using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using CountyRP.Models;
using CountyRP.WebAPI.DbContexts;
using CountyRP.WebAPI.Models.ViewModels;

namespace CountyRP.WebAPI.Controllers
{
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private PlayerContext _playerContext;
        private FactionContext _factionContext;
        private GangContext _gangContext;
        private AdminLevelContext _adminLevelContext;

        public PersonController(PlayerContext playerContext, FactionContext factionContext, GangContext gangContext, AdminLevelContext adminLevelContext)
        {
            _playerContext = playerContext;
            _factionContext = factionContext;
            _gangContext = gangContext;
            _adminLevelContext = adminLevelContext;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Person), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Person person)
        {
            var result = await CheckParamsAsync(person);
            if (result != null)
                return result;

            var isPersonExisted = await _playerContext.Persons
                .AnyAsync(p => p.Name == person.Name);
            if (isPersonExisted)
                return BadRequest($"Имя {person.Name} уже занято");

            var personDAO = MapToDAO(person);

            await _playerContext.Persons.AddAsync(personDAO);
            await _playerContext.SaveChangesAsync();

            person.Id = personDAO.Id;

            return Created("", person);
        }

        [HttpGet("GetById/{id}")]
        [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var personDAO = await _playerContext.Persons
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (personDAO == null)
                return NotFound($"Персонаж с ID {id} не найден");

            return Ok(
                MapToModel(personDAO)
            );
        }

        [HttpGet("GetByName/{name}")]
        [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByName(string name)
        {
            var personDAO = await _playerContext.Persons
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Name == name);

            if (personDAO == null)
                return NotFound($"Персонаж с именем {name} не найден");

            return Ok(
                MapToModel(personDAO)
            );
        }

        [HttpGet("GetAllByPlayerId/{playerId}")]
        [ProducesResponseType(typeof(Person[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllByPlayerId(int playerId)
        {
            var personsDAO = await _playerContext.Persons
                .AsNoTracking()
                .Where(p => p.PlayerId == playerId)
                .ToArrayAsync();

            if (personsDAO == null)
                return NotFound($"Персонажи, привязанные к игроку с ID {playerId}, не найдены");

            return Ok(
                personsDAO
                    .Select(p => MapToModel(p))
            );
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(FilteredModels<Person>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterBy(int page, int count, string name)
        {
            if (page < 1)
                return BadRequest("Номер страницы персонажей не может быть меньше 1");

            if (count < 1 || count > 50)
                return BadRequest("Количество персонажей на одной странице должно быть от 1 до 50");

            IQueryable<DAO.Person> query = _playerContext.Persons;
            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(p => p.Name.Contains(name));

            int allAmount = await query.CountAsync();
            int maxPage = (allAmount % count == 0) ? allAmount / count : allAmount / count + 1;
            if (page > maxPage && maxPage > 0)
                page = maxPage;

            var choosenPersons = await query
                    .Skip((page - 1) * count)
                    .Take(count)
                    .ToListAsync();

            return Ok(new FilteredModels<Person>
            {
                Items = choosenPersons
                    .Select(p => MapToModel(p))
                    .ToList(),
                AllAmount = allAmount,
                Page = page,
                MaxPage = maxPage
            });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] Person person)
        {
            if (id != person.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID персонажа {person.Id}");

            var result = await CheckParamsAsync(person);
            if (result != null)
                return result;

            var personDAO = await _playerContext.Persons
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
            if (personDAO == null)
                return NotFound($"Персонаж с ID {id} не найден");

            var isPersonExisted = await _playerContext.Persons
                .AnyAsync(p => p.Name == person.Name);

            if (person.Name != personDAO.Name && isPersonExisted)
                return BadRequest($"Имя {person.Name} уже занято");

            personDAO = MapToDAO(person);

            _playerContext.Persons.Update(personDAO);
            await _playerContext.SaveChangesAsync();

            return Ok(person);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var personDAO = await _playerContext.Persons
                .FirstOrDefaultAsync(p => p.Id == id);
            if (personDAO == null)
                return NotFound($"Персонаж с ID {id} не найден");

            _playerContext.Persons.Remove(personDAO);
            await _playerContext.SaveChangesAsync();

            return Ok();
        }

        private IActionResult CheckName(string name)
        {
            if (name == null || name.Length < 3 ||  name.Length > 32)
                return BadRequest("Длина имени должна быть от 3 до 32 символов");

            if (!System.Text.RegularExpressions.Regex.IsMatch(name, "^[a-zA-Z]+_[a-zA-Z]+$"))
                return BadRequest("Имя должно состоять из латинских букв и соответствовать формату: Имя_Фамилия");

            return null;
        }

        private async Task<IActionResult> CheckParamsAsync(Person person)
        {
            var result = CheckName(person.Name);
            if (result != null)
                return result;

            if (person.Position == null || person.Position.Length != 3)
                return BadRequest("Количество координат позиции должно быть равно 3");

            var isPlayerExisted = await _playerContext.Players
                .AnyAsync(p => p.Id == person.PlayerId);

            if (!isPlayerExisted)
                return BadRequest($"Игрок с ID {person.PlayerId} не найден");

            var isAdminLevelExisted = await _adminLevelContext.AdminLevels
                .AnyAsync(g => g.Id == person.AdminLevelId);

            if (person.AdminLevelId == null || person.AdminLevelId != string.Empty && !isAdminLevelExisted)
                return BadRequest($"Уровень админки с ID {person.AdminLevelId} не найден");

            var isFactionExisted = await _factionContext.Factions
                .AnyAsync(f => f.Id == person.FactionId);

            if (person.FactionId == null || person.FactionId != string.Empty && !isFactionExisted)
                return BadRequest($"Фракция с ID {person.FactionId} не найдена");

            var isGangExisted = await _gangContext.Gangs
                .AnyAsync(g => g.Id == person.GroupId);

            if (person.GroupId != 0 && !isGangExisted)
                return BadRequest($"Группировка с ID {person.GroupId} не найдена");

            return null;
        }

        private DAO.Person MapToDAO(Person person)
        {
            return new DAO.Person
            {
                Id = person.Id,
                Name = person.Name,
                PlayerId = person.PlayerId,
                RegDate = person.RegDate,
                LastDate = person.LastDate,
                AdminLevelId = person.AdminLevelId,
                FactionId = person.FactionId,
                GroupId = person.GroupId,
                Leader = person.Leader,
                Rank = person.Rank,
                Position = person.Position
                    ?.ToArray(),
                CommonInventoryId = person.CommonInventoryId,
                PocketsInventoryId = person.PocketsInventoryId
            };
        }

        private Person MapToModel(DAO.Person person)
        {
            return new Person
            {
                Id = person.Id,
                Name = person.Name,
                PlayerId = person.PlayerId,
                RegDate = person.RegDate,
                LastDate = person.LastDate,
                AdminLevelId = person.AdminLevelId,
                FactionId = person.FactionId,
                GroupId = person.GroupId,
                Leader = person.Leader,
                Rank = person.Rank,
                Position = person.Position
                    ?.ToArray(),
                CommonInventoryId = person.CommonInventoryId,
                PocketsInventoryId = person.PocketsInventoryId
            };
        }
    }
}
