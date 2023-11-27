using Aishopping.DTos.Requests;
using Aishopping.DTos.Responses;
using Aishopping.Models;
namespace Aishopping.Repositories
{
    public interface IProductRepository
    {
        Task<ProductResponseDto?> GetProductAsync(int id);
        Task<List<ProductResponseDto>?> GetProductsAsync();
        Task<ProductResponseDto> CreateProductAsync(AddProduct addProduct);
        Task<bool> UpdateProductAsync(int id,UpdateProduct updateProduct);
        Task<bool> DeleteProductAsync(int id);
    }
}