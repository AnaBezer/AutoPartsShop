using AutoPartsShop.Models.DTOs;
using AutoPartsShop.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace AutoPartsShop.WebUI.Pages
{
    public class ProductsBase : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }

        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Products = await ProductService.GetItems();

            var shoppingCartItems = await ShoppingCartService.GetItems(HardCoded.UserId);
            var totalQty = shoppingCartItems.Sum(i => i.Qty);

            ShoppingCartService.RaiseEventOnShoppingCartChanged(totalQty);
        }

        protected IOrderedEnumerable<IGrouping<int, ProductDTO>> GetGroupedProductsByCategory()
        {
            var groupedProducts = Products
                .GroupBy(product => product.CategoryId)
                .OrderBy(group => group.Key);

            return groupedProducts;
        }

        protected string GetCategoryName(IGrouping<int, ProductDTO> groupedProductDTOs)
        {
            return groupedProductDTOs.FirstOrDefault(p => p.CategoryId == groupedProductDTOs.Key).CategoryName;
        }


    }
}
