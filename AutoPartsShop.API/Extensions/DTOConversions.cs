using AutoPartsShop.API.Models;
using AutoPartsShop.Models.DTOs;
using System.Net.NetworkInformation;

namespace AutoPartsShop.API.Extensions
{
    public static class DTOConversions
    {

        public static IEnumerable<ProductCategoryDTO> ConvertToDTO(this IEnumerable<ProductCategory> productCategories)
        {
            return (from productCategory in productCategories
                    select new ProductCategoryDTO
                    {
                        Id = productCategory.Id,
                        CategoryName = productCategory.CategoryName,
                        IconCSS = productCategory.IconCSS

                    }).ToList();
        }
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

        public static IEnumerable<CartItemDTO> ConvertToDTO(this IEnumerable<CartItem> cartItems,
                                                            IEnumerable<Product> products)
        {
            return (from cartItem in cartItems
                    join product in products
                    on cartItem.ProductId equals product.Id
                    select new CartItemDTO
                    {
                        Id = cartItem.Id,
                        ProductId = cartItem.ProductId,
                        ProductName = product.ProductName,
                        ProductDescription = product.Description,
                        ProductImageURL = product.ImageURL,
                        Price = product.Price,
                        CartId = cartItem.CartId,
                        Qty = cartItem.Qty,
                        TotalPrice = product.Price * cartItem.Qty,
                    }).ToList();
        }

        public static CartItemDTO ConvertToDTO(this CartItem cartItem,
                                                    Product product)
        {
            if (cartItem == null)
            {
                throw new ArgumentNullException(nameof(cartItem));
            }

            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            return new CartItemDTO
            {
                Id = cartItem.Id,
                ProductId = cartItem.ProductId,
                ProductName = product.ProductName,
                ProductDescription = product.Description,
                ProductImageURL = product.ImageURL,
                Price = product.Price,
                CartId = cartItem.CartId,
                Qty = cartItem.Qty,
                TotalPrice = product.Price * cartItem.Qty,
            };
        }

    }
}
