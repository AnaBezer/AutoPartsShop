using AutoPartsShop.DataAccess.Entities;

namespace AutoPartsShop.DataAccess.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<ProductCategory>> GetCategories();
        Task<Product> GetProduct(int id);
        Task<ProductCategory> GetCategory(int id);
        Task<IEnumerable<Product>> GetProductsByCategory(int id);
    }
}
