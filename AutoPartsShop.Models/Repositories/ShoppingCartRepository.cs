using AutoPartsShop.DataAccess.Data;
using AutoPartsShop.DataAccess.DTOs;
using AutoPartsShop.DataAccess.Entities;
using AutoPartsShop.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartsShop.DataAccess.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly DatabaseContext databaseContext;

        public ShoppingCartRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        private async Task<bool> ShoppingCartProductExists(int shoppingCartId, int productId)
        {
            return await this.databaseContext.ShoppingCartProducts
                .AnyAsync(c => c.ShoppingCartId == shoppingCartId && c.ProductId == productId);
        }

        public async Task<ShoppingCartProduct> AddProduct(ShoppingCartProductToAddDTO shoppingCartProductToAddDTO)
        {
            if (await ShoppingCartProductExists(shoppingCartProductToAddDTO.ShoppingCartId, shoppingCartProductToAddDTO.ProductId) == false)
            {
                var product = new ShoppingCartProduct
                {
                    ShoppingCartId = shoppingCartProductToAddDTO.ShoppingCartId,
                    ProductId = shoppingCartProductToAddDTO.ProductId,
                    Qty = shoppingCartProductToAddDTO.Qty
                };

                await this.databaseContext.ShoppingCartProducts.AddAsync(product);
                await this.databaseContext.SaveChangesAsync();

                return product;
            }

            throw new Exception("Product already exists in the shopping cart.");
        }

        public async Task<ShoppingCartProduct> DeleteProduct(int id)
        {
            var product = await this.databaseContext.ShoppingCartProducts.FindAsync(id);

            if (product != null)
            {
                this.databaseContext.ShoppingCartProducts.Remove(product);
                await this.databaseContext.SaveChangesAsync();
            }

            return product;
        }

        public async Task<ShoppingCartProduct> GetProduct(int id)
        {
            return await this.databaseContext.ShoppingCartProducts
                .Where(sp => sp.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ShoppingCartProduct>> GetProducts(int userId)
        {
            var products = await (from cartProduct in this.databaseContext.ShoppingCartProducts
                                  join cart in this.databaseContext.ShoppingCarts
                                  on cartProduct.ShoppingCartId equals cart.Id
                                  where cart.UserId == userId
                                  select cartProduct)
                                  .ToListAsync();

            return products;
        }

        public async Task<ShoppingCartProduct> UpdateQty(int id, ShoppingCartProductQtyUpdateDTO cartProductQtyUpdateDTO)
        {
            var product = await this.databaseContext.ShoppingCartProducts.FindAsync(id);

            if (product != null)
            {
                product.Qty = cartProductQtyUpdateDTO.Qty;
                await this.databaseContext.SaveChangesAsync();
                return product;
            }

            return null;
        }
    }
}
