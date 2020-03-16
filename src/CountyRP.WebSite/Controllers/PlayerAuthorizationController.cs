using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CountyRP.WebSite.Services.Interfaces;

namespace CountyRP.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerAuthorizationController : ControllerBase
    {
        private IPlayerAuthorizationAdapter _playerAuthorizationClient;

        public PlayerAuthorizationController(IPlayerAuthorizationAdapter playerAuthorizationClient)
        {
            _playerAuthorizationClient = playerAuthorizationClient;
        }

        [HttpGet]
        [Route("tryauthorize")]
        public async Task<IActionResult> TryAuthorize(string login, string password)
        {
            var x = await _playerAuthorizationClient.TryAuthorize(login, password);

            return Content($"{x.Id} {x.Login} {x.Password}");
        }
    }
}
