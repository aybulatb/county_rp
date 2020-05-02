using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using CountyRP.Models;
using CountyRP.WebAPI.Models;
using CountyRP.WebAPI.Extensions;

namespace CountyRP.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FactionController : ControllerBase
    {
        private FactionContext _factionContext;

        public FactionController(FactionContext factionContext)
        {
            _factionContext = factionContext;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Faction), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Create(Faction createFaction)
        {
            var result = CheckParams(createFaction);
            if (result != null)
                return result;
            
            if (_factionContext.Factions
                .FirstOrDefault(f => f.Id == createFaction.Id) != null)
            {
                return BadRequest($"Фракции с ID {createFaction.Id} уже существует");
            }

            Entities.Faction faction = new Entities.Faction().Format(createFaction);

            _factionContext.Factions.Add(faction);
            _factionContext.SaveChanges();

            return Created("", createFaction);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Faction), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetById(string id)
        {
            Entities.Faction faction = _factionContext.Factions.FirstOrDefault(f => f.Id == id);

            if (faction == null)
                return NotFound($"Фракции с ID {id} не найдена");

            return Ok(new Faction().Format(faction));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Faction>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            List<Faction> factions = _factionContext.Factions
                .Select(f => new Faction().Format(f))
                .ToList();

            return Ok(factions);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Faction), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Edit(string id, Faction faction)
        {
            if (id != faction.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID {faction.Id} фракции");

            if (_factionContext.Factions.AsNoTracking()
                .FirstOrDefault(f => f.Id == faction.Id) == null)
            {
                return NotFound($"Фракции с ID {faction.Id} не найдена");
            }

            var result = CheckParams(faction);
            if (result != null)
                return result;

            _factionContext.Factions.Update(new Entities.Faction().Format(faction));
            _factionContext.SaveChanges();

            return Ok(faction);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Delete(string id)
        {
            Entities.Faction faction = _factionContext.Factions
                .FirstOrDefault(f => f.Id == id);

            if (faction == null)
                return NotFound($"Фракция с ID {id} не найдена");

            _factionContext.Factions.Remove(faction);
            _factionContext.SaveChanges();

            return Ok();
        }

        private IActionResult CheckParams(Faction faction)
        {
            TrimParams(faction);

            if (faction.Id.Length < 3 || faction.Id.Length > 16)
                return BadRequest("ID должен быть от 3 до 16 символов");

            if (faction.Name.Length < 3 || faction.Name.Length > 32)
                return BadRequest("Название должно быть от 3 до 32 символов");

            foreach (string rank in faction.Ranks)
            {
                if (rank.Length < 1 || rank.Length > 32)
                    return BadRequest("Название ранга должно быть от 1 до 32 символов");
            }

            if (faction.Type < FactionType.None)
                return BadRequest("Тип фракции должно быть от 0 до 1");

            return null;
        }

        private void TrimParams(Faction faction)
        {
            faction.Id = faction.Id.Trim();
            faction.Name = faction.Name.Trim();
            for (int i = 0; i < faction.Ranks.Length; i++)
                faction.Ranks[i] = faction.Ranks[i].Trim();
        }
    }
}
