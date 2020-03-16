using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CountyRP.WebSite.Exceptions;
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
            Player player;

            try
            {
                player = await _playerAuthorizationClient.TryAuthorize(login, password);
            }
            catch (AdapterException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(player);
        }
    }
}
