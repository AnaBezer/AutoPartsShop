using AutoPartsShop.API.Data;
using AutoPartsShop.API.Models;
using AutoPartsShop.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsShop.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext databaseContext;

        public ProductRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories = await this.databaseContext.ProductCategories.ToListAsync();
            return categories;
        }

        public async Task<ProductCategory> GetCategory(int id)
        {
            var category = await this.databaseContext.ProductCategories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<Product> GetItem(int id)
        {
            var product = await this.databaseContext.Products.FindAsync(id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await this.databaseContext.Products.ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> GetItemsByCategory(int id)
        {
            var products = await (from product in databaseContext.Products
                                  where product.CategoryId == id
                                  select product).ToListAsync();

            return products;
        }
    }
}
