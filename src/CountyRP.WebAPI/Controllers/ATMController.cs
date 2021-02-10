using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using CountyRP.Models;
using CountyRP.WebAPI.DbContexts;

namespace CountyRP.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ATMController : ControllerBase
    {
        private PropertyContext _propertyContext;

        public ATMController(PropertyContext propertyContext)
        {
            _propertyContext = propertyContext;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ATM), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] ATM atm)
        {
            var result = await CheckParamsAsync(atm);
            if (result != null)
                return result;

            var atmDAO = MapToDAO(atm);

            await _propertyContext.ATMs.AddAsync(atmDAO);
            await _propertyContext.SaveChangesAsync();

            atm.Id = atmDAO.Id;

            return Created("", atm);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ATM[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var ATMsDAO = await _propertyContext.ATMs
                .AsNoTracking()
                .ToArrayAsync();

            return Ok(
                ATMsDAO
                    .Select(a => MapToModel(a))
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ATM), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var atmDAO = await _propertyContext.ATMs
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
            if (atmDAO == null)
                return NotFound($"Банкомат с ID {id} не найдена");

            return Ok(
                MapToModel(atmDAO)
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ATM), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, [FromBody] ATM atm)
        {
            if (id != atm.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID банкомата {atm.Id}");

            var result = await CheckParamsAsync(atm);
            if (result != null)
                return result;

            var isAtmExisted = await _propertyContext.ATMs
                .AsNoTracking()
                .AnyAsync(a => a.Id == id);
            if (!isAtmExisted)
                return NotFound($"Банкомат с ID {id} не найден");

            var atmDAO = MapToDAO(atm);

            _propertyContext.ATMs.Update(atmDAO);
            await _propertyContext.SaveChangesAsync();

            return Ok(atm);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var atmDAO = await _propertyContext.ATMs
                .FirstOrDefaultAsync(a => a.Id == id);
            if (atmDAO == null)
                return NotFound($"Банкомат с ID {id} не найдена");

            _propertyContext.ATMs.Remove(atmDAO);
            await _propertyContext.SaveChangesAsync();

            return Ok();
        }

        private async Task<IActionResult> CheckParamsAsync(ATM atm)
        {
            if (atm.Position == null || atm.Position.Length != 3)
                return BadRequest("Количество координат должно быть равно 3");

            var result = await CheckOwner(atm);
            if (result != null)
                return result;

            return null;
        }

        private async Task<IActionResult> CheckOwner(ATM atm)
        {
            var isBusinessExisted = await _propertyContext.Businesses
                .AnyAsync(b => b.Id == atm.BusinessId);

            if (atm.BusinessId != 0 && !isBusinessExisted)
                return BadRequest($"Бизнес с ID {atm.BusinessId} не найден");

            return null;
        }

        private DAO.ATM MapToDAO(ATM atm)
        {
            return new DAO.ATM
            {
                Id = atm.Id,
                Position = atm.Position
                    ?.Select(p => p)
                    .ToArray(),
                Dimension = atm.Dimension,
                BusinessId = atm.BusinessId
            };
        }

        private ATM MapToModel(DAO.ATM atm)
        {
            return new ATM
            {
                Id = atm.Id,
                Position = atm.Position
                    ?.Select(p => p)
                    .ToArray(),
                Dimension = atm.Dimension,
                BusinessId = atm.BusinessId
            };
        }
    }
}
