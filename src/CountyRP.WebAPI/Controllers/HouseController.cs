using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using CountyRP.Models;
using CountyRP.WebAPI.Models;

namespace CountyRP.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HouseController : ControllerBase
    {
        private PlayerContext _playerContext;
        private PropertyContext _propertyContext;

        public HouseController(PlayerContext playerContext, PropertyContext propertyContext)
        {
            _playerContext = playerContext;
            _propertyContext = propertyContext;
        }

        [HttpPost]
        [ProducesResponseType(typeof(House), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] House house)
        {
            var result = CheckParams(house);
            if (result != null)
                return result;

            house.Id = 0;

            var houseDAO = MapToDAO(house);

            _propertyContext.Houses.Add(houseDAO);
            await _propertyContext.SaveChangesAsync();

            house.Id = houseDAO.Id;

            return Created("", house);
        }

        [HttpGet]
        [ProducesResponseType(typeof(House[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var housesDAO = _propertyContext.Houses.AsNoTracking().ToArray();

            return Ok(housesDAO.Select(h => MapToModel(h)));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(House), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var houseDAO = _propertyContext.Houses.AsNoTracking().FirstOrDefault(h => h.Id == id);
            if (houseDAO == null)
                return NotFound($"Дом с ID {id} не найден");

            return Ok(MapToModel(houseDAO));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(House), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, [FromBody] House house)
        {
            if (id != house.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID дома {house.Id}");

            var result = CheckParams(house);
            if (result != null)
                return result;

            var houseDAO = _propertyContext.Houses.AsNoTracking().FirstOrDefault(h => h.Id == id);
            if (houseDAO == null)
                return NotFound($"Дом с ID {id} не найден");

            houseDAO = MapToDAO(house);

            _propertyContext.Houses.Update(houseDAO);
            await _propertyContext.SaveChangesAsync();

            return Ok(house);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var houseDAO = _propertyContext.Houses.FirstOrDefault(h => h.Id == id);
            if (houseDAO == null)
                return NotFound($"Дом с ID {id} не найден");

            _propertyContext.Houses.Remove(houseDAO);
            await _propertyContext.SaveChangesAsync();

            return Ok();
        }

        private IActionResult CheckParams(House house)
        {
            if (house.EntrancePosition == null || house.EntrancePosition.Length != 3)
                return BadRequest("Количество координат входа должно быть равно 3");

            if (house.ExitPosition == null || house.ExitPosition.Length != 3)
                return BadRequest("Количество координат выхода должно быть равно 3");

            var result = CheckOwner(house);
            if (result != null)
                return result;

            return null;
        }

        private IActionResult CheckOwner(House house)
        {
            if (house.OwnerId != 0 
                && _playerContext.Persons.FirstOrDefault(p => p.Id == house.OwnerId) == null)
                return BadRequest($"Персонаж с ID {house.OwnerId} не найден");

            return null;
        }

        private DAO.House MapToDAO(House house)
        {
            return new DAO.House
            {
                Id = house.Id,
                EntrancePosition = house.EntrancePosition?.Select(ep => ep).ToArray(),
                EntranceDimension = house.EntranceDimension,
                ExitPosition = house.ExitPosition?.Select(ep => ep).ToArray(),
                ExitDimension = house.ExitDimension,
                OwnerId = house.OwnerId,
                Lock = house.Lock,
                Price = house.Price
            };
        }

        private House MapToModel(DAO.House house)
        {
            return new House
            {
                Id = house.Id,
                EntrancePosition = house.EntrancePosition?.Select(ep => ep).ToArray(),
                EntranceDimension = house.EntranceDimension,
                ExitPosition = house.ExitPosition?.Select(ep => ep).ToArray(),
                ExitDimension = house.ExitDimension,
                OwnerId = house.OwnerId,
                Lock = house.Lock,
                Price = house.Price
            };
        }
    }
}
