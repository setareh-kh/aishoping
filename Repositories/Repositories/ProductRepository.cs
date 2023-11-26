using Aishopping.DTos.Requests;
using Aishopping.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
namespace Aishopping.Repositories.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;
        private IMapper _mapper;
        public ProductRepository(AppDbContext appDbContext,IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper=mapper;
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
            var newProduct = _mapper.Map<Product>(addProduct);
            
            await _appDbContext.Products.AddAsync(newProduct);
            await _appDbContext.SaveChangesAsync();
            return newProduct;
        }
        public async Task<bool> UpdateProductAsync(int id, UpdateProduct updateProduct)
        {
            var existingProduct = await _appDbContext.Products.FindAsync(id);
            if (existingProduct != null)
            {
                _mapper.Map(updateProduct,existingProduct);
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