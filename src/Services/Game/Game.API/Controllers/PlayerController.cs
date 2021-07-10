using CountyRP.Services.Game.API.Converters;
using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private IGameRepository _gameRepository;

        public PlayerController(
            IGameRepository gameRepository
        )
        {
            _gameRepository = gameRepository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiPlayerDtoOut), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
            [FromBody] ApiPlayerDtoIn apiPlayerDtoIn
        )
        {
            var playerDtoIn = ApiPlayerDtoInConverter.ToRepository(apiPlayerDtoIn);

            var playerDtoOut = await _gameRepository.AddPlayerAsync(playerDtoIn);

            return Created(
                string.Empty,
                PlayerDtoOutConverter.ToApi(playerDtoOut)
            );
        }
    }
}
