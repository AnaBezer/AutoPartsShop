using AutoPartsShop.API.Models;
using AutoPartsShop.Models.DTOs;

namespace AutoPartsShop.API.Extensions
{
    public static class DTOConversions
    {
        public static IEnumerable<ProductDTO> ConvertToDTO(this IEnumerable<Product> products, IEnumerable<ProductCategory> categories)
        {
            return products.Select(product => new ProductDTO
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Brand = product.Brand,
                Description = product.Description,
                ImageURL = product.ImageURL,
                Price = product.Price,
                Qty = product.Qty,
                CategoryId = product.CategoryId,
                CategoryName = categories.FirstOrDefault(c => c.Id == product.CategoryId)?.CategoryName
            });
        }

        public static ProductDTO ConvertToDTO(this Product product,
                                                     ProductCategory productCategory)
        {
            return new ProductDTO
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                ImageURL = product.ImageURL,
                Price = product.Price,
                Qty = product.Qty,
                CategoryId = product.CategoryId,
                CategoryName = productCategory.CategoryName,
            };

        }

    }
}
