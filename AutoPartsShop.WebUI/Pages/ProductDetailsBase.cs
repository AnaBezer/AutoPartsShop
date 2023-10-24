using AutoPartsShop.Application.Services.Interfaces;
using AutoPartsShop.DataAccess.DTOs;

using Microsoft.AspNetCore.Components;

namespace AutoPartsShop.WebUI.Pages
{
    public class ProductDetailsBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }

        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ProductDTO Product { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Product = await ProductService.GetProduct(Id);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected async Task AddToShoppingCart_Click(ShoppingCartProductToAddDTO shoppingCartProductToAddDTO)
        {
            try
            {
                var cartItemDTO = await ShoppingCartService.AddProduct(shoppingCartProductToAddDTO);
                NavigationManager.NavigateTo("/ShoppingCart");
            }
            catch (Exception)
            {

                //Log Exception
            }
        }
    }
}
