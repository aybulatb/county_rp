using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using CountyRP.Entities;
using CountyRP.WebAPI.Models;
using CountyRP.WebAPI.Models.ViewModels;

namespace CountyRP.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AllPlayerController : ControllerBase
    {
        private PlayerContext _playerContext;

        public AllPlayerController(PlayerContext playerContext)
        {
            _playerContext = playerContext;
        }

        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(AllPlayer), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult GetById(int id)
        {
            Player player = _playerContext.Players.FirstOrDefault(p => p.Id == id);
            if (player == null)
                return BadRequest();

            List<Person> persons = _playerContext.Persons.Where(p => p.PlayerId == player.Id).ToList();

            AllPlayer allPlayer = new AllPlayer
            {
                Player = player,
                Persons = persons
            };
            return Ok(allPlayer);
        }

        [HttpGet]
        [Route("GetByLogin")]
        [ProducesResponseType(typeof(AllPlayer), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult GetByLogin(string login)
        {
            Player player = _playerContext.Players.FirstOrDefault(p => p.Login == login);
            if (player == null)
                return BadRequest();

            List<Person> persons = _playerContext.Persons.Where(p => p.PlayerId == player.Id).ToList();

            AllPlayer allPlayer = new AllPlayer
            {
                Player = player,
                Persons = persons
            };
            return Ok(allPlayer);
        }
    }
}
