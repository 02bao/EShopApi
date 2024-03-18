using EShopApi.Models;

namespace EShopApi.Contracts
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetAll();
        Task<Products> Add(Products products);
        Task<Products> Update(Products products);
        Task<Products> Remove(int id);
        Task<Products> Find(int id);
        Task<bool> IsExist(int id);
    }
}
