using Aishopping.Models;
using AutoMapper;
using Aishopping.DTos.Requests;
using Microsoft.EntityFrameworkCore;
using Aishopping.DTos.Responses;
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
        public async Task<OrderResponseDto?> GetOrderAsync(int id)
        {
            Order? order = await _appDbContext.Orders.FindAsync(id);
            var response= _mapper.Map<OrderResponseDto>(order);
            return response ?? null;
        }

        public async Task<List<OrderResponseDto>?> GetOrdersAsync()
        {
            List<Order>? orders = await _appDbContext.Orders.ToListAsync();
            var responses= orders.Select(o=>_mapper.Map<OrderResponseDto>(o)).ToList();
            return responses.Count > 0 ? responses : null;
        }
        public async Task<OrderResponseDto> CreateOrderAsync(AddOrder addOrder)
        {
            var order=_mapper.Map<Order>(addOrder);
            order.OrderDate = DateTime.Now;
            await _appDbContext.Orders.AddAsync(order);
            await _appDbContext.SaveChangesAsync();
            var response= _mapper.Map<OrderResponseDto>(order);
            return response;
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
        public async Task<List<OrderResponseDto>?> GetOrderUserAsync()
        {
            var result = await _appDbContext.Orders.Include(order=> order.User).ToListAsync();
            var responses= result.Select(o=>_mapper.Map<OrderResponseDto>(o)).ToList();
            return responses ?? null;
        }
    }
}