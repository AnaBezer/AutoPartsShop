using AutoPartsShop.Models.DTOs;
using AutoPartsShop.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace AutoPartsShop.WebUI.Pages
{
    public class ProductsByCategoryBase : ComponentBase
    {
        [Parameter]
        public int CategoryId { get; set; }
        [Inject]
        public IProductService ProductService { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }
        public string CategoryName { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                Products = await ProductService.GetItemsByCategory(CategoryId);

                if (Products != null && Products.Count() > 0)
                {
                    var productDTO = Products.FirstOrDefault(p => p.CategoryId == CategoryId);

                    if (productDTO != null)
                    {
                        CategoryName = productDTO.CategoryName;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
