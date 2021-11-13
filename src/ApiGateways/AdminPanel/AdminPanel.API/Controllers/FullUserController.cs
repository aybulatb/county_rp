using CountyRP.ApiGateways.AdminPanel.API.Converters;
using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Interfaces;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Interfaces;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.API.Controllers
{
    public class FullUserController : ControllerBase
    {
        private readonly ILogger<FullUserController> _logger;
        private readonly ISiteService _siteService;
        private readonly IGameService _gameService;

        public FullUserController(
            ILogger<FullUserController> logger,
            ISiteService siteService,
            IGameService gameService
        )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _siteService = siteService ?? throw new ArgumentNullException(nameof(siteService));
            _gameService = gameService ?? throw new ArgumentNullException(nameof(gameService));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return null;
        }

        [HttpGet("ShortFilterBy")]
        public async Task<IActionResult> GetByShortFilter(ApiFullUserFilterDtoIn apiFullUserFilterDtoIn)
        {
            var userFilter = ApiFullUserFilterDtoInConverter.ToUserService(apiFullUserFilterDtoIn);

            var users = await _siteService.GetUsersByFilterAsync(userFilter);

            var playerWithPersonsFilter = ApiFullUserFilterDtoInConverter.ToGameService(
                source: apiFullUserFilterDtoIn,
                playerIds: users.Items
                    .Select(user => user.PlayerId)
            );

            var playerWithPersons = await _gameService.GetPlayersWithPersonsByFilterAsync(playerWithPersonsFilter);

            var fullUsers = playerWithPersons
                .Items
                .Select(playerWithPersons =>
                    GamePlayerWithPersonsDtoOutConverter.ToApiFullUserDtoOutApi(
                        source: playerWithPersons,
                        user: users.Items.First(user => user.PlayerId == playerWithPersons.Id)
                    )
                );

            return Ok(
                new ApiPagedFilterResultDtoOut<ApiFullUserDtoOut>(
                    allCount: playerWithPersons.AllCount,
                    page: playerWithPersons.Page,
                    maxPages: playerWithPersons.MaxPages,
                    items: fullUsers
                )
            );
        }

        [HttpPost]
        public IActionResult Create()
        {
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            return null;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return null;
        }
    }
}
