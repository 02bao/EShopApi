using EShopApi.Contracts;
using EShopApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesPersonsController : ControllerBase
    {
        private readonly ISalesPersonRepository _salesPersonRepository;

        public SalesPersonsController(ISalesPersonRepository salesPersonRepository)
        {
            _salesPersonRepository = salesPersonRepository;
        }

        [HttpGet]
        public IEnumerable<SalesPersons> GetSalesPersons()
        {
            return _salesPersonRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalesPersons>> GetSalesPersons(int id)
        {
            var salesPersons = await _salesPersonRepository.Find(id);
            if(salesPersons == null)
            {
                return NotFound();
            }
            return salesPersons;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutsalesPersons(int id, SalesPersons salesPersons)
        {
            if(id != salesPersons.SalesPersonsId)
            {
                return BadRequest();
            }
            await _salesPersonRepository.Update(salesPersons);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<SalesPersons>> PostSalesPersons(SalesPersons salesPersons)
        {
            await _salesPersonRepository.Add(salesPersons);
            return CreatedAtAction("GetSalesPersons", new {id = salesPersons.SalesPersonsId}, salesPersons);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SalesPersons>> DeleteSalesPErsons(int id)
        {
            var salesPersons = await _salesPersonRepository.Find(id);
            if(salesPersons == null)
            {
                return NotFound();
            }

            await _salesPersonRepository.Remove(id);
            return salesPersons;
        }

        private async Task<bool> SalesPersonsExists(int id)
        {
            return await _salesPersonRepository.IsExist(id);
        }
    }
}
