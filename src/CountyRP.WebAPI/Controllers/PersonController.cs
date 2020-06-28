using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using CountyRP.Models;
using CountyRP.WebAPI.Extensions;
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
        public IActionResult Create([FromBody]Person person)
        {
            var result = CheckParams(person);
            if (result != null)
                return result;

            if (_playerContext.Persons.FirstOrDefault(p => p.Name == person.Name) == null)
                return BadRequest($"Имя {person.Name} уже занято");

            Entities.Person personEntity = new Entities.Person().Format(person);

            _playerContext.Persons.Add(personEntity);
            _playerContext.SaveChanges();

            person.Id = personEntity.Id;

            return Created("", person);
        }

        [HttpGet("GetById/{id}")]
        [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            Entities.Person person = _playerContext.Persons.FirstOrDefault(p => p.Id == id);

            if (person == null)
                return NotFound($"Персонаж с ID {id} не найден");

            return Ok(new Person().Format(person));
        }

        [HttpGet("GetByName/{name}")]
        [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetByName(string name)
        {
            Entities.Person person = _playerContext.Persons.FirstOrDefault(p => p.Name == name);

            if (person == null)
                return NotFound($"Персонаж с именем {name} не найден");

            return Ok(new Person().Format(person));
        }

        [HttpGet("GetAllByPlayerId/{playerId}")]
        [ProducesResponseType(typeof(List<Person>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetAllByPlayerId(int playerId)
        {
            List<Entities.Person> persons = _playerContext.Persons.Where(p => p.PlayerId == playerId).ToList();

            if (persons == null)
                return NotFound($"Персонажи, привязанные к игроку с ID {playerId}, не найдены");

            return Ok(persons.Select(p => new Person().Format(p)));
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

            IQueryable<Entities.Person> query = _playerContext.Persons;
            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(p => p.Name.Contains(name));

            int allAmount = query.Count();
            int maxPage = (allAmount % count == 0) ? allAmount / count : allAmount / count + 1;
            if (page > maxPage)
                page = maxPage;

            return Ok(new FilteredModels<Person>
            {
                Items = query
                    .Skip((page - 1) * count)
                    .Take(count)
                    .Select(p => new Person().Format(p))
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
        public IActionResult Update(int id, [FromBody]Person person)
        {
            if (id != person.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID персонажа {person.Id}");

            var result = CheckParams(person);
            if (result != null)
                return result;

            Entities.Person personEntity = _playerContext.Persons.FirstOrDefault(p => p.Id == id);
            if (personEntity == null)
                return NotFound($"Персонаж с ID {id} не найден");

            if (person.Name != personEntity.Name
                && _playerContext.Persons.FirstOrDefault(p => p.Name == person.Name) == null)
                return BadRequest($"Имя {person.Name} уже занято");

            personEntity = personEntity.Format(person);

            _playerContext.Persons.Update(personEntity);
            _playerContext.SaveChanges();

            return Ok(person);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            Entities.Person person = _playerContext.Persons.FirstOrDefault(p => p.Id == id);
            if (person == null)
                return NotFound($"Персонаж с ID {id} не найден");

            _playerContext.Persons.Remove(person);
            _playerContext.SaveChanges();

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
    }
}
