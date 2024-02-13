using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using AutoPartsShop.Application.Services.Interfaces;
using AutoPartsShop.DataAccess.DTOs;
using Newtonsoft.Json;

namespace AutoPartsShop.Application.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly HttpClient httpClient;

        public event Action<int> OnShoppingCartChanged;

        public ShoppingCartService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ShoppingCartProductDTO> AddProduct(ShoppingCartProductToAddDTO shoppingCartProductToAddDTO)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<ShoppingCartProductToAddDTO>("api/ShoppingCarts", shoppingCartProductToAddDTO);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default;
                    }

                    return await response.Content.ReadFromJsonAsync<ShoppingCartProductDTO>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"HTTP status:{response.StatusCode} Message - {message}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ShoppingCartProductDTO> DeleteProduct(int id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"api/ShoppingCarts/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ShoppingCartProductDTO>();
                }

                return default;
            }
            catch (Exception)
            {
                //Log Exception
                throw;
            }
        }

        public async Task<List<ShoppingCartProductDTO>> GetProducts(int userId)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/ShoppingCarts/{userId}/GetProducts");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ShoppingCartProductDTO>().ToList(); ;
                    }
                    return await response.Content.ReadFromJsonAsync<List<ShoppingCartProductDTO>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code:{response.StatusCode} Message: {message}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RaiseEventOnShoppingCartChanged(int totalQty)
        {
            if (OnShoppingCartChanged != null)
            {
                OnShoppingCartChanged.Invoke(totalQty);
            }
        }

        public async Task<ShoppingCartProductDTO> UpdateQty(ShoppingCartProductQtyUpdateDTO shoppingCartProductQtyUpdateDTO)
        {
            try
            {
                var jsonRequest = JsonConvert.SerializeObject(shoppingCartProductQtyUpdateDTO);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");

                var response = await httpClient.PatchAsync($"api/ShoppingCarts/{shoppingCartProductQtyUpdateDTO.ShoppingCartProductId}", content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ShoppingCartProductDTO>();
                }
                return null;

            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }
    }
}
