using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using CountyRP.Models;
using CountyRP.WebSite.Exceptions;
using CountyRP.WebSite.Services.Interfaces;

namespace CountyRP.WebSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private IPlayerAdapter _playerAdapter;

        public AuthorizationController(IPlayerAdapter playerAdapter)
        {
            _playerAdapter = playerAdapter;
        }

        [HttpPost("TryAuthorize")]
        public async Task<IActionResult> TryAuthorize(string login, string password)
        {
            if (User.Identity.IsAuthenticated)
                return BadRequest("Вы уже авторизованы");

            Player player;

            try
            {
                player = await _playerAdapter.TryAuthorize(login, password);
            }
            catch (AdapterException ex)
            {
                return BadRequest(ex.Message);
            }

            string jwt = Authenticate(player.Id, player.Login);

            return Ok(new
            {
                access_token = jwt
            });
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            return Ok();
        }

        private string Authenticate(int id, string login)
        {
            var claims = new List<Claim>
            {
                new Claim("id", id.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, login)
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, "Token");

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromDays(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
    }
}
