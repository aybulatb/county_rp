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
        public async Task<IActionResult> Create([FromBody] LockerRoom lockerRoom)
        {
            var result = CheckParams(lockerRoom);
            if (result != null)
                return result;

            var lockerRoomDAO = MapToDAO(lockerRoom);

            _factionContext.LockerRooms.Add(lockerRoomDAO);
            await _factionContext.SaveChangesAsync();

            lockerRoom.Id = lockerRoomDAO.Id;

            return Created("", lockerRoom);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LockerRoom), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var lockerRoomDAO = _factionContext.LockerRooms.AsNoTracking().FirstOrDefault(lr => lr.Id == id);
            if (lockerRoomDAO == null)
                return NotFound($"Раздевалка с ID {id} не найдена");

            return Ok(MapToModel(lockerRoomDAO));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(LockerRoom), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, [FromBody] LockerRoom lockerRoom)
        {
            if (id != lockerRoom.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID раздевалки {lockerRoom.Id}");

            var result = CheckParams(lockerRoom);
            if (result != null)
                return result;

            var lockerRoomDAO = _factionContext.LockerRooms.AsNoTracking().FirstOrDefault(lr => lr.Id == id);
            if (lockerRoomDAO == null)
                return NotFound($"Раздевалка с ID {id} не найдена");

            lockerRoomDAO = MapToDAO(lockerRoom);

            _factionContext.LockerRooms.Update(lockerRoomDAO);
            await _factionContext.SaveChangesAsync();

            return Ok(lockerRoom);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var lockerRoomDAO = _factionContext.LockerRooms.FirstOrDefault(lr => lr.Id == id);
            if (lockerRoomDAO == null)
                return NotFound($"Раздевалка с ID {id} не найдена");

            _factionContext.LockerRooms.Remove(lockerRoomDAO);
            await _factionContext.SaveChangesAsync();

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

        private DAO.LockerRoom MapToDAO(LockerRoom lockerRoom)
        {
            return new DAO.LockerRoom
            {
                Id = lockerRoom.Id,
                Position = lockerRoom.Position?.Select(p => p).ToArray(),
                Dimension = lockerRoom.Dimension,
                TypeMarker = lockerRoom.TypeMarker,
                ColorMarker = lockerRoom.ColorMarker?.Select(cm => cm).ToArray(),
                FactionId = lockerRoom.FactionId
            };
        }

        private LockerRoom MapToModel(DAO.LockerRoom lockerRoom)
        {
            return new LockerRoom
            {
                Id = lockerRoom.Id,
                Position = lockerRoom.Position?.Select(p => p).ToArray(),
                Dimension = lockerRoom.Dimension,
                TypeMarker = lockerRoom.TypeMarker,
                ColorMarker = lockerRoom.ColorMarker?.Select(cm => cm).ToArray(),
                FactionId = lockerRoom.FactionId
            };
        }
    }
}
