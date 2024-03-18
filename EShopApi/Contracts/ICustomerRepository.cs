using EShopApi.Models;

namespace EShopApi.Contracts
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Task<Customer> Add(Customer customer);  
        Task<Customer> Update(Customer customer);
        Task<Customer> Find(int id);
        Task<Customer> Remove(int id);
        Task<bool> IsExists(int id);
    }
}
