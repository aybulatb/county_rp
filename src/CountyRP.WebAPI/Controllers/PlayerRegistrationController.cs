using System.Linq;
using Microsoft.AspNetCore.Mvc;

using CountyRP.Entities;
using CountyRP.WebAPI.Models;

namespace CountyRP.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerRegistrationController : ControllerBase
    {
        private PlayerContext _playerContext;

        public PlayerRegistrationController(PlayerContext playerContext)
        {
            _playerContext = playerContext;
        }

        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(typeof(void), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult Register(string login, string password)
        {
            if (login.Length < 3 || login.Length > 32)
            {
                return BadRequest("Логин должен быть от 3 до 32 символов");
            }

            if (password.Length < 8 || login.Length > 32)
            {
                return BadRequest("Пароль должен быть от 8 до 32 символов");
            }

            Player existingPlayer = _playerContext.Players.
                FirstOrDefault(p => p.Login == login);

            if (existingPlayer != null)
            {
                return BadRequest();
            }

            _playerContext.Players.Add(new Player { Login = login, Password = password });
            _playerContext.SaveChanges();

            return StatusCode(201);
        }
    }
}
