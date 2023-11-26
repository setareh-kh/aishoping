using Aishopping.Models;
using AutoMapper;
using Aishopping.DTos.Requests;
using Microsoft.EntityFrameworkCore;
namespace Aishopping.Repositories.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private IMapper _mapper;
        public OrderRepository(AppDbContext appDbContext,IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper=mapper;
        }
        public async Task<Order?> GetOrderAsync(int id)
        {
            Order? Order = await _appDbContext.Orders.FindAsync(id);
            return Order ?? null;
        }

        public async Task<List<Order>?> GetOrdersAsync()
        {
            List<Order>? orders = await _appDbContext.Orders.ToListAsync();
            return orders.Count > 0 ? orders : null;
        }
        public async Task<Order> CreateOrderAsync(AddOrder addOrder)
        {
            var order=_mapper.Map<Order>(addOrder);
            order.OrderDate = DateTime.Now;
            await _appDbContext.Orders.AddAsync(order);
            await _appDbContext.SaveChangesAsync();
            return order;
        }
        public async Task<bool> UpdateOrderAsync(int id, UpdateOrder updateOrder)
        {
            var Order = await _appDbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (Order != null)
            {
                _mapper.Map(updateOrder, Order);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var Order = await _appDbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (Order != null)
            {
                _appDbContext.Remove(Order);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            else
                return false;

        }
        public async Task<List<Order>?> GetOrderUserAsync()
        {
            var result = await _appDbContext.Orders.Include(order=> order.User).ToListAsync();
            return result ?? null;
        }
    }
}