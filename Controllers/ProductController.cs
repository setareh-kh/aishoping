using Aishopping.DTos.Requests;
using Aishopping.Models;
using Aishopping.Repositories.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepository;
        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Product>? Products = await _productRepository.GetProductsAsync();
            return Ok(Products == null ? "No Any Product" : Products);
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            Product? product = await _productRepository.GetProductAsync(id);
            return Ok(product == null ? "no Product with this Id" : product);
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] AddProduct addProduct)
        {
            var result = await _productRepository.CreateProductAsync(addProduct);
            return Ok("Product is successfully registered");
        }
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateProduct updateProduct)
        {
            bool result = await _productRepository.UpdateProductAsync(id, updateProduct);
            return Ok(result ? "Your Product has been updated" : "no Product with this Id");
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool isDeleted = await _productRepository.DeleteProductAsync(id);
            return Ok(isDeleted ? "The Product was deleted" : "no Product with this Id");
        }
    }
}