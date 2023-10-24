using AutoPartsShop.API.Models;

namespace AutoPartsShop.API.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetItems();
        Task<IEnumerable<ProductCategory>> GetCategories();
        Task<Product> GetItem(int id);
        Task<ProductCategory> GetCategory(int id);
        Task<IEnumerable<Product>> GetItemsByCategory(int id);
    }
}
