using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CountyRP.Extra;

namespace CountyRP.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerAuthorizationController : ControllerBase
    {
        private PlayerAuthorizationClient _playerAuthorizationClient;

        public PlayerAuthorizationController(PlayerAuthorizationClient playerAuthorizationClient)
        {
            _playerAuthorizationClient = playerAuthorizationClient;
        }

        [HttpGet]
        [Route("tryauthorize")]
        public async Task<IActionResult> TryAuthorize(string login, string password)
        {
            try
            {
                var x = await _playerAuthorizationClient.TryAuthorizeAsync(login, password);

                return Content($"{x.Id} {x.Login} {x.Password}");
            }
            catch (ApiException ex)
            {
                return Content($"{ex.StatusCode}");
            }
        }
    }
}
