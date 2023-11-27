using Aishopping.Models;
using Aishopping.DTos.Requests;
using Aishopping.DTos.Responses;
namespace Aishopping.Repositories
{
    public interface IOrderRepository
    {
        Task<OrderResponseDto?> GetOrderAsync(int id);
        Task<List<OrderResponseDto>?> GetOrdersAsync();
        Task<List<OrderResponseDto>?> GetOrderUserAsync();
        Task<OrderResponseDto> CreateOrderAsync(AddOrder addOrder);
        Task<bool> UpdateOrderAsync(int id,UpdateOrder updateOrder);
        Task<bool> DeleteOrderAsync(int id);

    }
}