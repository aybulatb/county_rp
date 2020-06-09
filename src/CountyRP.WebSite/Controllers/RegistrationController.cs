using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CountyRP.Models;
using CountyRP.WebSite.Services.Interfaces;

namespace CountyRP.WebSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private IPlayerAdapter _playerAdapter;

        public RegistrationController(IPlayerAdapter playerAdapter)
        {
            _playerAdapter = playerAdapter;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]Player player)
        {
            player = await _playerAdapter.Register(player);

            return Ok(player);
        }
    }
}
