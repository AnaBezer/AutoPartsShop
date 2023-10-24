using AutoPartsShop.API.Models;
using AutoPartsShop.Models.DTOs;

namespace AutoPartsShop.API.Repositories.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task<CartItem> AddItem(CartItemToAddDTO cartItemToAddDTO);
        Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDTO cartItemQtyUpdateDTO);
        Task<CartItem> DeleteItem(int id);
        Task<CartItem> GetItem(int id);
        Task<IEnumerable<CartItem>> GetItems(int userId);
    }
}
