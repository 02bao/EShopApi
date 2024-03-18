using EShopApi.Contracts;
using EShopApi.Data;
using EShopApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EShopApi.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private EshopApi_DBContext _Context;
        public CustomerRepository(EshopApi_DBContext context)
        {
            _Context = context;
        }

        public async Task<Customer> Add(Customer customer)
        {
            await _Context.Customer.AddAsync(customer);
            await _Context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> Find(int id)
        {
            return await _Context.Customer.Include(c => c.Orders).SingleOrDefaultAsync(c => c.CustomerId == id);
        }
        public IEnumerable<Customer> GetAll() 
        {
            return _Context.Customer.ToList();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _Context.Customer.AnyAsync(c => c.CustomerId == id);
        }
        public async Task<Customer> Remove(int id)
        {
            var customer = await _Context.Customer.SingleAsync(c => c.CustomerId == id);
            _Context.Customer.Remove(customer);
            await _Context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> Update(Customer customer)
        {
            _Context.Customer.Update(customer);
            await _Context.SaveChangesAsync();
            return customer;

        }
    }
}
