using System.Linq;
using Microsoft.AspNetCore.Mvc;

using CountyRP.Entities;
using CountyRP.WebAPI.Models;

namespace CountyRP.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerAuthorizationController : ControllerBase
    {
        private PlayerContext playerContext;

        public PlayerAuthorizationController(PlayerContext playerContext)
        {
            this.playerContext = playerContext;
        }

        [HttpGet]
        [Route("tryauthorize")]
        [ProducesResponseType(typeof(Player), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult TryAuthorize(string login, string password)
        {
            Player player = playerContext.Players.
                FirstOrDefault(p => p.Login == login && p.Password == password);

            if (player == null)
            {
                return BadRequest("Игрок не найден");
            }

            return Ok(player);
        }
    }
}
