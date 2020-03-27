using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CountyRP.Entities;
using CountyRP.WebAPI.Models;

namespace CountyRP.WebAPI.Controllers
{
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private PlayerContext _playerContext;

        public PlayerController(PlayerContext playerContext)
        {
            _playerContext = playerContext;
        }

        [HttpGet]
        [Route("GetById")]
        public Player GetById(int id)
        {
            return _playerContext.Players.FirstOrDefault(p => p.Id == id);
        }

        [HttpGet]
        [Route("GetByLogin")]
        public Player GetByLogin(string login)
        {
            return _playerContext.Players.FirstOrDefault(p => p.Login == login);
        }
    }
}
