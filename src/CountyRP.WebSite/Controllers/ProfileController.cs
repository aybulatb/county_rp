using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CountyRP.Extra;
using CountyRP.WebSite.Services.Interfaces;

namespace CountyRP.WebSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private IAllPlayerAdapter _allPlayerAdapter;

        public ProfileController(IAllPlayerAdapter allPlayerAdapter)
        {
            _allPlayerAdapter = allPlayerAdapter;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile(string login)
        {
            AllPlayer allPlayer;

            allPlayer = await _allPlayerAdapter.GetByLogin(login);

            return Ok(new
            {
                Player = new
                {
                    Id = allPlayer.Player.Id,
                    Login = allPlayer.Player.Login
                },
                Persons = allPlayer.Persons.Select(p => new
                {
                    Id = p.Id,
                    Name = p.Name,
                    PlayerId = p.PlayerId
                })
            });
        }
    }
}
