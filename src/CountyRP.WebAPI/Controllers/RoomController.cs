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
    public class RoomController : ControllerBase
    {
        private PropertyContext _propertyContext;
        private GangContext _gangContext;

        public RoomController(PropertyContext propertyContext, GangContext gangContext)
        {
            _propertyContext = propertyContext;
            _gangContext = gangContext;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Room), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody]Room room)
        {
            var result = CheckParams(room);
            if (result != null)
                return result;

            Entities.Room roomEntity = new Entities.Room().Format(room);

            _propertyContext.Rooms.Add(roomEntity);
            _propertyContext.SaveChanges();

            room.Id = roomEntity.Id;

            return Created("", room);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Room), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            Entities.Room room = _propertyContext.Rooms.FirstOrDefault(r => r.Id == id);
            if (room == null)
                return NotFound($"Помещение с ID {id} не найдено");

            return Ok(new Room().Format(room));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Room), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Edit(int id, [FromBody]Room room)
        {
            if (id != room.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID помещения {room.Id}");

            var result = CheckParams(room);
            if (result != null)
                return result;

            Entities.Room roomEntity = _propertyContext.Rooms.FirstOrDefault(r => r.Id == id);
            if (roomEntity == null)
                return NotFound($"Помещение с ID {id} не найдено");

            roomEntity = roomEntity.Format(room);

            _propertyContext.Rooms.Update(roomEntity);
            _propertyContext.SaveChanges();

            return Ok(room);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            Entities.Room room = _propertyContext.Rooms.FirstOrDefault(r => r.Id == id);
            if (room == null)
                return NotFound($"Помещение с ID {id} не найдено");

            _propertyContext.Rooms.Remove(room);
            _propertyContext.SaveChanges();

            return Ok();
        }

        private IActionResult CheckParams(Room room)
        {
            if (room.Name.Length < 3 || room.Name.Length > 32)
                return BadRequest("Название должно быть от 3 до 32 символов");

            if (room.EntrancePosition.Length != 3)
                return BadRequest("Количество координат входа должно быть равно 3");

            if (room.ExitPosition.Length != 3)
                return BadRequest("Количество координат выхода должно быть равно 3");

            if (room.ColorMarker.Length != 3)
                return BadRequest("Количество цветов маркера должно быть равно 3");

            if (room.SafePosition.Length != 3)
                return BadRequest("Количество координат сейфа должно быть равно 3");

            var result = CheckOwner(room);
            if (result != null)
                return result;

            return null;
        }

        private IActionResult CheckOwner(Room room)
        {
            if (room.GroupId != 0
                && _gangContext.Gangs.FirstOrDefault(g => g.Id == room.GroupId) == null)
                return BadRequest($"Группировка с ID {room.GroupId} не найдена");

            return null;
        }
    }
}
