using System.Linq;
using System.Threading.Tasks;
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
    public class FactionController : ControllerBase
    {
        private FactionContext _factionContext;

        public FactionController(FactionContext factionContext)
        {
            _factionContext = factionContext;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Faction), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Faction faction)
        {
            var result = CheckParams(faction);
            if (result != null)
                return result;
            
            if (_factionContext.Factions
                .FirstOrDefault(f => f.Id == faction.Id) != null)
            {
                return BadRequest($"Фракции с ID {faction.Id} уже существует");
            }

            var factionDAO = MapToDAO(faction);

            _factionContext.Factions.Add(factionDAO);
            await _factionContext.SaveChangesAsync();

            return Created("", faction);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Faction), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetById(string id)
        {
            var factionDAO = _factionContext.Factions.FirstOrDefault(f => f.Id == id);

            if (factionDAO == null)
                return NotFound($"Фракции с ID {id} не найдена");

            return Ok(MapToModel(factionDAO));
        }

        [HttpGet]
        [ProducesResponseType(typeof(Faction[]), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var factions = _factionContext.Factions.AsNoTracking().Select(f => MapToModel(f));

            return Ok(factions);
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(FilteredModels<Faction>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult FilterBy(int page, int count, string id, string name)
        {
            if (page < 1)
                return BadRequest("Номер страницы групп не может быть меньше 1");

            if (count < 1 || count > 50)
                return BadRequest("Количество групп на одной странице должно быть от 1 до 50");

            IQueryable<DAO.Faction> query = _factionContext.Factions;
            if (!string.IsNullOrWhiteSpace(id))
                query = query.Where(f => f.Id.Contains(id));
            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(f => f.Name.Contains(name));

            int allAmount = query.Count();
            int maxPage = (allAmount % count == 0) ? allAmount / count : allAmount / count + 1;
            if (page > maxPage && maxPage > 0)
                page = maxPage;

            return Ok(new FilteredModels<Faction>
            {
                Items = query
                    .Skip((page - 1) * count)
                    .Take(count)
                    .Select(f => MapToModel(f))
                    .ToList(),
                AllAmount = allAmount,
                Page = page,
                MaxPage = maxPage
            });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Faction), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(string id, [FromBody] Faction faction)
        {
            if (id != faction.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID {faction.Id} фракции");

            if (_factionContext.Factions.AsNoTracking()
                .FirstOrDefault(f => f.Id == faction.Id) == null)
            {
                return NotFound($"Фракции с ID {faction.Id} не найдена");
            }

            var result = CheckParams(faction);
            if (result != null)
                return result;

            _factionContext.Factions.Update(MapToDAO(faction));
            await _factionContext.SaveChangesAsync();

            return Ok(faction);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            var factionDAO = _factionContext.Factions.FirstOrDefault(f => f.Id == id);

            if (factionDAO == null)
                return NotFound($"Фракция с ID {id} не найдена");

            _factionContext.Factions.Remove(factionDAO);
            await _factionContext.SaveChangesAsync();

            return Ok();
        }

        private IActionResult CheckParams(Faction faction)
        {
            TrimParams(faction);

            if (faction.Id == null || !System.Text.RegularExpressions.Regex.IsMatch(faction.Id, "^[a-zA-Z0-9]{3,16}$"))
                return BadRequest("ID должен состоять из латинских букв и цифр от 3 до 16 символов");

            if (faction.Name == null || faction.Name.Length < 3 || faction.Name.Length > 32)
                return BadRequest("Название должно быть от 3 до 32 символов");

            if (faction.Ranks == null || faction.Ranks.Length != Constants.MaxFactionRanks)
                return BadRequest($"Количество рангов должно быть {Constants.MaxFactionRanks}");

            foreach (string rank in faction.Ranks)
            {
                if (rank == null || rank.Length < 1 || rank.Length > 32)
                    return BadRequest("Название ранга должно быть от 1 до 32 символов");
            }

            if (faction.Type < FactionType.None)
                return BadRequest("Тип фракции должно быть от 0 до 1");

            return null;
        }

        private void TrimParams(Faction faction)
        {
            faction.Id = faction.Id?.Trim();
            faction.Name = faction.Name?.Trim();
            for (int i = 0; i < faction.Ranks?.Length; i++)
                faction.Ranks[i] = faction.Ranks[i]?.Trim();
        }

        private DAO.Faction MapToDAO(Faction faction)
        {
            return new DAO.Faction
            {
                Id = faction.Id,
                Name = faction.Name,
                Ranks = faction.Ranks?.Select(r => r).ToArray(),
                Type = faction.Type
            };
        }

        private Faction MapToModel(DAO.Faction faction)
        {
            return new Faction
            {
                Id = faction.Id,
                Name = faction.Name,
                Ranks = faction.Ranks?.Select(r => r).ToArray(),
                Type = faction.Type
            };
        }
    }
}
