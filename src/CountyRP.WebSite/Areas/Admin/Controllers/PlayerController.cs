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
    public class PlayerController : ControllerBase
    {
        private IPlayerAdapter _playerAdapter;

        public PlayerController(IPlayerAdapter playerAdapter)
        {
            _playerAdapter = playerAdapter;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Player player)
        {
            try
            {
                player = await _playerAdapter.Register(player);
            }
            catch (AdapterException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(player);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Player player;

            try
            {
                player = await _playerAdapter.GetById(id);
            }
            catch (AdapterException ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(player);
        }

        [HttpGet("FilterBy")]
        public async Task<IActionResult> FilterBy(int page, string name)
        {
            FilteredModels<Player> players;

            try
            {
                players = await _playerAdapter.FilterBy(page, 20, name);
            }
            catch (AdapterException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(players);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody]Player player)
        {
            try
            {
                player = await _playerAdapter.Edit(id, player);
            }
            catch (AdapterException ex) when (ex.StatusCode == StatusCodes.Status400BadRequest)
            {
                return BadRequest(ex.Message);
            }
            catch (AdapterException ex) when (ex.StatusCode == StatusCodes.Status404NotFound)
            {
                return NotFound(ex.Message);
            }

            return Ok(player);
        }
    }
}
