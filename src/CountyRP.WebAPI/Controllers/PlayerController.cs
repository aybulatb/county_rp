using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using CountyRP.Entities;
using CountyRP.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CountyRP.WebAPI.Controllers
{
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private PlayerContext _playerContext;
        private GroupContext _groupContext;

        public PlayerController(PlayerContext playerContext, GroupContext groupContext)
        {
            _playerContext = playerContext;
            _groupContext = groupContext;
        }

        [HttpGet("GetById/{id}")]
        [ProducesResponseType(typeof(Player), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            Player player = _playerContext.Players.FirstOrDefault(p => p.Id == id);

            if (player == null)
                return NotFound($"Игрок с ID {id} не найден");

            return Ok(player);
        }

        [HttpGet("GetByLogin/{login}")]
        [ProducesResponseType(typeof(Player), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetByLogin(string login)
        {
            Player player = _playerContext.Players.FirstOrDefault(p => p.Login == login);

            if (player == null)
                return NotFound($"Игрок с логином {login} не найден");

            return Ok(player);
        }

        [HttpGet("TryAuthorize")]
        [ProducesResponseType(typeof(Player), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult TryAuthorize(string login, string password)
        {
            Player player = _playerContext.Players
                .FirstOrDefault(p => p.Login == login && p.Password == password);

            if (player == null)
                return BadRequest("Неправильно указаны либо логин, либо пароль");

            return Ok(player);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Player), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody]Player player)
        {
            var result = CheckParams(player);
            if (result != null)
                return result;

            if (_playerContext.Players
                .FirstOrDefault(p => p.Login == player.Login) != null)
            {
                return BadRequest($"Игрок с логином {player.Login} уже существует");
            }

            _playerContext.Players.Add(player);
            _playerContext.SaveChanges();

            return Created("", player);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Player), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Edit([FromBody]Player player)
        {
            Player existingPlayer = _playerContext.Players.AsNoTracking()
                .FirstOrDefault(p => p.Id == player.Id);

            if (existingPlayer == null)
                return NotFound($"Игрок с ID {player.Id} не существует");

            var result = CheckParams(player);
            if (result != null)
                return result;

            if (existingPlayer.Login != player.Login && 
                _playerContext.Players
                .FirstOrDefault(p => p.Login == player.Login) != null)
            {
                return BadRequest($"Игрок с логином {player.Login} уже существует");
            }

            _playerContext.Players.Update(player);
            _playerContext.SaveChanges();

            return Ok(player);
        }

        [HttpPut("{id}/SetLogin/{login}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult SetLogin(int id, string login)
        {
            var result = CheckLogin(login);
            if (result != null)
                return result;

            Player player = _playerContext.Players.FirstOrDefault(p => p.Id == id);

            if (player == null)
                return NotFound($"Игрок с ID {id} не найден");

            if (_playerContext.Players
                .FirstOrDefault(p => p.Login == login) != null)
            {
                return BadRequest($"Игрок с логином {login} уже существует");
            }

            player.Login = login;
            _playerContext.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}/SetPassword/{password}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult SetPassword(int id, string password)
        {
            var result = CheckPassword(password);
            if (result != null)
                return result;

            Player player = _playerContext.Players.FirstOrDefault(p => p.Id == id);

            if (player == null)
                return NotFound($"Игрок с ID {id} не найден");

            player.Password = password;
            _playerContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            Player player = _playerContext.Players.FirstOrDefault(p => p.Id == id);

            if (player == null)
                return NotFound($"Игрок с ID {id} найден");

            _playerContext.Players.Remove(player);
            _playerContext.SaveChanges();

            return Ok();
        }


        private IActionResult CheckParams(Player player)
        {
            var result = CheckLogin(player.Login);
            if (result != null)
                return result;

            result = CheckPassword(player.Password);
            if (result != null)
                return result;

            if (player.Password.Length < 8 || player.Password.Length > 32)
                return BadRequest("Пароль должен быть от 8 до 32 символов");

            if (_groupContext.Groups
                .FirstOrDefault(g => g.Id == player.GroupId) == null)
            {
                return BadRequest($"Группа с ID {player.GroupId} не существует");
            }

            return null;
        }

        private IActionResult CheckLogin(string login)
        {
            if (login.Length < 3 || login.Length > 32)
                return BadRequest("Логин должен быть от 3 до 32 символов");

            return null;
        }

        private IActionResult CheckPassword(string password)
        {
            if (password.Length < 8 || password.Length > 32)
                return BadRequest("Пароль должен быть от 8 до 32 символов");

            return null;
        }
    }
}
