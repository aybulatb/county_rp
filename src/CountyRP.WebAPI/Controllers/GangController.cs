using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using CountyRP.Models;
using CountyRP.WebAPI.DbContexts;

namespace CountyRP.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GangController : ControllerBase
    {
        private GangContext _gangContext;

        public GangController(GangContext gangContext)
        {
            _gangContext = gangContext;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Gang), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Gang gang)
        {
            var result = CheckParams(gang);
            if (result != null)
                return result;

            var gangDAO = MapToDAO(gang);

            await _gangContext.Gangs.AddAsync(gangDAO);
            await _gangContext.SaveChangesAsync();

            gang.Id = gangDAO.Id;

            return Created("", gang);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Gang), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var gangDAO = await _gangContext.Gangs
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.Id == id);

            if (gangDAO == null)
                return NotFound($"Группировка с ID {id} не найдена");

            return Ok(
                MapToModel(gangDAO)
            );
        }

        [HttpGet]
        [ProducesResponseType(typeof(Gang[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var gangsDAO = await _gangContext.Gangs
                .AsNoTracking()
                .ToArrayAsync();

            return Ok(
                gangsDAO
                    .Select(g => MapToModel(g))
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Gang), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, [FromBody] Gang gang)
        {
            if (id != gang.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID {gang.Id} группировки");

            var isGangExisted = await _gangContext.Gangs
                .AsNoTracking()
                .AnyAsync(g => g.Id == id);
            if (!isGangExisted)
                return NotFound($"Группировка с ID {id} не найдена");

            var result = CheckParams(gang);
            if (result != null)
                return result;

            var gangDAO = MapToDAO(gang);
            _gangContext.Gangs.Update(gangDAO);
            await _gangContext.SaveChangesAsync();

            return Ok(gang);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var gangDAO = await _gangContext.Gangs
                .FirstOrDefaultAsync(g => g.Id == id);

            if (gangDAO == null)
                return NotFound($"Группировка с ID {id} не найдена");

            _gangContext.Gangs.Remove(gangDAO);
            await _gangContext.SaveChangesAsync();

            return Ok();
        }

        private IActionResult CheckParams(Gang gang)
        {
            TrimParams(gang);

            if (gang.Name == null || gang.Name.Length < 3 || gang.Name.Length > 32)
                return BadRequest("Название должно быть от 3 до 32 символов");

            if (gang.Ranks == null || gang.Ranks.Length != Constants.MaxGangRanks)
                return BadRequest($"Количество рангов должно быть {Constants.MaxGangRanks}");

            foreach (string rank in gang.Ranks)
            {
                if (rank == null || rank.Length < 1 || rank.Length > 32)
                    return BadRequest("Название ранга должно быть от 1 до 32 символов");
            }

            if (gang.Type < GangType.None)
                return BadRequest("Тип группировки должно быть от 0 до 1");

            return null;
        }

        private void TrimParams(Gang gang)
        {
            gang.Name = gang.Name?.Trim();
            for (int i = 0; i < gang.Ranks?.Length; i++)
                gang.Ranks[i] = gang.Ranks[i]?.Trim();
        }

        private DAO.Gang MapToDAO(Gang gang)
        {
            return new DAO.Gang
            {
                Id = gang.Id,
                Name = gang.Name,
                Color = gang.Color,
                Ranks = gang.Ranks
                    ?.Select(r => r)
                    .ToArray(),
                Type = gang.Type
            };
        }

        private Gang MapToModel(DAO.Gang gang)
        {
            return new Gang
            {
                Id = gang.Id,
                Name = gang.Name,
                Color = gang.Color,
                Ranks = gang.Ranks
                    ?.Select(r => r)
                    .ToArray(),
                Type = gang.Type
            };
        }
    }
}
