using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using CountyRP.WebAPI.Models;
using CountyRP.WebAPI.Models.ViewModels.FactionViewModels;

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
        [Route("Create")]
        [ProducesResponseType(typeof(Faction), StatusCodes.Status201Created)]
        public IActionResult Create(CreateFaction createFaction)
        {
            Entities.Faction faction = new Entities.Faction
            {
                Id = createFaction.Id,
                Name = createFaction.Name,
                Ranks = createFaction.Ranks
            };

            _factionContext.Factions.Add(faction);
            _factionContext.SaveChanges();

            return Created("", faction);
        }

        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(Faction), StatusCodes.Status200OK)]
        public IActionResult GetById(string id)
        {
            Entities.Faction faction = _factionContext.Factions.FirstOrDefault(f => f.Id == id);

            if (faction == null)
                return NotFound();

            return Ok(new Faction
            {
                Id = faction.Id,
                Name = faction.Name,
                Ranks = faction.Ranks
            });
        }
    }
}
