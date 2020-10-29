using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CountyRP.Models;
using CountyRP.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CountyRP.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessController : ControllerBase
    {
        private PlayerContext _playerContext;
        private PropertyContext _propertyContext;

        public BusinessController(PlayerContext playerContext, PropertyContext propertyContext)
        {
            _playerContext = playerContext;
            _propertyContext = propertyContext;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Business), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Business business)
        {
            var result = CheckParams(business);
            if (result != null)
                return result;

            var businessDAO = MapToDAO(business);

            _propertyContext.Businesses.Add(businessDAO);
            await _propertyContext.SaveChangesAsync();

            business.Id = businessDAO.Id;

            return Ok(business);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Business[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var businessesDAO = _propertyContext.Businesses.AsNoTracking().ToArray();

            return Ok(businessesDAO.Select(b => MapToModel(b)));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Business), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var businessDAO = _propertyContext.Businesses.AsNoTracking().FirstOrDefault(b => b.Id == id);
            if (businessDAO == null)
                return NotFound($"Бизнес с ID {id} не найден");

            return Ok(MapToModel(businessDAO));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Business), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, [FromBody] Business business)
        {
            if (id != business.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID бизнеса {business.Id}");

            var businessDAO = _propertyContext.Businesses.AsNoTracking().FirstOrDefault(b => b.Id == id);
            if (businessDAO == null)
                return NotFound($"Бизнес с ID {id} не найден");

            var result = CheckParams(business);
            if (result != null)
                return result;

            businessDAO = MapToDAO(business);

            _propertyContext.Businesses.Update(businessDAO);
            await _propertyContext.SaveChangesAsync();

            return Ok(business);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var businessDAO = _propertyContext.Businesses.FirstOrDefault(b => b.Id == id);
            if (businessDAO == null)
                return NotFound($"Бизнес с ID {id} не найден");

            _propertyContext.Businesses.Remove(businessDAO);
            await _propertyContext.SaveChangesAsync();

            return Ok();
        }

        private IActionResult CheckParams(Business business)
        {
            if (business.Name == null || business.Name.Length < 3 || business.Name.Length > 32)
                return BadRequest("Длина названия должна быть от 3 до 32 символов");

            if (business.EntrancePosition == null || business.EntrancePosition.Length != 3)
                return BadRequest("Количество координат входа должно быть равно 3");

            if (business.ExitPosition == null || business.ExitPosition.Length != 3)
                return BadRequest("Количество координат выхода должно быть равно 3");

            var result = CheckOwner(business);
            if (result != null)
                return result;

            return null;
        }

        private IActionResult CheckOwner(Business business)
        {
            if (business.OwnerId != 0 &&
                _playerContext.Persons.FirstOrDefault(p => p.Id == business.OwnerId) == null)
                return BadRequest($"Персонаж с ID {business.OwnerId} не найден");

            return null;
        }

        private void TrimParams(Business business)
        {
            business.Name = business.Name?.Trim();
        }

        private DAO.Business MapToDAO(Business business)
        {
            return new DAO.Business
            {
                Id = business.Id,
                Name = business.Name,
                EntrancePosition = business.EntrancePosition?.Select(ep => ep).ToArray(),
                EntranceDimension = business.EntranceDimension,
                ExitPosition = business.ExitPosition?.Select(ep => ep).ToArray(),
                ExitDimension = business.ExitDimension,
                OwnerId = business.OwnerId,
                Lock = business.Lock,
                Type = business.Type,
                Price = business.Price
            };
        }

        private Business MapToModel(DAO.Business business)
        {
            return new Business
            {
                Id = business.Id,
                Name = business.Name,
                EntrancePosition = business.EntrancePosition?.Select(ep => ep).ToArray(),
                EntranceDimension = business.EntranceDimension,
                ExitPosition = business.ExitPosition?.Select(ep => ep).ToArray(),
                ExitDimension = business.ExitDimension,
                OwnerId = business.OwnerId,
                Lock = business.Lock,
                Type = business.Type,
                Price = business.Price
            };
        }
    }
}
