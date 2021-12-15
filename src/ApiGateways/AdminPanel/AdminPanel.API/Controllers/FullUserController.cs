using CountyRP.ApiGateways.AdminPanel.API.Converters;
using CountyRP.ApiGateways.AdminPanel.API.Converters.FullUser;
using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Interfaces;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Interfaces;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FullUserController : ControllerBase
    {
        private readonly ILogger<FullUserController> _logger;
        private readonly ISiteService _siteService;
        private readonly IGameService _gameService;
        private readonly IForumService _forumService;

        public FullUserController(
            ILogger<FullUserController> logger,
            ISiteService siteService,
            IGameService gameService,
            IForumService forumService
        )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _siteService = siteService ?? throw new ArgumentNullException(nameof(siteService));
            _gameService = gameService ?? throw new ArgumentNullException(nameof(gameService));
            _forumService = forumService ?? throw new ArgumentNullException(nameof(forumService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _siteService.GetUserByIdAsync(id);

            var playerWithPersons = await _gameService.GetPlayerWithPersonsByPlayerIdAsync(user.PlayerId);

            return Ok(
                GamePlayerWithPersonsDtoOutConverter.ToApiFullUserDtoOutApi(
                    source: playerWithPersons,
                    user: user
                )
            );
        }

        [HttpGet("ShortFilterBy")]
        public async Task<IActionResult> GetByShortFilter([FromQuery] ApiFullUserFilterDtoIn apiFullUserFilterDtoIn)
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
                .Join(
                    users.Items,
                    p => p.Id,
                    u => u.PlayerId,
                    (p, u) =>
                        GamePlayerWithPersonsDtoOutConverter.ToApiFullUserDtoOutApi(
                            source: p,
                            user: u
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
        public async Task<IActionResult> Update(int id, [FromBody] ApiUpdatedFullUserDtoIn apiUpdatedFullUserDtoIn)
        {
            var user = await _siteService.GetUserByIdAsync(id);

            var playerWithPersons = await _gameService.GetPlayerWithPersonsByPlayerIdAsync(user.PlayerId);

            var allPersonsExist = apiUpdatedFullUserDtoIn
                .Persons
                .All(updatedPerson => playerWithPersons.Persons.Any(person => person.Id == updatedPerson.Id));

            if (!allPersonsExist)
            {
                return BadRequest();
            }

            var updatedSiteUserDtoIn = ApiUpdatedFullUserDtoInConverter.ToSiteService(
                source: apiUpdatedFullUserDtoIn,
                user: user
            );

            await _siteService.UpdateUserAsync(updatedSiteUserDtoIn);

            var updatedFullUserDtoIn = ApiUpdatedFullUserDtoInConverter.ToGameService(apiUpdatedFullUserDtoIn);

            await _gameService.UpdatePlayerAsync(id, updatedFullUserDtoIn);

            var editedPersonsDtoIn = apiUpdatedFullUserDtoIn
                .Persons
                .Select(person =>
                    ApiUpdatedFullUserPersonDtoInConverter.ToService(
                        source: person,
                        playerId: id
                    )
                );

            await _gameService.UpdatePersonsAsync(editedPersonsDtoIn);

            return null;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var siteUser = await _siteService.GetUserByIdAsync(id);

            await _siteService.DeleteUserAsync(id);
            await _gameService.DeletePlayerAsync(siteUser.PlayerId);
            await _forumService.DeleteUserAsync(siteUser.ForumUserId);

            return NoContent();
        }
    }
}
