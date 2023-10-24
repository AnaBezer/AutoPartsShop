using AutoPartsShop.DataAccess.DTOs;
using AutoPartsShop.DataAccess.Entities;

namespace AutoPartsShop.DataAccess.Repositories.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCartProduct> AddProduct(ShoppingCartProductToAddDTO cartProductToAddDTO);
        Task<ShoppingCartProduct> UpdateQty(int id, ShoppingCartProductQtyUpdateDTO cartProductQtyUpdateDTO);
        Task<ShoppingCartProduct> DeleteProduct(int id);
        Task<ShoppingCartProduct> GetProduct(int id);
        Task<IEnumerable<ShoppingCartProduct>> GetProducts(int userId);
    }
}
