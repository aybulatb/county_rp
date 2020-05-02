using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using CountyRP.Entities;
using CountyRP.WebAPI.Models;
using CountyRP.WebAPI.Models.ViewModels.PersonViewModels;

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
        [Route("Create")]
        [ProducesResponseType(typeof(Person), StatusCodes.Status201Created)]
        public IActionResult Create([FromBody]CreatePerson createPerson)
        {
            Person person = new Person
            {
                Name = createPerson.Name,
                PlayerId = createPerson.PlayerId
            };

            _playerContext.Persons.Add(person);
            _playerContext.SaveChanges();

            return Created("", person);
        }

        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            Person person = _playerContext.Persons.FirstOrDefault(p => p.Id == id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpGet]
        [Route("GetByName")]
        [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
        public IActionResult GetByName(string name)
        {
            Person person = _playerContext.Persons.FirstOrDefault(p => p.Name == name);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpGet]
        [Route("GetAllByPlayerId")]
        [ProducesResponseType(typeof(List<Person>), StatusCodes.Status200OK)]
        public IActionResult GetAllByPlayerId(int playerId)
        {
            List<Person> persons = _playerContext.Persons.Where(p => p.PlayerId == playerId).ToList();

            if (persons == null)
                return NotFound();

            return Ok(persons);
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
        public IActionResult Update([FromBody]EditPerson editPerson)
        {
            Person person = _playerContext.Persons.FirstOrDefault(f => f.Id == editPerson.Id);

            person.FactionId = editPerson.FactionId;

            _playerContext.SaveChanges();

            return Ok(person);
        }
    }
}
