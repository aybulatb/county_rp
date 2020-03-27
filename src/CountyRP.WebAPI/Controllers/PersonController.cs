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
        public Person GetById(int id)
        {
            return _playerContext.Persons.FirstOrDefault(p => p.Id == id);
        }

        [HttpGet]
        [Route("GetByName")]
        public Person GetByName(string name)
        {
            return _playerContext.Persons.FirstOrDefault(p => p.Name == name);
        }
    }
}
