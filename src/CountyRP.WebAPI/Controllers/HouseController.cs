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
            var result = await CheckParamsAsync(house);
            if (result != null)
                return result;

            house.Id = 0;

            var houseDAO = MapToDAO(house);

            await _propertyContext.Houses.AddAsync(houseDAO);
            await _propertyContext.SaveChangesAsync();

            house.Id = houseDAO.Id;

            return Created("", house);
        }

        [HttpGet]
        [ProducesResponseType(typeof(House[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var housesDAO = await _propertyContext.Houses
                .AsNoTracking()
                .ToArrayAsync();

            return Ok(
                housesDAO
                .Select(h => MapToModel(h))
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(House), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var houseDAO = await _propertyContext.Houses
                .AsNoTracking()
                .FirstOrDefaultAsync(h => h.Id == id);
            if (houseDAO == null)
                return NotFound($"Дом с ID {id} не найден");

            return Ok(
                MapToModel(houseDAO)
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(House), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, [FromBody] House house)
        {
            if (id != house.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID дома {house.Id}");

            var result = await CheckParamsAsync(house);
            if (result != null)
                return result;

            var isHouseExisted = await _propertyContext.Houses
                .AsNoTracking()
                .AnyAsync(h => h.Id == id);
            if (!isHouseExisted)
                return NotFound($"Дом с ID {id} не найден");

            var houseDAO = MapToDAO(house);

            _propertyContext.Houses.Update(houseDAO);
            await _propertyContext.SaveChangesAsync();

            return Ok(house);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var houseDAO = await _propertyContext.Houses
                .FirstOrDefaultAsync(h => h.Id == id);
            if (houseDAO == null)
                return NotFound($"Дом с ID {id} не найден");

            _propertyContext.Houses.Remove(houseDAO);
            await _propertyContext.SaveChangesAsync();

            return Ok();
        }

        private async Task<IActionResult> CheckParamsAsync(House house)
        {
            if (house.EntrancePosition?.Length != 3)
                return BadRequest("Количество координат входа должно быть равно 3");

            if (house.ExitPosition?.Length != 3)
                return BadRequest("Количество координат выхода должно быть равно 3");

            if (house.SafePosition?.Length != 3)
                return BadRequest("Количество координат сейфа должно быть равно 3");

            var result = await CheckOwner(house);
            if (result != null)
                return result;

            var isGarageExistedWithId = await _propertyContext.Garages
                .AnyAsync(g => g.Id == house.GarageId);

            if (house.GarageId != 0 && !isGarageExistedWithId)
                return BadRequest($"Гараж с ID {house.GarageId} не найден");

            return null;
        }

        private async Task<IActionResult> CheckOwner(House house)
        {
            var isPersonExisted = await _playerContext.Persons
                .AnyAsync(p => p.Id == house.OwnerId);

            if (house.OwnerId != 0 && !isPersonExisted)
                return BadRequest($"Персонаж с ID {house.OwnerId} не найден");

            return null;
        }

        private DAO.House MapToDAO(House house)
        {
            return new DAO.House
            {
                Id = house.Id,
                EntrancePosition = house.EntrancePosition
                    ?.ToArray(),
                EntranceDimension = house.EntranceDimension,
                ExitPosition = house.ExitPosition
                    ?.ToArray(),
                ExitDimension = house.ExitDimension,
                OwnerId = house.OwnerId,
                GarageId = house.GarageId,
                Lock = house.Lock,
                Price = house.Price,
                SafePosition = house.SafePosition
                    ?.ToArray(),
                SafeDimension = house.SafeDimension,
                SafeInventoryId = house.SafeInventoryId
            };
        }

        private House MapToModel(DAO.House house)
        {
            return new House
            {
                Id = house.Id,
                EntrancePosition = house.EntrancePosition
                    ?.ToArray(),
                EntranceDimension = house.EntranceDimension,
                ExitPosition = house.ExitPosition
                    ?.ToArray(),
                ExitDimension = house.ExitDimension,
                OwnerId = house.OwnerId,
                GarageId = house.GarageId,
                Lock = house.Lock,
                Price = house.Price,
                SafePosition = house.SafePosition
                    ?.ToArray(),
                SafeDimension = house.SafeDimension,
                SafeInventoryId = house.SafeInventoryId
            };
        }
    }
}
