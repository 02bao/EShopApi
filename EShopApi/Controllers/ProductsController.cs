using EShopApi.Contracts;
using EShopApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IEnumerable<Products> GetProducts()
        {
            return _productRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProducts(int id)
        {
            var products = await _productRepository.Find(id);

            if(products == null)
            {
                return NotFound();
            }

            return products;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, Products products)
        {
            if(id != products.ProductsId)
            {
                return BadRequest();
            }
            await _productRepository.Update(products);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Products>> PostProducts(Products products)
        {
            await _productRepository.Add(products);
            return CreatedAtAction("GetProducts", new { id = products.ProductsId }, products);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Products>> DeleteProducts(int id)
        {
            var products = await _productRepository.Find(id);
            if(products == null)
            {
                return NotFound();
            }
            await _productRepository.Remove(id);
            return products;
        }
        private async Task<bool> ProductsExists(int id)
        {
            return await _productRepository.IsExist(id);
        }

    }
}
