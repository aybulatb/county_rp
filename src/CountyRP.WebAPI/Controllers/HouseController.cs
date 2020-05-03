using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CountyRP.Models;
using CountyRP.WebAPI.Extensions;
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
        public IActionResult Create([FromBody]House house)
        {
            var result = CheckParams(house);
            if (result != null)
                return result;

            house.Id = 0;

            Entities.House houseEntity = new Entities.House().Format(house);

            _propertyContext.Houses.Add(houseEntity);
            _propertyContext.SaveChanges();

            house.Id = houseEntity.Id;

            return Created("", house);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(House), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            Entities.House house = _propertyContext.Houses.FirstOrDefault(h => h.Id == id);
            if (house == null)
                return NotFound($"Дом с ID {id} не найден");

            return Ok(new House().Format(house));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(House), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Edit(int id, [FromBody]House house)
        {
            if (id != house.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID дома {house.Id}");

            var result = CheckParams(house);
            if (result != null)
                return result;

            Entities.House houseEntity = _propertyContext.Houses.FirstOrDefault(h => h.Id == id);
            if (houseEntity == null)
                return NotFound($"Дом с ID {id} не найден");

            houseEntity = houseEntity.Format(house);

            _propertyContext.Houses.Update(houseEntity);
            _propertyContext.SaveChanges();

            return Ok(house);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            Entities.House house = _propertyContext.Houses.FirstOrDefault(h => h.Id == id);
            if (house == null)
                return NotFound($"Дом с ID {id} не найден");

            _propertyContext.Houses.Remove(house);
            _propertyContext.SaveChanges();

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
    }
}
