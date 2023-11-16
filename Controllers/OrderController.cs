using Aishopping.Models;
using Aishopping.Repositories;
using Aishopping.Repositories.Repositories;
using DTos.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Order>? orders = await _orderRepository.GetOrdersAsync();
            return Ok(orders == null ? "No Any Order" : orders);
        }
        [HttpGet]
        [Route("GetAllOrderWithUser")]
        public async Task<IActionResult> GetAllOrderUserAsync()
        {
            List<Order>? orders = await _orderRepository.GetOrderUserAsync();
            return Ok(orders == null ? "No Any Order" : orders);
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetorderAsync(int id)
        {
            Order? order = await _orderRepository.GetOrderAsync(id);
            return Ok(order == null ? "no order with this Id" : order);
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] AddOrder addOrder)
        {
            var result = await _orderRepository.CreateOrderAsync(addOrder);
            return Ok("order is successfully registered");
        }
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateOrder updateOrder)
        {
            bool result = await _orderRepository.UpdateOrderAsync(id, updateOrder);
            return Ok(result ? "Your order has been updated" : "no order with this Id");
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool isDeleted = await _orderRepository.DeleteOrderAsync(id);
            return Ok(isDeleted ? "The order was deleted" : "no order with this Id");
        }
        
    }
}