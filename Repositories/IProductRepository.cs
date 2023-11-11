using Aishopping.DTos.Requests;
using Aishopping.Models;
namespace Aishopping.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetProductAsync(int id);
        Task<List<Product>?> GetProductsAsync();
        Task<Product> CreateProductAsync(AddProduct addProduct);
        Task<bool> UpdateProductAsync(int id,UpdateProduct updateProduct);
        Task<bool> DeleteProductAsync(int id);
    }
}