using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CountyRP.Models;
using CountyRP.WebSite.Exceptions;
using CountyRP.WebSite.Models.ViewModels;
using CountyRP.WebSite.Services.Interfaces;

namespace CountyRP.WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    public class AdminLevelController : ControllerBase
    {
        private IAdminLevelAdapter _adminLevelAdapter;

        public AdminLevelController(IAdminLevelAdapter adminLevelAdapter)
        {
            _adminLevelAdapter = adminLevelAdapter;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AdminLevel adminLevel)
        {
            try
            {
                adminLevel = await _adminLevelAdapter.Create(adminLevel);
            }
            catch (AdapterException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(adminLevel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            AdminLevel adminLevel;

            try
            {
                adminLevel = await _adminLevelAdapter.GetById(id);
            }
            catch (AdapterException ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(adminLevel);
        }

        [HttpGet("FilterBy")]
        public async Task<IActionResult> FilterBy(int page, string id, string name)
        {
            FilteredModels<AdminLevel> adminLevels;

            try
            {
                adminLevels = await _adminLevelAdapter.FilterBy(page, 20, id, name);
            }
            catch (AdapterException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(adminLevels);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, [FromBody]AdminLevel adminLevel)
        {
            try
            {
                adminLevel = await _adminLevelAdapter.Edit(id, adminLevel);
            }
            catch (AdapterException ex) when (ex.StatusCode == StatusCodes.Status400BadRequest)
            {
                return BadRequest(ex.Message);
            }
            catch (AdapterException ex) when (ex.StatusCode == StatusCodes.Status404NotFound)
            {
                return NotFound(ex.Message);
            }

            return Ok(adminLevel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _adminLevelAdapter.Delete(id);
            }
            catch (AdapterException ex)
            {
                return NotFound(ex.Message);
            }

            return Ok();
        }
    }
}
