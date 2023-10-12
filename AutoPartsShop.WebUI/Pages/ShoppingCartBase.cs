using AutoPartsShop.Models.DTOs;
using AutoPartsShop.WebUI.Services.Interfaces;
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
        public List<CartItemDTO> ShoppingCartItems { get; set; }
        public string ErrorMessage { get; set; }
        protected string TotalPrice { get; set; }
        protected int TotalQuantity { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                ShoppingCartItems = await ShoppingCartService.GetItems(HardCoded.UserId);
                CartChanged();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected async Task DeleteCartItem_Click(int id)
        {
            var cartItemDTO = await ShoppingCartService.DeleteItem(id);

            RemoveCartItem(id);
            CartChanged();


        }

        protected async Task UpdateQtyCartItem_Click(int id, int qty)
        {
            try
            {
                if (qty > 0)
                {
                    // Update the item's quantity
                    var updateItemDTO = new CartItemQtyUpdateDTO
                    {
                        CartItemId = id,
                        Qty = qty
                    };

                    var returnedUpdateItemDTO = await this.ShoppingCartService.UpdateQty(updateItemDTO);

                    // Update item total price
                    UpdateItemTotalPrice(returnedUpdateItemDTO);

                    CartChanged();

                    // Call JS interop to hide the update button
                    await MakeUpdateQtyButtonVisible(id, false);
                }
                else
                {
                    var item = this.ShoppingCartItems.FirstOrDefault(x => x.Id == id);

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
            TotalPrice = this.ShoppingCartItems.Sum(p => p.TotalPrice).ToString("C");
        }

        private void SetTotalQuantity()
        {
            TotalQuantity = this.ShoppingCartItems.Sum(p => p.Qty);
        }

        protected async Task UpdateQty_Input(int id)
        {
            await MakeUpdateQtyButtonVisible(id, true);
        }

        protected async Task MakeUpdateQtyButtonVisible(int id, bool visible)
        {
            await Js.InvokeVoidAsync("MakeUpdateQtyButtonVisible", id, visible);
        }

        private void UpdateItemTotalPrice(CartItemDTO cartItemDTO)
        {
            var item = GetCartItem(cartItemDTO.Id);

            if (item != null)
            {
                item.TotalPrice = cartItemDTO.Price * cartItemDTO.Qty;
            }
        }

        private void CalculateCartSummaryTotals()
        {
            SetTotalPrice();
            SetTotalQuantity();
        }

        private CartItemDTO GetCartItem(int id)
        {
            return ShoppingCartItems.FirstOrDefault(x => x.Id == id);
        }

        private void RemoveCartItem(int id)
        {
            var cartItemDTO = GetCartItem(id);

            ShoppingCartItems.Remove(cartItemDTO);
        }

        private void CartChanged()
        {
            CalculateCartSummaryTotals();
            ShoppingCartService.RaiseEventOnShoppingCartChanged(TotalQuantity);
        }
    }
}
