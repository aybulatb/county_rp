using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using CountyRP.Models;
using CountyRP.WebAPI.Models;
using CountyRP.WebAPI.Models.ViewModels;

namespace CountyRP.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameBanController : ControllerBase
    {
        private BanContext _banContext;
        private PlayerContext _playerContext;

        public GameBanController(BanContext banContext, PlayerContext playerContext)
        {
            _banContext = banContext;
            _playerContext = playerContext;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GameBan), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var gameBan = _banContext.GameBans.AsNoTracking().FirstOrDefault(sb => sb.Id == id);

            if (gameBan == null)
                return NotFound($"Бан в игре с ID {id} не найден");

            return Ok(MapToModel(gameBan));
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(FilteredModels<GameBan>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult FilterBy(int page, int count)
        {
            if (page < 1)
                return BadRequest("Номер страницы банов не может быть меньше 1");

            if (count < 1 || count > 50)
                return BadRequest("Количество банов на одной странице должно быть от 1 до 50");

            IQueryable<Entities.GameBan> query = _banContext.GameBans;

            int allAmount = query.Count();
            int maxPage = (allAmount % count == 0) ? allAmount / count : allAmount / count + 1;
            if (page > maxPage && maxPage > 0)
                page = maxPage;

            var choosenGameBans = query
                    .Skip((page - 1) * count)
                    .Take(count)
                    .Select(sb => sb)
                    .ToList();

            return Ok(new FilteredModels<GameBan>
            {
                Items = choosenGameBans.Select(sb => MapToModel(sb)).ToList(),
                AllAmount = allAmount,
                Page = page,
                MaxPage = maxPage
            });
        }

        [HttpPost]
        [ProducesResponseType(typeof(GameBan), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody]GameBan gameBan)
        {
            var error = CheckParams(gameBan);
            if (error != null)
                return error;

            var gameBanEntity = MapToEntity(gameBan);
            gameBanEntity.Id = 0;

            _banContext.GameBans.Add(gameBanEntity);
            _banContext.SaveChanges();

            return Created("", MapToModel(gameBanEntity));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(GameBan), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Edit(int id, [FromBody]GameBan gameBan)
        {
            if (gameBan.Id != id)
                return BadRequest($"Указанный ID {id} не соответствует ID {gameBan.Id} бана в игре");

            var gameBanEntity = _banContext.GameBans.FirstOrDefault(sb => sb.Id == id);

            if (gameBanEntity == null)
                return NotFound($"Бан в игре с ID {id} не найден");

            var error = CheckParams(gameBan);
            if (error != null)
                return error;

            gameBanEntity.PlayerId = gameBan.PlayerId;
            gameBanEntity.PersonId = gameBan.PersonId;
            gameBanEntity.AdminId = gameBan.AdminId;
            gameBanEntity.StartDateTime = gameBan.StartDateTime;
            gameBanEntity.FinishDateTime = gameBan.FinishDateTime;
            gameBanEntity.IP = gameBan.IP;
            gameBanEntity.Reason = gameBan.Reason;

            _banContext.SaveChanges();

            return Ok(gameBan);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var gameBan = _banContext.GameBans.FirstOrDefault(sb => sb.Id == id);

            if (gameBan == null)
                return NotFound($"Бан в игре с ID {id} не найден");

            _banContext.GameBans.Remove(gameBan);
            _banContext.SaveChanges();

            return Ok();
        }

        private Entities.GameBan MapToEntity(GameBan sb)
        {
            return new Entities.GameBan
            {
                Id = sb.Id,
                PlayerId = sb.PlayerId,
                PersonId = sb.PersonId,
                AdminId = sb.AdminId,
                StartDateTime = sb.StartDateTime,
                FinishDateTime = sb.FinishDateTime,
                IP = sb.IP,
                Reason = sb.Reason
            };
        }

        private GameBan MapToModel(Entities.GameBan sb)
        {
            return new GameBan
            {
                Id = sb.Id,
                PlayerId = sb.PlayerId,
                PersonId = sb.PersonId,
                AdminId = sb.AdminId,
                StartDateTime = sb.StartDateTime,
                FinishDateTime = sb.FinishDateTime,
                IP = sb.IP,
                Reason = sb.Reason
            };
        }

        private IActionResult CheckParams(GameBan gameBan)
        {
            if (gameBan.PlayerId != 0 && gameBan.PersonId != 0)
                return BadRequest($"Можно забанить только либо игрока, либо персонажа");

            if (gameBan.PersonId == 0 && _playerContext.Players.FirstOrDefault(p => p.Id == gameBan.PlayerId) == null)
                return BadRequest($"Забаненный игрок с ID {gameBan.PlayerId} не найден");

            if (gameBan.PlayerId == 0 && _playerContext.Persons.FirstOrDefault(p => p.Id == gameBan.PersonId) == null)
                return BadRequest($"Забаненный персонаж с ID {gameBan.PersonId} не найден");

            if (_playerContext.Players.FirstOrDefault(p => p.Id == gameBan.AdminId) == null)
                return BadRequest($"Забанивший игрок с ID {gameBan.AdminId} не найден");

            if (gameBan.StartDateTime > gameBan.FinishDateTime)
                return BadRequest("Дата бана не может быть больше даты окончания бана");

            if (gameBan.Reason.Length < 1 || gameBan.Reason.Length > 96)
                return BadRequest("Причина бана должна быть от 1 до 96 символов");

            if (!string.IsNullOrWhiteSpace(gameBan.IP) && !Regex.IsMatch(gameBan.IP, "^[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}$"))
                return BadRequest("IP должен быть в формате 255.255.255.255");

            return null;
        }
    }
}
