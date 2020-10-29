﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using CountyRP.Models;
using CountyRP.WebAPI.Models;
using CountyRP.WebAPI.Models.ViewModels;

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
            var playerDAO = _playerContext.Players.AsNoTracking().FirstOrDefault(p => p.Id == id);

            if (playerDAO == null)
                return NotFound($"Игрок с ID {id} не найден");

            return Ok(MapToModel(playerDAO));
        }

        [HttpGet("GetByLogin/{login}")]
        [ProducesResponseType(typeof(Player), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetByLogin(string login)
        {
            var playerDAO = _playerContext.Players.AsNoTracking().FirstOrDefault(p => p.Login == login);

            if (playerDAO == null)
                return NotFound($"Игрок с логином {login} не найден");

            return Ok(MapToModel(playerDAO));
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(FilteredModels<Player>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult FilterBy(int page, int count, string login)
        {
            if (page < 1)
                return BadRequest("Номер страницы игроков не может быть меньше 1");

            if (count < 1 || count > 50)
                return BadRequest("Количество игроков на одной странице должно быть от 1 до 50");

            IQueryable<DAO.Player> query = _playerContext.Players;
            if (!string.IsNullOrWhiteSpace(login))
                query = query.Where(p => p.Login.Contains(login));

            int allAmount = query.Count();
            int maxPage = (allAmount % count == 0) ? allAmount / count : allAmount / count + 1;
            if (page > maxPage && maxPage > 0)
                page = maxPage;

            var choosenPlayer = query
                    .Skip((page - 1) * count)
                    .Take(count)
                    .ToList();

            return Ok(new FilteredModels<Player>
            {
                Items = choosenPlayer.Select(p => MapToModel(p)).ToList(),
                AllAmount = allAmount,
                Page = page,
                MaxPage = maxPage
            });
        }

        [HttpGet("TryAuthorize")]
        [ProducesResponseType(typeof(Player), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult TryAuthorize(string login, string password)
        {
            var playerDAO = _playerContext.Players.AsNoTracking()
                .FirstOrDefault(p => p.Login == login && p.Password == password);

            if (playerDAO == null)
                return BadRequest("Неправильно указаны либо логин, либо пароль");

            return Ok(MapToModel(playerDAO));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Player), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] Player player)
        {
            var result = CheckParams(player);
            if (result != null)
                return result;

            if (_playerContext.Players
                .FirstOrDefault(p => p.Login == player.Login) != null)
            {
                return BadRequest($"Игрок с логином {player.Login} уже существует");
            }

            var playerDAO = MapToDAO(player);

            _playerContext.Players.Add(playerDAO);
            await _playerContext.SaveChangesAsync();

            player.Id = playerDAO.Id;

            return Created("", player);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Player), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, [FromBody] Player player)
        {
            if (id != player.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID игрока {player.Id}");

            var playerDAO = _playerContext.Players.AsNoTracking().FirstOrDefault(p => p.Id == player.Id);

            if (playerDAO == null)
                return NotFound($"Игрок с ID {player.Id} не существует");

            var result = CheckParams(player);
            if (result != null)
                return result;

            if (playerDAO.Login != player.Login && 
                _playerContext.Players
                .FirstOrDefault(p => p.Login == player.Login) != null)
            {
                return BadRequest($"Игрок с логином {player.Login} уже существует");
            }

            playerDAO = MapToDAO(player);

            _playerContext.Players.Update(playerDAO);
            await _playerContext.SaveChangesAsync();

            return Ok(player);
        }

        [HttpPut("{id}/SetLogin/{login}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SetLogin(int id, string login)
        {
            var result = CheckLogin(login);
            if (result != null)
                return result;

            var playerDAO = _playerContext.Players.FirstOrDefault(p => p.Id == id);

            if (playerDAO == null)
                return NotFound($"Игрок с ID {id} не найден");

            if (_playerContext.Players
                .FirstOrDefault(p => p.Login == login) != null)
            {
                return BadRequest($"Игрок с логином {login} уже существует");
            }

            playerDAO.Login = login;
            await _playerContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}/SetPassword/{password}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SetPassword(int id, string password)
        {
            var result = CheckPassword(password);
            if (result != null)
                return result;

            var playerDAO = _playerContext.Players.FirstOrDefault(p => p.Id == id);

            if (playerDAO == null)
                return NotFound($"Игрок с ID {id} не найден");

            playerDAO.Password = password;
            await _playerContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var playerDAO = _playerContext.Players.FirstOrDefault(p => p.Id == id);

            if (playerDAO == null)
                return NotFound($"Игрок с ID {id} не найден");

            _playerContext.Players.Remove(playerDAO);
            await _playerContext.SaveChangesAsync();

            return Ok();
        }


        private IActionResult CheckParams(Player player)
        {
            TrimParams(player);

            var result = CheckLogin(player.Login);
            if (result != null)
                return result;

            result = CheckPassword(player.Password);
            if (result != null)
                return result;

            if (player.GroupId == null || 
                _groupContext.Groups
                .FirstOrDefault(g => g.Id == player.GroupId) == null)
            {
                return BadRequest($"Группа с ID {player.GroupId} не существует");
            }

            return null;
        }

        private IActionResult CheckLogin(string login)
        {
            if (login == null || !System.Text.RegularExpressions.Regex.IsMatch(login, "^[a-zA-Z0-9]{3,32}$"))
                return BadRequest("Логин должен быть от 3 до 32 символов");

            return null;
        }

        private IActionResult CheckPassword(string password)
        {
            if (password == null || password.Length < 8 || password.Length > 32)
                return BadRequest("Пароль должен быть от 8 до 32 символов");

            return null;
        }

        private void TrimParams(Player player)
        {
            player.Login = player.Login?.Trim();
        }

        private DAO.Player MapToDAO(Player player)
        {
            return new DAO.Player
            {
                Id = player.Id,
                Login = player.Login,
                Password = player.Password,
                GroupId = player.GroupId
            };
        }

        private Player MapToModel(DAO.Player player)
        {
            return new Player
            {
                Id = player.Id,
                Login = player.Login,
                Password = player.Password,
                GroupId = player.GroupId
            };
        }
    }
}
