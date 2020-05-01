using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using CountyRP.Models;
using CountyRP.WebAPI.Extensions;
using CountyRP.WebAPI.Models;

namespace CountyRP.WebAPI.Controllers
{
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private PlayerContext _playerContext;

        public PersonController(PlayerContext playerContext)
        {
            _playerContext = playerContext;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Person), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody]Person person)
        {
            var result = CheckParams(person);
            if (result != null)
                return result;

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

            personEntity = personEntity.Format(person);

            _playerContext.Persons.Update(personEntity);
            _playerContext.SaveChanges();

            return Ok(person);
        }

        
        private IActionResult CheckName(string name)
        {
            if (name.Length < 3 || name.Length > 32)
                return BadRequest("Длина имени должна быть от 3 до 32 символов");

            return null;
        }

        private IActionResult CheckParams(Person person)
        {
            var result = CheckName(person.Name);
            if (result != null)
                return result;

            if (_playerContext.Players
                .FirstOrDefault(p => p.Id == person.PlayerId) == null)
                return BadRequest($"Игрок с ID {person.PlayerId} для привязки персонажа не найден");

            return null;
        }
    }
}
