using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CountyRP.WebSite.Services.Interfaces;
using CountyRP.Extra;

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
        [Route("TryAuthorize")]
        public async Task<IActionResult> TryAuthorize(string login, string password)
        {
            Player player = await _playerAuthorizationClient.TryAuthorize(login, password);

            if (player == null)
            {
                return BadRequest("Данный игрок не найден");
            }

            return Content($"{player.Id} {player.Login} {player.Password}");
        }
    }
}
