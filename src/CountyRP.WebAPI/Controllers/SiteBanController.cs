using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using CountyRP.Models;
using CountyRP.WebAPI.DbContexts;
using CountyRP.WebAPI.Models.ViewModels;

namespace CountyRP.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SiteBanController : ControllerBase
    {
        private BanContext _banContext;
        private PlayerContext _playerContext;

        public SiteBanController(BanContext banContext, PlayerContext playerContext)
        {
            _banContext = banContext;
            _playerContext = playerContext;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SiteBan), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var siteBan = _banContext.SiteBans.AsNoTracking().FirstOrDefault(sb => sb.Id == id);

            if (siteBan == null)
                return NotFound($"Бан на сайте с ID {id} не найден");

            return Ok(MapToModel(siteBan));
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(FilteredModels<SiteBan>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult FilterBy(int page, int count)
        {
            if (page < 1)
                return BadRequest("Номер страницы банов не может быть меньше 1");

            if (count < 1 || count > 50)
                return BadRequest("Количество банов на одной странице должно быть от 1 до 50");

            IQueryable<DAO.SiteBan> query = _banContext.SiteBans;

            int allAmount = query.Count();
            int maxPage = (allAmount % count == 0) ? allAmount / count : allAmount / count + 1;
            if (page > maxPage && maxPage > 0)
                page = maxPage;

            var choosenSiteBans = query
                    .Skip((page - 1) * count)
                    .Take(count)
                    .ToList();

            return Ok(new FilteredModels<SiteBan>
            {
                Items = choosenSiteBans.Select(sb => MapToModel(sb)).ToList(),
                AllAmount = allAmount,
                Page = page,
                MaxPage = maxPage
            });
        }

        [HttpPost]
        [ProducesResponseType(typeof(SiteBan), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] SiteBan siteBan)
        {
            var error = CheckParams(siteBan);
            if (error != null)
                return error;

            var siteBanDAO = MapToDAO(siteBan);
            siteBanDAO.Id = 0;

            _banContext.SiteBans.Add(siteBanDAO);
            await _banContext.SaveChangesAsync();

            return Created("", MapToModel(siteBanDAO));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SiteBan), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, [FromBody] SiteBan siteBan)
        {
            if (siteBan.Id != id)
                return BadRequest($"Указанный ID {id} не соответствует ID {siteBan.Id} бана на сайте");

            var siteBanDAO = _banContext.SiteBans.AsNoTracking().FirstOrDefault(sb => sb.Id == id);

            if (siteBanDAO == null)
                return NotFound($"Бан на сайте с ID {id} не найден");

            var error = CheckParams(siteBan);
            if (error != null)
                return error;

            siteBanDAO = MapToDAO(siteBan);

            _banContext.SiteBans.Update(siteBanDAO);
            await _banContext.SaveChangesAsync();

            return Ok(siteBan);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var siteBanDAO = _banContext.SiteBans.FirstOrDefault(sb => sb.Id == id);

            if (siteBanDAO == null)
                return NotFound($"Бан на сайте с ID {id} не найден");

            _banContext.SiteBans.Remove(siteBanDAO);
            await _banContext.SaveChangesAsync();

            return Ok();
        }

        private DAO.SiteBan MapToDAO(SiteBan siteBan)
        {
            return new DAO.SiteBan
            {
                Id = siteBan.Id,
                PlayerId = siteBan.PlayerId,
                AdminId = siteBan.AdminId,
                StartDateTime = siteBan.StartDateTime,
                FinishDateTime = siteBan.FinishDateTime,
                IP = siteBan.IP,
                Reason = siteBan.Reason
            };
        }

        private SiteBan MapToModel(DAO.SiteBan siteBan)
        {
            return new SiteBan
            {
                Id = siteBan.Id,
                PlayerId = siteBan.PlayerId,
                AdminId = siteBan.AdminId,
                StartDateTime = siteBan.StartDateTime,
                FinishDateTime = siteBan.FinishDateTime,
                IP = siteBan.IP,
                Reason = siteBan.Reason
            };
        }

        private IActionResult CheckParams(SiteBan siteBan)
        {
            if (_playerContext.Players.FirstOrDefault(p => p.Id == siteBan.PlayerId) == null)
                return BadRequest($"Забаненный игрок с ID {siteBan.PlayerId} не найден");

            if (_playerContext.Players.FirstOrDefault(p => p.Id == siteBan.AdminId) == null)
                return BadRequest($"Забанивший игрок с ID {siteBan.AdminId} не найден");

            if (siteBan.StartDateTime > siteBan.FinishDateTime)
                return BadRequest("Дата бана не может быть больше даты окончания бана");

            if (siteBan.Reason.Length < 1 || siteBan.Reason.Length > 96)
                return BadRequest("Причина бана должна быть от 1 до 96 символов");

            if (!string.IsNullOrWhiteSpace(siteBan.IP) && !Regex.IsMatch(siteBan.IP, "^[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}$"))
                return BadRequest("IP должен быть в формате 255.255.255.255");

            return null;
        }
    }
}
