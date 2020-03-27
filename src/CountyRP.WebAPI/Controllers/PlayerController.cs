using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CountyRP.Entities;
using CountyRP.WebAPI.Models;

namespace CountyRP.WebAPI.Controllers
{
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private PlayerContext _playerContext;

        public PlayerController(PlayerContext playerContext)
        {
            _playerContext = playerContext;
        }

        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(Player), 200)]
        public IActionResult GetById(int id)
        {
            Player player = _playerContext.Players.FirstOrDefault(p => p.Id == id);

            if (player == null)
                return NotFound();

            return Ok(player);
        }

        [HttpGet]
        [Route("GetByLogin")]
        [ProducesResponseType(typeof(Player), 200)]
        public IActionResult GetByLogin(string login)
        {
            Player player = _playerContext.Players.FirstOrDefault(p => p.Login == login);

            if (player == null)
                return NotFound();

            return Ok(player);
        }
    }
}
