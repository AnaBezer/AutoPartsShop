using AutoPartsShop.Application.Services.Interfaces;
using AutoPartsShop.DataAccess.DTOs;

using Microsoft.AspNetCore.Components;

namespace AutoPartsShop.WebUI.Shared
{
    public class ProductCategoriesNavMenuBase : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }

        public IEnumerable<ProductCategoryDTO> ProductCategoryDTOs { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                ProductCategoryDTOs = await ProductService.GetProductCategories();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

        }
    }
}
