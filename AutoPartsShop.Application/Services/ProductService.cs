using AutoPartsShop.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using AutoPartsShop.DataAccess.DTOs;

namespace AutoPartsShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ProductDTO> GetProduct(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Products/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ProductDTO);
                    }

                    return await response.Content.ReadFromJsonAsync<ProductDTO>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }

            }
            catch (Exception)
            {
                // Log exception
                throw;
            }
        }
        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            try
            {
                var products = await this.httpClient.GetFromJsonAsync<IEnumerable<ProductDTO>>("api/Products");
                return products;
            }
            catch (Exception)
            {
                // Log exception 
                throw;
            }
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByCategory(int categoryId)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Products/{categoryId}/GetProductsByCategory");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProductDTO>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<ProductDTO>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code - {response.StatusCode} Message - {message}");
                }
            }
            catch (Exception)
            {
                //Log Exception
                throw;
            }
        }

        public async Task<IEnumerable<ProductCategoryDTO>> GetProductCategories()
        {
            try
            {
                var response = await httpClient.GetAsync("api/Products/GetProductCategories");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProductCategoryDTO>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<ProductCategoryDTO>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code - {response.StatusCode} Message - {message}");
                }
            }
            catch (Exception)
            {
                //Log Exception
                throw;
            }
        }
    }
}

