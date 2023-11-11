using Aishopping.DTos.Requests;
using Aishopping.Models;
using Microsoft.EntityFrameworkCore;
namespace Aishopping.Repositories.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Product?> GetProductAsync(int id)
        {
            Product? product = await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product ?? null;
        }

        public async Task<List<Product>?> GetProductsAsync()
        {
            List<Product> products = await _appDbContext.Products.ToListAsync();
            return products.Count > 0 ? products : null;
        }
        public async Task<Product> CreateProductAsync(AddProduct addProduct)
        {
            Product newUser = new()
            {
                Name = addProduct.Name,
                Price = addProduct.Price
            };
            await _appDbContext.Products.AddAsync(newUser);
            await _appDbContext.SaveChangesAsync();
            return newUser;
        }
        public async Task<bool> UpdateProductAsync(int id, UpdateProduct updateProduct)
        {
            var existingProduct = await _appDbContext.Products.FindAsync(id);
            if (existingProduct != null)
            {
                existingProduct.Name = updateProduct.Name;
                existingProduct.Price = updateProduct.Price;
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var existingProduct = await _appDbContext.Products.FindAsync(id);
            if (existingProduct != null)
            {
                _appDbContext.Products.Remove(existingProduct);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}