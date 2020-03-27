using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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

        [HttpPost]
        [Route("TryAuthorize")]
        public async Task<IActionResult> TryAuthorize(string login, string password)
        {
            if (User.Identity.IsAuthenticated)
                return BadRequest("Вы уже авторизованы");

            Player player;

            try
            {
                player = await _playerAuthorizationClient.TryAuthorize(login, password);
            }
            catch (AdapterException ex)
            {
                return BadRequest(ex.Message);
            }

            await Authenticate(player.Id, player.Password);

            return Ok(player);
        }

        private async Task Authenticate(int id, string password)
        {
            var claims = new List<Claim>
            {
                new Claim("id", id.ToString()),
                new Claim("password", password)
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
        }

        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok();
        }
    }
}
