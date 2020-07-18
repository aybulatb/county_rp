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
    public class LogController : ControllerBase
    {
        private LogContext _logContext;
        private PlayerContext _playerContext;

        public LogController(LogContext logContext, PlayerContext playerContext)
        {
            _logContext = logContext;
            _playerContext = playerContext;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LogUnit), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var logUnit = _logContext.LogUnits.AsNoTracking().FirstOrDefault(lu => lu.Id == id);

            if (logUnit == null)
                return NotFound($"Лог с ID {id} не найден");

            return Ok(MapToModel(logUnit));
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(FilteredModels<LogUnit>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult FilterBy(int page, int count)
        {
            if (page < 1)
                return BadRequest("Номер страницы логов не может быть меньше 1");

            if (count < 1 || count > 50)
                return BadRequest("Количество логов на одной странице должно быть от 1 до 50");

            IQueryable<Entities.LogUnit> query = _logContext.LogUnits;

            int allAmount = query.Count();
            int maxPage = (allAmount % count == 0) ? allAmount / count : allAmount / count + 1;
            if (page > maxPage && maxPage > 0)
                page = maxPage;

            var choosenLogUnits = query
                    .Skip((page - 1) * count)
                    .Take(count)
                    .ToList();

            return Ok(new FilteredModels<LogUnit>
            {
                Items = choosenLogUnits.Select(lu => MapToModel(lu)).ToList(),
                AllAmount = allAmount,
                Page = page,
                MaxPage = maxPage
            });
        }

        [HttpPost]
        [ProducesResponseType(typeof(LogUnit), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody]LogUnit logUnit)
        {
            var error = CheckParams(logUnit);
            if (error != null)
                return error;

            var logUnitEntity = MapToEntity(logUnit);
            logUnitEntity.Id = 0;

            _logContext.LogUnits.Add(logUnitEntity);
            _logContext.SaveChanges();

            return Created("", MapToModel(logUnitEntity));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(LogUnit), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Edit(int id, [FromBody]LogUnit logUnit)
        {
            if (logUnit.Id != id)
                return BadRequest($"Указанный ID {id} не соответствует ID {logUnit.Id} лога");

            var logUnitEntity = _logContext.LogUnits.SingleOrDefault(lu => lu.Id == id);

            if (logUnitEntity == null)
                return NotFound($"Лог с ID {id} не найден");

            var error = CheckParams(logUnit);
            if (error != null)
                return error;

            logUnitEntity.DateTime = logUnit.DateTime;
            logUnitEntity.Login = logUnit.Login;
            logUnitEntity.IP = logUnit.IP;
            logUnitEntity.ActionId = (Entities.LogAction)logUnit.ActionId;
            logUnitEntity.Comment = logUnit.Comment;

            _logContext.SaveChanges();

            return Ok(logUnit);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var logUnit = _logContext.LogUnits.SingleOrDefault(lu => lu.Id == id);

            if (logUnit == null)
                return NotFound($"Лог с ID {id} не найден");

            _logContext.LogUnits.Remove(logUnit);
            _logContext.SaveChanges();

            return Ok();
        }

        private Entities.LogUnit MapToEntity(LogUnit lu)
        {
            return new Entities.LogUnit
            {
                Id = lu.Id,
                DateTime = lu.DateTime,
                Login = lu.Login,
                IP = lu.IP,
                ActionId = (Entities.LogAction)lu.ActionId,
                Comment = lu.Comment
            };
        }

        private LogUnit MapToModel(Entities.LogUnit lu)
        {
            return new LogUnit
            {
                Id = lu.Id,
                DateTime = lu.DateTime,
                Login = lu.Login,
                IP = lu.IP,
                ActionId = (LogAction)lu.ActionId,
                Comment = lu.Comment
            };
        }

        private IActionResult CheckParams(LogUnit logUnit)
        {
            if (logUnit.Login.Length < 3 || logUnit.Login.Length > 32)
                return BadRequest("Логин должен быть от 3 до 32 символов");

            if (!string.IsNullOrWhiteSpace(logUnit.IP) && !Regex.IsMatch(logUnit.IP, "^[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}$"))
                return BadRequest("IP должен быть в формате 255.255.255.255");

            return null;
        }
    }
}
