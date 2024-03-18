using EShopApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
namespace EShopApi.Contracts
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes ="Bearer")]
    public class CuxtomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CuxtomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            return new ObjectResult(_customerRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            var customer = await _customerRepository.Find(id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
        {
            await _customerRepository.Add(customer);
            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        [HttpPut]
        public async Task<IActionResult> PutCustomer([FromBody] Customer customer)
        {
            await _customerRepository.Update(customer);
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute,] int id)
        {
            await _customerRepository.Remove(id);
            return Ok();
        }
    }
}
