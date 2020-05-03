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
        public IActionResult Create([FromBody]Teleport teleport)
        {
            var result = CheckParams(teleport);
            if (result != null)
                return result;

            Entities.Teleport teleportEntity = new Entities.Teleport().Format(teleport);

            _propertyContext.Teleports.Add(teleportEntity);
            _propertyContext.SaveChanges();

            teleport.Id = teleportEntity.Id;

            return Ok(teleport);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Teleport), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            Entities.Teleport teleport = _propertyContext.Teleports.FirstOrDefault(t => t.Id == id);
            if (teleport == null)
                return NotFound($"Телепорт с ID {id} не найден");

            return Ok(new Teleport().Format(teleport));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Teleport), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Edit(int id, [FromBody]Teleport teleport)
        {
            if (id != teleport.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID телепорта {teleport.Id}");

            var result = CheckParams(teleport);
            if (result != null)
                return result;

            Entities.Teleport teleportEntity = _propertyContext.Teleports.FirstOrDefault(t => t.Id == id);
            if (teleportEntity == null)
                return NotFound($"Телепорт с ID {id} не найден");

            teleportEntity = teleportEntity.Format(teleport);

            _propertyContext.Teleports.Update(teleportEntity);
            _propertyContext.SaveChanges();

            return Ok(teleport);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            Entities.Teleport teleport = _propertyContext.Teleports.FirstOrDefault(t => t.Id == id);
            if (teleport == null)
                return NotFound($"Телепорт с ID {id} не найден");

            _propertyContext.Teleports.Remove(teleport);
            _propertyContext.SaveChanges();

            return Ok();
        }

        private IActionResult CheckParams(Teleport teleport)
        {
            TrimParams(teleport);

            if (teleport.Name == null || teleport.Name.Length < 3 || teleport.Name.Length > 32)
                return BadRequest("Название должно быть от 3 до 32 символов");

            if (teleport.EntrancePosition == null || teleport.EntrancePosition.Length != 3)
                return BadRequest("Количество координат входа должно быть равно 3");

            if (teleport.ExitPosition == null || teleport.ExitPosition.Length != 3)
                return BadRequest("Количество координат выхода должно быть равно 3");

            if (teleport.ColorMarker == null || teleport.ColorMarker.Length != 3)
                return BadRequest("Количество цветов должно быть равно 3");

            var result = CheckOwner(teleport);
            if (result != null)
                return result;

            return null;
        }

        private IActionResult CheckOwner(Teleport teleport)
        {
            if (teleport.FactionId == null ||
                teleport.FactionId != string.Empty &&
                _factionContext.Factions.FirstOrDefault(f => f.Id == teleport.FactionId) == null)
                return BadRequest($"Фракция с ID {teleport.FactionId} не найдена");

            if (teleport.GangId != 0 && 
                _gangContext.Gangs.FirstOrDefault(g => g.Id == teleport.GangId) == null)
                return BadRequest($"Группировка с ID {teleport.GangId} не найдена");

            return null;
        }

        private void TrimParams(Teleport teleport)
        {
            teleport.Name = teleport.Name?.Trim();
        }
    }
}
