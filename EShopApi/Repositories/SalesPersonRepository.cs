using EShopApi.Contracts;
using EShopApi.Data;
using EShopApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EShopApi.Repositories
{
    public class SalesPersonRepository : ISalesPersonRepository
    {
        private readonly EshopApi_DBContext _context;

        public SalesPersonRepository(EshopApi_DBContext context)
        {
            _context = context;
        }
        public async Task<SalesPersons> Add(SalesPersons salesPerson)
        {
            await _context.SalesPersons.AddAsync(salesPerson);
            await _context.SaveChangesAsync();
            return salesPerson;
        }

        public async Task<SalesPersons> Find(int id)
        {
            return await _context.SalesPersons.SingleOrDefaultAsync(s => s.SalesPersonsId == id);
        }

        public IEnumerable<SalesPersons> GetAll()
        {
            return _context.SalesPersons;
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.SalesPersons.AnyAsync(s=> s.SalesPersonsId ==id);
        }

        public async Task<SalesPersons> Remove(int id)
        {
            var salesPerson = await _context.SalesPersons.SingleAsync(s => s.SalesPersonsId == id);
            _context.SalesPersons.Remove(salesPerson);
            await _context.SaveChangesAsync();
            return salesPerson;
        }

        public async Task<SalesPersons> Update(SalesPersons salesPerson)
        {
            _context.SalesPersons.Update(salesPerson);
            await _context.SaveChangesAsync();
            return salesPerson;
        }
    }
}
