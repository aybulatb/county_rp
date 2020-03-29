using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CountyRP.WebSite.Services.Interfaces;
using CountyRP.WebSite.Exceptions;
using CountyRP.WebSite.Extenstions;
using CountyRP.Extra;

namespace CountyRP.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerProfileController : ControllerBase
    {
        private IPlayerAdapter _playerAdapter;

        public PlayerProfileController(IPlayerAdapter playerAdapter)
        {
            _playerAdapter = playerAdapter;
        }

        [HttpGet]
        [Route("MiniInfo")]
        public async Task<IActionResult> GetMiniInfo()
        {
            int id = User.Claims.GetId();

            if (id == 0)
                return BadRequest();

            Player player;

            try
            {
                player = await _playerAdapter.GetById(id);
            }
            catch (AdapterException)
            {
                return NotFound();
            }

            return Ok(new
            {
                Login = player.Login
            });
        }
    }
}
