using AutoPartsShop.DataAccess.DTOs;

namespace AutoPartsShop.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProduct(int id);
        Task<IEnumerable<ProductCategoryDTO>> GetProductCategories();
        Task<IEnumerable<ProductDTO>> GetProductsByCategory(int categoryId);
    }
}
