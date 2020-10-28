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
        public async Task<IActionResult> Create([FromBody] Room room)
        {
            var result = CheckParams(room);
            if (result != null)
                return result;

            var roomDAO = MapToDAO(room);

            _propertyContext.Rooms.Add(roomDAO);
            await _propertyContext.SaveChangesAsync();

            room.Id = roomDAO.Id;

            return Created("", room);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Room[]), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var roomsDAO = _propertyContext.Rooms.AsNoTracking().ToArray();

            return Ok(roomsDAO.Select(r => MapToModel(r)));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Room), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var roomDAO = _propertyContext.Rooms.AsNoTracking().FirstOrDefault(r => r.Id == id);
            if (roomDAO == null)
                return NotFound($"Помещение с ID {id} не найдено");

            return Ok(MapToModel(roomDAO));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Room), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, [FromBody] Room room)
        {
            if (id != room.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID помещения {room.Id}");

            var result = CheckParams(room);
            if (result != null)
                return result;

            var roomDAO = _propertyContext.Rooms.AsNoTracking().FirstOrDefault(r => r.Id == id);
            if (roomDAO == null)
                return NotFound($"Помещение с ID {id} не найдено");

            roomDAO = MapToDAO(room);

            _propertyContext.Rooms.Update(roomDAO);
            await _propertyContext.SaveChangesAsync();

            return Ok(room);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var roomDAO = _propertyContext.Rooms.FirstOrDefault(r => r.Id == id);
            if (roomDAO == null)
                return NotFound($"Помещение с ID {id} не найдено");

            _propertyContext.Rooms.Remove(roomDAO);
            await _propertyContext.SaveChangesAsync();

            return Ok();
        }

        private IActionResult CheckParams(Room room)
        {
            if (room.Name == null || room.Name.Length < 3 || room.Name.Length > 32)
                return BadRequest("Название должно быть от 3 до 32 символов");

            if (room.EntrancePosition == null || room.EntrancePosition.Length != 3)
                return BadRequest("Количество координат входа должно быть равно 3");

            if (room.ExitPosition == null || room.ExitPosition.Length != 3)
                return BadRequest("Количество координат выхода должно быть равно 3");

            if (room.ColorMarker == null || room.ColorMarker.Length != 3)
                return BadRequest("Количество цветов маркера должно быть равно 3");

            if (room.SafePosition == null || room.SafePosition.Length != 3)
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

        private void TrimParams(Room room)
        {
            room.Name = room.Name?.Trim();
        }

        private DAO.Room MapToDAO(Room room)
        {
            return new DAO.Room
            {
                Id = room.Id,
                Name = room.Name,
                EntrancePosition = room.EntrancePosition?.Select(ep => ep).ToArray(),
                EntranceDimension = room.EntranceDimension,
                ExitPosition = room.ExitPosition?.Select(ep => ep).ToArray(),
                ExitDimension = room.ExitDimension,
                TypeMarker = room.TypeMarker,
                ColorMarker = room.ColorMarker?.Select(cm => cm).ToArray(),
                TypeBlip = room.TypeBlip,
                ColorBlip = room.ColorBlip,
                GroupId = room.GroupId,
                Lock = room.Lock,
                Price = room.Price,
                LastPayment = room.LastPayment,
                SafePosition = room.SafePosition?.Select(sf => sf).ToArray(),
                SafeDimension = room.SafeDimension
            };
        }

        private Room MapToModel(DAO.Room room)
        {
            return new Room
            {
                Id = room.Id,
                Name = room.Name,
                EntrancePosition = room.EntrancePosition?.Select(ep => ep).ToArray(),
                EntranceDimension = room.EntranceDimension,
                ExitPosition = room.ExitPosition?.Select(ep => ep).ToArray(),
                ExitDimension = room.ExitDimension,
                TypeMarker = room.TypeMarker,
                ColorMarker = room.ColorMarker?.Select(cm => cm).ToArray(),
                TypeBlip = room.TypeBlip,
                ColorBlip = room.ColorBlip,
                GroupId = room.GroupId,
                Lock = room.Lock,
                Price = room.Price,
                LastPayment = room.LastPayment,
                SafePosition = room.SafePosition?.Select(sf => sf).ToArray(),
                SafeDimension = room.SafeDimension
            };
        }
    }
}
