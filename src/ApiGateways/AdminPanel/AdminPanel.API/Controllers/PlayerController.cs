using CountyRP.ApiGateways.AdminPanel.API.Converters;
using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private ILogger<PlayerController> _logger;
        private IGameService _gameService;

        public PlayerController(
            ILogger<PlayerController> logger,
            IGameService gameService
        )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _gameService = gameService ?? throw new ArgumentNullException(nameof(gameService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var playerDtoOut = await _gameService.GetPlayerByIdAsync(id);

            return Ok(playerDtoOut);
        }

        [HttpGet("FilterBy")]
        public async Task<IActionResult> FilterBy([FromQuery] ApiPlayerFilterDtoIn apiPlayerFilterDtoIn)
        {
            var gamePlayerFilterDtoIn = ApiPlayerFilterDtoInConverter.ToGamePlayerFilterDtoInService(apiPlayerFilterDtoIn);

            var gamePagedPlayersDtoOut = await _gameService.GetPlayersByFilterAsync(gamePlayerFilterDtoIn);

            var gamePersonFilterDtoIn = ApiPlayerFilterDtoInConverter.ToGamePersonFilterDtoInService(apiPlayerFilterDtoIn);

            var gamePagedPersonsDtoOut = await _gameService.GetPersonsByFilterAsync(gamePersonFilterDtoIn);

            var mergedPlayerIds = gamePagedPersonsDtoOut.Items
                .Select(person => person.PlayerId);

            var validatedPlayers = gamePagedPlayersDtoOut.Items.Where(
                player => mergedPlayerIds.Contains(player.Id)
            );

            return Ok();
        }
    }
}
