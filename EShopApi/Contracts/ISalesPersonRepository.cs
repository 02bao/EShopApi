using EShopApi.Models;

namespace EShopApi.Contracts
{
    public interface ISalesPersonRepository
    {
        IEnumerable<SalesPersons> GetAll();
        Task<SalesPersons> Add(SalesPersons salesPerson);
        Task<SalesPersons> Update(SalesPersons salesPerson);
        Task<SalesPersons> Find(int id);
        Task<SalesPersons> Remove(int id);
        Task<bool> IsExist(int id);
    }
}
