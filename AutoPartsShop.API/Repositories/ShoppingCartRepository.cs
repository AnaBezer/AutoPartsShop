using AutoPartsShop.API.Data;
using AutoPartsShop.API.Models;
using AutoPartsShop.API.Repositories.Interfaces;
using AutoPartsShop.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsShop.API.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {

        private readonly DatabaseContext databaseContext;

        public ShoppingCartRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        private async Task<bool> CartItemExists(int cartId, int productId)
        {
            return await this.databaseContext.CartItems.AnyAsync(c => c.CartId == cartId &&
                                                                     c.ProductId == productId);

        }
        public async Task<CartItem> AddItem(CartItemToAddDTO cartItemToAddDto)
        {
            if (await CartItemExists(cartItemToAddDto.CartId, cartItemToAddDto.ProductId) == false)
            {
                var item = await (from product in this.databaseContext.Products
                                  where product.Id == cartItemToAddDto.ProductId
                                  select new CartItem
                                  {
                                      CartId = cartItemToAddDto.CartId,
                                      ProductId = product.Id,
                                      Qty = cartItemToAddDto.Qty
                                  }).SingleOrDefaultAsync();

                if (item != null)
                {
                    var result = await this.databaseContext.CartItems.AddAsync(item);
                    await this.databaseContext.SaveChangesAsync();
                    return result.Entity;
                }
            }

            return null;

        }

        public async Task<CartItem> DeleteItem(int id)
        {
            var item = await this.databaseContext.CartItems.FindAsync(id);

            if (item != null)
            {
                this.databaseContext.CartItems.Remove(item);
                await this.databaseContext.SaveChangesAsync();
            }

            return item;

        }

        public async Task<CartItem> GetItem(int id)
        {
            return await (from cart in this.databaseContext.Carts
                          join cartItem in this.databaseContext.CartItems
                          on cart.Id equals cartItem.CartId
                          where cartItem.Id == id
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              ProductId = cartItem.ProductId,
                              Qty = cartItem.Qty,
                              CartId = cartItem.CartId
                          }).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CartItem>> GetItems(int userId)
        {
            return await (from cart in this.databaseContext.Carts
                          join cartItem in this.databaseContext.CartItems
                          on cart.Id equals cartItem.CartId
                          where cart.UserId == userId
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              ProductId = cartItem.ProductId,
                              Qty = cartItem.Qty,
                              CartId = cartItem.CartId
                          }).ToListAsync();
        }

        public async Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDTO cartItemQtyUpdateDTO)
        {
            var item = await this.databaseContext.CartItems.FindAsync(id);

            if (item != null)
            {
                item.Qty = cartItemQtyUpdateDTO.Qty;
                await this.databaseContext.SaveChangesAsync();
                return item;
            }

            return null;
        }
    }
}
