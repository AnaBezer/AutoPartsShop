using AutoPartsShop.DataAccess.Data;
using AutoPartsShop.DataAccess.Entities;
using AutoPartsShop.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsShop.DataAccess.Repositories
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
        public async Task<Product> GetProduct(int id)
        {
            var product = await this.databaseContext.Products.FindAsync(id);
            return product;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await this.databaseContext.Products.ToListAsync();
            return products;
        }
        public async Task<IEnumerable<Product>> GetProductsByCategory(int id)
        {
            var products = await (from product in databaseContext.Products
                                  where product.CategoryId == id
                                  select product).ToListAsync();

            return products;
        }
    }
}
