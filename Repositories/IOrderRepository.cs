using Aishopping.Models;
using Aishopping.DTos.Requests;
namespace Aishopping.Repositories
{
    public interface IOrderRepository
    {
        Task<Order?> GetOrderAsync(int id);
        Task<List<Order>?> GetOrdersAsync();
        Task<List<Order>?> GetOrderUserAsync();
        Task<Order> CreateOrderAsync(AddOrder addOrder);
        Task<bool> UpdateOrderAsync(int id,UpdateOrder updateOrder);
        Task<bool> DeleteOrderAsync(int id);

    }
}