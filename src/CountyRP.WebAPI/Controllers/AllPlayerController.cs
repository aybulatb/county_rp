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
    [ApiController]
    [Route("[controller]")]
    public class AllPlayerController : ControllerBase
    {
        private PlayerContext _playerContext;
        private PropertyContext _propertyContext;
        private FactionContext _factionContext;

        public AllPlayerController(PlayerContext playerContext, PropertyContext propertyContext, FactionContext factionContext)
        {
            _playerContext = playerContext;
            _propertyContext = propertyContext;
            _factionContext = factionContext;
        }

        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(AllPlayer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult GetById(int id)
        {
            Entities.Player player = _playerContext.Players.FirstOrDefault(p => p.Id == id);
            if (player == null)
                return BadRequest();

            List<Entities.Person> persons = _playerContext.Persons.Where(p => p.PlayerId == player.Id).ToList();

            AllPlayer allPlayer = new AllPlayer
            {
                Player = new Player().Format(player),
                Persons = persons.Select(p => new AllPerson 
                { 
                    Person = new Person().Format(p),
                    Faction = _factionContext.Factions
                        .Where(f => f.Id == p.FactionId)
                        .Select(f => new Faction
                        {
                            Id = f.Id,
                            Name = f.Name,
                            Ranks = f.Ranks
                        })
                        .FirstOrDefault(),
                    Vehicles = _propertyContext.Vehicles.Where(v => v.OwnerId == p.Id).Select(v => new Vehicle
                    { 
                        Id = v.Id
                    }).ToList()
                }).ToList()
            };

            return Ok(allPlayer);
        }

        [HttpGet]
        [Route("GetByLogin")]
        [ProducesResponseType(typeof(AllPlayer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult GetByLogin(string login)
        {
            Entities.Player player = _playerContext.Players.FirstOrDefault(p => p.Login == login);
            if (player == null)
                return BadRequest();

            List<Entities.Person> persons = _playerContext.Persons.Where(p => p.PlayerId == player.Id).ToList();

            AllPlayer allPlayer = new AllPlayer
            {
                Player = new Player().Format(player),
                Persons = persons.Select(p => new AllPerson
                {
                    Person = new Person().Format(p),
                    Faction = _factionContext.Factions
                        .Where(f => f.Id == p.FactionId)
                        .Select(f => new Faction 
                        { 
                            Id = f.Id,
                            Name = f.Name,
                            Ranks = f.Ranks
                        })
                        .FirstOrDefault(),
                    Vehicles = _propertyContext.Vehicles.Where(v => v.OwnerId == p.Id).Select(v => new Vehicle
                    {
                        Id = v.Id
                    }).ToList()
                }).ToList()
            };

            return Ok(allPlayer);
        }
    }
}
