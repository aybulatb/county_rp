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
            var result = await CheckParamsAsync(lockerRoom);
            if (result != null)
                return result;

            var lockerRoomDAO = MapToDAO(lockerRoom);

            await _factionContext.LockerRooms.AddAsync(lockerRoomDAO);
            await _factionContext.SaveChangesAsync();

            lockerRoom.Id = lockerRoomDAO.Id;

            return Created("", lockerRoom);
        }

        [HttpGet]
        [ProducesResponseType(typeof(LockerRoom[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var lockerRoomsDAO = await _factionContext.LockerRooms
                .AsNoTracking()
                .ToArrayAsync();

            return Ok(
                lockerRoomsDAO
                    .Select(lr => MapToModel(lr))
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LockerRoom), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var lockerRoomDAO = await _factionContext.LockerRooms
                .AsNoTracking()
                .FirstOrDefaultAsync(lr => lr.Id == id);
            if (lockerRoomDAO == null)
                return NotFound($"Раздевалка с ID {id} не найдена");

            return Ok(
                MapToModel(lockerRoomDAO)
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(LockerRoom), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, [FromBody] LockerRoom lockerRoom)
        {
            if (id != lockerRoom.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID раздевалки {lockerRoom.Id}");

            var result = await CheckParamsAsync(lockerRoom);
            if (result != null)
                return result;

            var isLockerRoomExisted = await _factionContext.LockerRooms
                .AsNoTracking()
                .AnyAsync(lr => lr.Id == id);
            if (!isLockerRoomExisted)
                return NotFound($"Раздевалка с ID {id} не найдена");

            var lockerRoomDAO = MapToDAO(lockerRoom);

            _factionContext.LockerRooms.Update(lockerRoomDAO);
            await _factionContext.SaveChangesAsync();

            return Ok(lockerRoom);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var lockerRoomDAO = await _factionContext.LockerRooms
                .FirstOrDefaultAsync(lr => lr.Id == id);
            if (lockerRoomDAO == null)
                return NotFound($"Раздевалка с ID {id} не найдена");

            _factionContext.LockerRooms.Remove(lockerRoomDAO);
            await _factionContext.SaveChangesAsync();

            return Ok();
        }

        private async Task<IActionResult> CheckParamsAsync(LockerRoom lockerRoom)
        {
            if (lockerRoom.Position == null || lockerRoom.Position.Length != 3)
                return BadRequest("Количество координат должно быть равно 3");

            if (lockerRoom.ColorMarker == null || lockerRoom.ColorMarker.Length != 3)
                return BadRequest("Количество цветов маркера должно быть равно 3");

            var result = await CheckOwner(lockerRoom);
            if (result != null)
                return result;

            return null;
        }

        private async Task<IActionResult> CheckOwner(LockerRoom lockerRoom)
        {
            var isFactionExisted = await _factionContext.LockerRooms
                .AnyAsync(lr => lr.FactionId == lockerRoom.FactionId);

            if (lockerRoom.FactionId == null || lockerRoom.FactionId != string.Empty && !isFactionExisted)
                return BadRequest($"Фракция с ID {lockerRoom.FactionId} не найдена");

            return null;
        }

        private DAO.LockerRoom MapToDAO(LockerRoom lockerRoom)
        {
            return new DAO.LockerRoom
            {
                Id = lockerRoom.Id,
                Position = lockerRoom.Position
                    ?.Select(p => p)
                    .ToArray(),
                Dimension = lockerRoom.Dimension,
                TypeMarker = lockerRoom.TypeMarker,
                ColorMarker = lockerRoom.ColorMarker
                    ?.Select(cm => cm)
                    .ToArray(),
                FactionId = lockerRoom.FactionId
            };
        }

        private LockerRoom MapToModel(DAO.LockerRoom lockerRoom)
        {
            return new LockerRoom
            {
                Id = lockerRoom.Id,
                Position = lockerRoom.Position
                    ?.Select(p => p)
                    .ToArray(),
                Dimension = lockerRoom.Dimension,
                TypeMarker = lockerRoom.TypeMarker,
                ColorMarker = lockerRoom.ColorMarker
                    ?.Select(cm => cm)
                    .ToArray(),
                FactionId = lockerRoom.FactionId
            };
        }
    }
}
