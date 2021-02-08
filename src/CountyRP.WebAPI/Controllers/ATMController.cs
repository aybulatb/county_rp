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
            var result = CheckParams(atm);
            if (result != null)
                return result;

            var atmDAO = MapToDAO(atm);

            _propertyContext.ATMs.Add(atmDAO);
            await _propertyContext.SaveChangesAsync();

            atm.Id = atmDAO.Id;

            return Created("", atm);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ATM[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var ATMsDAO = _propertyContext.ATMs.AsNoTracking().ToArray();

            return Ok(ATMsDAO.Select(a => MapToModel(a)));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ATM), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var atmDAO = _propertyContext.ATMs.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (atmDAO == null)
                return NotFound($"Банкомат с ID {id} не найдена");

            return Ok(MapToModel(atmDAO));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ATM), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, [FromBody] ATM atm)
        {
            if (id != atm.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID банкомата {atm.Id}");

            var result = CheckParams(atm);
            if (result != null)
                return result;

            var atmDAO = _propertyContext.ATMs.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (atmDAO == null)
                return NotFound($"Банкомат с ID {id} не найден");

            atmDAO = MapToDAO(atm);

            _propertyContext.ATMs.Update(atmDAO);
            await _propertyContext.SaveChangesAsync();

            return Ok(atm);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var atmDAO = _propertyContext.ATMs.FirstOrDefault(a => a.Id == id);
            if (atmDAO == null)
                return NotFound($"Банкомат с ID {id} не найдена");

            _propertyContext.ATMs.Remove(atmDAO);
            await _propertyContext.SaveChangesAsync();

            return Ok();
        }

        private IActionResult CheckParams(ATM atm)
        {
            if (atm.Position == null || atm.Position.Length != 3)
                return BadRequest("Количество координат должно быть равно 3");

            var result = CheckOwner(atm);
            if (result != null)
                return result;

            return null;
        }

        private IActionResult CheckOwner(ATM atm)
        {
            if (atm.BusinessId != 0 &&
                _propertyContext.Businesses.FirstOrDefault(b => b.Id == atm.BusinessId) == null)
                return BadRequest($"Бизнес с ID {atm.BusinessId} не найден");

            return null;
        }

        private DAO.ATM MapToDAO(ATM atm)
        {
            return new DAO.ATM
            {
                Id = atm.Id,
                Position = atm.Position?.Select(p => p).ToArray(),
                Dimension = atm.Dimension,
                BusinessId = atm.BusinessId
            };
        }

        private ATM MapToModel(DAO.ATM atm)
        {
            return new ATM
            {
                Id = atm.Id,
                Position = atm.Position?.Select(p => p).ToArray(),
                Dimension = atm.Dimension,
                BusinessId = atm.BusinessId
            };
        }
    }
}
