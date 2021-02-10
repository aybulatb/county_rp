using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using CountyRP.Models;
using CountyRP.WebAPI.DbContexts;
using CountyRP.WebAPI.Models.ViewModels;

namespace CountyRP.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeleportController : ControllerBase
    {
        private PropertyContext _propertyContext;
        private FactionContext _factionContext;
        private GangContext _gangContext;

        public TeleportController(PropertyContext propertyContext, FactionContext factionContext, GangContext gangContext)
        {
            _propertyContext = propertyContext;
            _factionContext = factionContext;
            _gangContext = gangContext;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Teleport), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Teleport teleport)
        {
            var result = await CheckParamsAsync(teleport);
            if (result != null)
                return result;

            var teleportDAO = MapToDAO(teleport);

            await _propertyContext.Teleports.AddAsync(teleportDAO);
            await _propertyContext.SaveChangesAsync();

            teleport.Id = teleportDAO.Id;

            return Ok(teleport);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Teleport[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var teleportsDAO = await _propertyContext.Teleports
                .AsNoTracking()
                .ToArrayAsync();

            return Ok(
                teleportsDAO.Select(t => MapToModel(t))
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Teleport), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var teleportDAO = await _propertyContext.Teleports
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);
            if (teleportDAO == null)
                return NotFound($"Телепорт с ID {id} не найден");

            return Ok(
                MapToModel(teleportDAO)
            );
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(FilteredModels<Teleport>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterBy(int page, int count)
        {
            if (page < 1)
                return BadRequest("Номер страницы телепортов не может быть меньше 1");

            if (count < 1 || count > 50)
                return BadRequest("Количество телепортов на одной странице должно быть от 1 до 50");

            IQueryable<DAO.Teleport> query = _propertyContext.Teleports;

            int allAmount = await _propertyContext.Teleports.CountAsync();
            int maxPage = (allAmount % count == 0) ? allAmount / count : allAmount / count + 1;
            if (page > maxPage && maxPage > 0)
                page = maxPage;

            var choosenTeleports = await query
                    .Skip((page - 1) * count)
                    .Take(count)
                    .ToListAsync();

            return Ok(new FilteredModels<Teleport>
            {
                Items = choosenTeleports
                    .Select(t => MapToModel(t))
                    .ToList(),
                AllAmount = allAmount,
                Page = page,
                MaxPage = maxPage
            });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Teleport), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, [FromBody] Teleport teleport)
        {
            if (id != teleport.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID телепорта {teleport.Id}");

            var result = await CheckParamsAsync(teleport);
            if (result != null)
                return result;

            var isTeleportExisted = await _propertyContext.Teleports
                .AsNoTracking()
                .AnyAsync(t => t.Id == id);
            if (!isTeleportExisted)
                return NotFound($"Телепорт с ID {id} не найден");

            var teleportDAO = MapToDAO(teleport);

            _propertyContext.Teleports.Update(teleportDAO);
            await _propertyContext.SaveChangesAsync();

            return Ok(teleport);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var teleportDAO = await _propertyContext.Teleports
                .FirstOrDefaultAsync(t => t.Id == id);
            if (teleportDAO == null)
                return NotFound($"Телепорт с ID {id} не найден");

            _propertyContext.Teleports.Remove(teleportDAO);
            await _propertyContext.SaveChangesAsync();

            return Ok();
        }

        private async Task<IActionResult> CheckParamsAsync(Teleport teleport)
        {
            TrimParams(teleport);

            if (teleport.Name == null || teleport.Name.Length > 32)
                return BadRequest("Название должно быть до 32 символов");

            if (teleport.EntrancePosition == null || teleport.EntrancePosition.Length != 3)
                return BadRequest("Количество координат входа должно быть равно 3");

            if (teleport.ExitPosition == null || teleport.ExitPosition.Length != 3)
                return BadRequest("Количество координат выхода должно быть равно 3");

            if (teleport.ColorMarker == null || teleport.ColorMarker.Length != 3)
                return BadRequest("Количество цветов должно быть равно 3");

            var result = await CheckOwnerAsync(teleport);
            if (result != null)
                return result;

            return null;
        }

        private async Task<IActionResult> CheckOwnerAsync(Teleport teleport)
        {
            var isFactionExisted = await _factionContext.Factions
                .AnyAsync(f => f.Id == teleport.FactionId);

            if (teleport.FactionId == null || teleport.FactionId != string.Empty && !isFactionExisted)
                return BadRequest($"Фракция с ID {teleport.FactionId} не найдена");

            var isGangExisted = await _gangContext.Gangs
                .AnyAsync(g => g.Id == teleport.GangId);

            if (teleport.GangId != 0 && !isGangExisted)
                return BadRequest($"Группировка с ID {teleport.GangId} не найдена");

            var isBusinessExisted = await _propertyContext.Businesses
                .AnyAsync(b => b.Id == teleport.BusinessId);

            if (teleport.BusinessId != 0 && !isBusinessExisted)
                return BadRequest($"Бизнес с ID {teleport.BusinessId} не найден");

            return null;
        }

        private void TrimParams(Teleport teleport)
        {
            teleport.Name = teleport.Name?.Trim();
        }

        private DAO.Teleport MapToDAO(Teleport teleport)
        {
            return new DAO.Teleport
            {
                Id = teleport.Id,
                Name = teleport.Name,
                EntrancePosition = teleport.EntrancePosition
                    ?.Select(ep => ep)
                    .ToArray(),
                EntranceDimension = teleport.EntranceDimension,
                ExitPosition = teleport.ExitPosition
                    ?.Select(ep => ep)
                    .ToArray(),
                ExitDimension = teleport.ExitDimension,
                TypeMarker = teleport.TypeMarker,
                ColorMarker = teleport.ColorMarker
                    ?.Select(cm => cm)
                    .ToArray(),
                TypeBlip = teleport.TypeBlip,
                ColorBlip = teleport.ColorBlip,
                FactionId = teleport.FactionId,
                GangId = teleport.GangId,
                RoomId = teleport.RoomId,
                BusinessId = teleport.BusinessId,
                Lock = teleport.Lock
            };
        }

        private Teleport MapToModel(DAO.Teleport teleport)
        {
            return new Teleport
            {
                Id = teleport.Id,
                Name = teleport.Name,
                EntrancePosition = teleport.EntrancePosition
                    ?.Select(ep => ep)
                    .ToArray(),
                EntranceDimension = teleport.EntranceDimension,
                ExitPosition = teleport.ExitPosition
                    ?.Select(ep => ep)
                    .ToArray(),
                ExitDimension = teleport.ExitDimension,
                TypeMarker = teleport.TypeMarker,
                ColorMarker = teleport.ColorMarker
                    ?.Select(cm => cm)
                    .ToArray(),
                TypeBlip = teleport.TypeBlip,
                ColorBlip = teleport.ColorBlip,
                FactionId = teleport.FactionId,
                GangId = teleport.GangId,
                RoomId = teleport.RoomId,
                BusinessId = teleport.BusinessId,
                Lock = teleport.Lock
            };
        }
    }
}
