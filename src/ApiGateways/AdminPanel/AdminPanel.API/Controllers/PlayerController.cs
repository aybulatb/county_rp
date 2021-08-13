using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
            _gameService = gameService ?? throw new ArgumentNullException(nameof(_gameService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var playerDtoOut = await _gameService.GetPlayerByIdAsync(id);

            return Ok(playerDtoOut);
        }
    }
}
