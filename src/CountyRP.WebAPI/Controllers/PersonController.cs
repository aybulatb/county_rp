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
            var result = CheckParams(person);
            if (result != null)
                return result;

            if (_playerContext.Persons.FirstOrDefault(p => p.Name == person.Name) != null)
                return BadRequest($"Имя {person.Name} уже занято");

            var personDAO = MapToDAO(person);

            _playerContext.Persons.Add(personDAO);
            await _playerContext.SaveChangesAsync();

            person.Id = personDAO.Id;

            return Created("", person);
        }

        [HttpGet("GetById/{id}")]
        [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var personDAO = _playerContext.Persons.AsNoTracking().FirstOrDefault(p => p.Id == id);

            if (personDAO == null)
                return NotFound($"Персонаж с ID {id} не найден");

            return Ok(MapToModel(personDAO));
        }

        [HttpGet("GetByName/{name}")]
        [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetByName(string name)
        {
            var personDAO = _playerContext.Persons.AsNoTracking().FirstOrDefault(p => p.Name == name);

            if (personDAO == null)
                return NotFound($"Персонаж с именем {name} не найден");

            return Ok(MapToModel(personDAO));
        }

        [HttpGet("GetAllByPlayerId/{playerId}")]
        [ProducesResponseType(typeof(Person[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetAllByPlayerId(int playerId)
        {
            var personsDAO = _playerContext.Persons.AsNoTracking().Where(p => p.PlayerId == playerId).ToArray();

            if (personsDAO == null)
                return NotFound($"Персонажи, привязанные к игроку с ID {playerId}, не найдены");

            return Ok(personsDAO.Select(p => MapToModel(p)));
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(FilteredModels<Person>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult FilterBy(int page, int count, string name)
        {
            if (page < 1)
                return BadRequest("Номер страницы персонажей не может быть меньше 1");

            if (count < 1 || count > 50)
                return BadRequest("Количество персонажей на одной странице должно быть от 1 до 50");

            IQueryable<DAO.Person> query = _playerContext.Persons;
            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(p => p.Name.Contains(name));

            int allAmount = query.Count();
            int maxPage = (allAmount % count == 0) ? allAmount / count : allAmount / count + 1;
            if (page > maxPage && maxPage > 0)
                page = maxPage;

            return Ok(new FilteredModels<Person>
            {
                Items = query
                    .Skip((page - 1) * count)
                    .Take(count)
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

            var result = CheckParams(person);
            if (result != null)
                return result;

            var personDAO = _playerContext.Persons.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (personDAO == null)
                return NotFound($"Персонаж с ID {id} не найден");

            if (person.Name != personDAO.Name
                && _playerContext.Persons.FirstOrDefault(p => p.Name == person.Name) != null)
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
            var personDAO = _playerContext.Persons.FirstOrDefault(p => p.Id == id);
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

        private IActionResult CheckParams(Person person)
        {
            var result = CheckName(person.Name);
            if (result != null)
                return result;

            if (person.Position == null || person.Position.Length != 3)
                return BadRequest("Количество координат позиции должно быть равно 3");

            if (_playerContext.Players
                .FirstOrDefault(p => p.Id == person.PlayerId) == null)
                return BadRequest($"Игрок с ID {person.PlayerId} не найден");

            if (person.AdminLevelId == null ||
                person.AdminLevelId != string.Empty &&
                _adminLevelContext.AdminLevels
                .FirstOrDefault(g => g.Id == person.AdminLevelId) == null)
                return BadRequest($"Уровень админки с ID {person.AdminLevelId} не найден");

            if (person.FactionId == null ||
                person.FactionId != string.Empty &&
                _factionContext.Factions.FirstOrDefault(f => f.Id == person.FactionId) == null)
                return BadRequest($"Фракция с ID {person.FactionId} не найдена");

            if (person.GroupId != 0 &&
                _gangContext.Gangs.FirstOrDefault(g => g.Id == person.GroupId) == null)
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
                Position = person.Position?.Select(p => p).ToArray()
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
                Position = person.Position?.Select(p => p).ToArray()
            };
        }
    }
}
