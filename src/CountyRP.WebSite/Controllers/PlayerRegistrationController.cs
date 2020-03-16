using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CountyRP.WebSite.Services.Interfaces;

namespace CountyRP.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerRegistrationController : ControllerBase
    {
        private IPlayerRegistrationAdapter _playerRegistrationAdapter;

        public PlayerRegistrationController(IPlayerRegistrationAdapter playerRegistrationAdapter)
        {
            _playerRegistrationAdapter = playerRegistrationAdapter;
        }

        [HttpPost]
        public async Task<IActionResult> Register(string login, string password)
        {
            await _playerRegistrationAdapter.Register(login, password);

            return Ok();
        }
    }
}
