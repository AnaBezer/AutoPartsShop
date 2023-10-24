using AutoPartsShop.DataAccess.DTOs;
using AutoPartsShop.DataAccess.Entities;

namespace AutoPartsShop.DataAccess.Extensions
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
        public static IEnumerable<ShoppingCartProductDTO> ConvertToDTO(this IEnumerable<ShoppingCartProduct> cartProducts,
                                                            IEnumerable<Product> products)
        {
            return (from cartProduct in cartProducts
                    join product in products
                    on cartProduct.ProductId equals product.Id
                    select new ShoppingCartProductDTO
                    {
                        Id = cartProduct.Id,
                        ProductId = cartProduct.ProductId,
                        ProductName = product.ProductName,
                        ProductDescription = product.Description,
                        ProductImageURL = product.ImageURL,
                        Price = product.Price,
                        ShoppingCartId = cartProduct.ShoppingCartId,
                        Qty = cartProduct.Qty,
                        TotalPrice = product.Price * cartProduct.Qty,
                    }).ToList();
        }
        public static ShoppingCartProductDTO ConvertToDTO(this ShoppingCartProduct shoppingCartProduct,
                                                    Product product)
        {
            if (shoppingCartProduct == null)
            {
                throw new ArgumentNullException(nameof(shoppingCartProduct));
            }

            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            return new ShoppingCartProductDTO
            {
                Id = shoppingCartProduct.Id,
                ProductId = shoppingCartProduct.ProductId,
                ProductName = product.ProductName,
                ProductDescription = product.Description,
                ProductImageURL = product.ImageURL,
                Price = product.Price,
                ShoppingCartId = shoppingCartProduct.ShoppingCartId,
                Qty = shoppingCartProduct.Qty,
                TotalPrice = product.Price * shoppingCartProduct.Qty,
            };
        }

    }
}

