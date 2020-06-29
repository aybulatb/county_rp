using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using CountyRP.Models;
using CountyRP.WebSite.Exceptions;
using CountyRP.WebSite.Services.Interfaces;
using CountyRP.WebSite.Models.ViewModels;

namespace CountyRP.WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    public class FactionController : ControllerBase
    {
        private IFactionAdapter _factionAdapter;

        public FactionController(IFactionAdapter factionAdapter)
        {
            _factionAdapter = factionAdapter;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Faction faction)
        {
            try
            {
                faction = await _factionAdapter.Create(faction);
            }
            catch (AdapterException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(faction);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            Faction faction;

            try
            {
                faction = await _factionAdapter.GetById(id);
            }
            catch (AdapterException ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(faction);
        }

        [HttpGet("FilterBy")]
        public async Task<IActionResult> FilterBy(int page, string id, string name)
        {
            FilteredModels<Faction> factions;

            try
            {
                factions = await _factionAdapter.FilterBy(page, 20, id, name);
            }
            catch (AdapterException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(factions);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, [FromBody]Faction faction)
        {
            try
            {
                faction = await _factionAdapter.Edit(id, faction);
            }
            catch (AdapterException ex) when (ex.StatusCode == StatusCodes.Status400BadRequest)
            {
                return BadRequest(ex.Message);
            }
            catch (AdapterException ex) when (ex.StatusCode == StatusCodes.Status404NotFound)
            {
                return NotFound(ex.Message);
            }

            return Ok(faction);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _factionAdapter.Delete(id);
            }
            catch (AdapterException ex)
            {
                return NotFound(ex.Message);
            }

            return Ok();
        }
    }
}
