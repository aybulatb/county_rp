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
    public class LockerRoomController : ControllerBase
    {
        private FactionContext _factionContext;

        public LockerRoomController(FactionContext factionContext)
        {
            _factionContext = factionContext;
        }

        [HttpPost]
        [ProducesResponseType(typeof(LockerRoom), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody]LockerRoom lockerRoom)
        {
            var result = CheckParams(lockerRoom);
            if (result != null)
                return result;

            Entities.LockerRoom lockerRoomEntity = new Entities.LockerRoom().Format(lockerRoom);

            _factionContext.LockerRooms.Add(lockerRoomEntity);
            _factionContext.SaveChanges();

            lockerRoom.Id = lockerRoomEntity.Id;

            return Created("", lockerRoom);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LockerRoom), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            Entities.LockerRoom lockerRoom = _factionContext.LockerRooms.FirstOrDefault(lr => lr.Id == id);
            if (lockerRoom == null)
                return NotFound($"Раздевалка с ID {id} не найдена");

            return Ok(new LockerRoom().Format(lockerRoom));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(LockerRoom), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Edit(int id, [FromBody]LockerRoom lockerRoom)
        {
            if (id != lockerRoom.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID раздевалки {lockerRoom.Id}");

            var result = CheckParams(lockerRoom);
            if (result != null)
                return result;

            Entities.LockerRoom lockerRoomEntity = _factionContext.LockerRooms.FirstOrDefault(lr => lr.Id == id);
            if (lockerRoomEntity == null)
                return NotFound($"Раздевалка с ID {id} не найдена");

            lockerRoomEntity = lockerRoomEntity.Format(lockerRoom);

            _factionContext.LockerRooms.Update(lockerRoomEntity);
            _factionContext.SaveChanges();

            return Ok(lockerRoom);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            Entities.LockerRoom lockerRoom = _factionContext.LockerRooms.FirstOrDefault(lr => lr.Id == id);
            if (lockerRoom == null)
                return NotFound($"Раздевалка с ID {id} не найдена");

            _factionContext.LockerRooms.Remove(lockerRoom);
            _factionContext.SaveChanges();

            return Ok();
        }

        private IActionResult CheckParams(LockerRoom lockerRoom)
        {
            if (lockerRoom.Position == null || lockerRoom.Position.Length != 3)
                return BadRequest("Количество координат должно быть равно 3");

            if (lockerRoom.ColorMarker == null || lockerRoom.ColorMarker.Length != 3)
                return BadRequest("Количество цветов маркера должно быть равно 3");

            var result = CheckOwner(lockerRoom);
            if (result != null)
                return result;

            return null;
        }

        private IActionResult CheckOwner(LockerRoom lockerRoom)
        {
            if (lockerRoom.FactionId == null ||
                lockerRoom.FactionId != string.Empty &&
                _factionContext.LockerRooms.FirstOrDefault(lr => lr.FactionId == lockerRoom.FactionId) == null)
                return BadRequest($"Фракция с ID {lockerRoom.FactionId} не найдена");

            return null;
        }
    }
}
