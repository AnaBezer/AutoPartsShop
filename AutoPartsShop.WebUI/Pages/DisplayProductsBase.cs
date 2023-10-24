using AutoPartsShop.DataAccess.DTOs;
using Microsoft.AspNetCore.Components;

namespace AutoPartsShop.WebUI.Pages
{
    public class DisplayProductsBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductDTO> Products { get; set; }

    }
}
