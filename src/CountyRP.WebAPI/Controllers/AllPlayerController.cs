using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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
            Player player = _playerContext.Players.FirstOrDefault(p => p.Id == id);
            if (player == null)
                return BadRequest();

            List<Person> persons = _playerContext.Persons.Where(p => p.PlayerId == player.Id).ToList();

            AllPlayer allPlayer = new AllPlayer
            {
                Player = player,
                Persons = persons.Select(p => new AllPerson 
                { 
                    Person = p,
                    Faction = _factionContext.Factions
                        .Where(f => f.Id == p.FactionId)
                        .Select(f => new Models.ViewModels.FactionViewModels.Faction
                        {
                            Id = f.Id,
                            Name = f.Name,
                            Ranks = f.Ranks
                        })
                        .FirstOrDefault(),
                    Vehicles = _propertyContext.Vehicles.Where(v => v.OwnerId == p.Id).ToList()
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
            Player player = _playerContext.Players.FirstOrDefault(p => p.Login == login);
            if (player == null)
                return BadRequest();

            List<Person> persons = _playerContext.Persons.Where(p => p.PlayerId == player.Id).ToList();

            AllPlayer allPlayer = new AllPlayer
            {
                Player = player,
                Persons = persons.Select(p => new AllPerson
                {
                    Person = p,
                    Faction = _factionContext.Factions
                        .Where(f => f.Id == p.FactionId)
                        .Select(f => new Models.ViewModels.FactionViewModels.Faction 
                        { 
                            Id = f.Id,
                            Name = f.Name,
                            Ranks = f.Ranks
                        })
                        .FirstOrDefault(),
                    Vehicles = _propertyContext.Vehicles.Where(v => v.OwnerId == p.Id).ToList()
                }).ToList()
            };

            return Ok(allPlayer);
        }
    }
}
