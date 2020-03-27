using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CountyRP.Entities;
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

        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(Person), 200)]
        public IActionResult GetById(int id)
        {
            Person person = _playerContext.Persons.FirstOrDefault(p => p.Id == id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpGet]
        [Route("GetByName")]
        [ProducesResponseType(typeof(Person), 200)]
        public IActionResult GetByName(string name)
        {
            Person person = _playerContext.Persons.FirstOrDefault(p => p.Name == name);

            if (person == null)
                return NotFound();

            return Ok(person);
        }
    }
}
