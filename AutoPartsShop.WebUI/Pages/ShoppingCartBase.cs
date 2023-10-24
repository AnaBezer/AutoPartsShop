using AutoPartsShop.Application.Services.Interfaces;
using AutoPartsShop.DataAccess.DTOs;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace AutoPartsShop.WebUI.Pages
{
    public class ShoppingCartBase : ComponentBase
    {
        [Inject]
        public IJSRuntime Js { get; set; }

        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }
        public List<ShoppingCartProductDTO> ShoppingCartProducts { get; set; }
        public string ErrorMessage { get; set; }
        protected string TotalPrice { get; set; }
        protected int TotalQuantity { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                ShoppingCartProducts = await ShoppingCartService.GetProducts(HardCoded.UserId);
                ShoppingCartChanged();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected async Task DeleteCartProduct_Click(int id)
        {
            var cartProductDTO = await ShoppingCartService.DeleteProduct(id);

            RemoveShoppingCartProduct(id);
            ShoppingCartChanged();


        }

        protected async Task UpdateQtyCartProduct_Click(int id, int qty)
        {
            try
            {
                if (qty > 0)
                {
                    // Update the item's quantity
                    var updateProductDTO = new ShoppingCartProductQtyUpdateDTO
                    {
                        ShoppingCartProductId = id,
                        Qty = qty
                    };

                    var returnedUpdateProductDTO = await this.ShoppingCartService.UpdateQty(updateProductDTO);

                    // Update item total price
                    UpdateProductTotalPrice(returnedUpdateProductDTO);

                    ShoppingCartChanged();

                    // Call JS interop to hide the update button
                    await MakeUpdateQtyButtonVisible(id, false);
                }
                else
                {
                    var item = this.ShoppingCartProducts.FirstOrDefault(x => x.Id == id);

                    if (item != null)
                    {
                        item.Qty = 1;
                        item.TotalPrice = item.Price;

                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SetTotalPrice()
        {
            TotalPrice = this.ShoppingCartProducts.Sum(p => p.TotalPrice).ToString("C");
        }

        private void SetTotalQuantity()
        {
            TotalQuantity = this.ShoppingCartProducts.Sum(p => p.Qty);
        }

        protected async Task UpdateQty_Input(int id)
        {
            await MakeUpdateQtyButtonVisible(id, true);
        }

        protected async Task MakeUpdateQtyButtonVisible(int id, bool visible)
        {
            await Js.InvokeVoidAsync("MakeUpdateQtyButtonVisible", id, visible);
        }

        private void UpdateProductTotalPrice(ShoppingCartProductDTO cartProductDTO)
        {
            var product = GetShoppingCartProduct(cartProductDTO.Id);

            if (product != null)
            {
                product.TotalPrice = cartProductDTO.Price * cartProductDTO.Qty;
            }
        }

        private void CalculateShoppingCartSummaryTotals()
        {
            SetTotalPrice();
            SetTotalQuantity();
        }

        private ShoppingCartProductDTO GetShoppingCartProduct(int id)
        {
            return ShoppingCartProducts.FirstOrDefault(x => x.Id == id);
        }

        private void RemoveShoppingCartProduct(int id)
        {
            var cartProductDTO = GetShoppingCartProduct(id);

            ShoppingCartProducts.Remove(cartProductDTO);
        }

        private void ShoppingCartChanged()
        {
            CalculateShoppingCartSummaryTotals();
            ShoppingCartService.RaiseEventOnShoppingCartChanged(TotalQuantity);
        }
    }
}
