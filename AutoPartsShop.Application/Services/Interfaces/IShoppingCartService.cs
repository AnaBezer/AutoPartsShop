using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoPartsShop.DataAccess.DTOs;

namespace AutoPartsShop.Application.Services.Interfaces
{
    public interface IShoppingCartService
    {
        Task<List<ShoppingCartProductDTO>> GetProducts(int userId);
        Task<ShoppingCartProductDTO> AddProduct(ShoppingCartProductToAddDTO shoppingCartProductToAddDTO);
        Task<ShoppingCartProductDTO> DeleteProduct(int id);
        Task<ShoppingCartProductDTO> UpdateQty(ShoppingCartProductQtyUpdateDTO shoppingCartProductQtyUpdateDTO);

        event Action<int> OnShoppingCartChanged;
        void RaiseEventOnShoppingCartChanged(int totalQty);
    }
}
