using CountyRP.Services.Game.API.Converters;
using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerWithPersonsController : ControllerBase
    {
        private readonly ILogger<PlayerWithPersonsController> _logger;
        private readonly IGameRepository _gameRepository;

        public PlayerWithPersonsController(
            ILogger<PlayerWithPersonsController> logger,
            IGameRepository gameRepository
        )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
        }

        [HttpGet("{playerId}")]
        [ProducesResponseType(typeof(ApiPlayerWithPersonsDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int playerId)
        {
            var playerFilterDtoIn = PlayerIdConverter.ToPlayerFilterDtoIn(playerId);

            var filteredPlayers = await _gameRepository.GetPlayersByFilter(
                playerFilterDtoIn
            );

            if (!filteredPlayers.Items.Any())
            {
                return NotFound(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.PlayerNotFoundById,
                        message: string.Format(
                            ConstantMessages.PlayerNotFoundById,
                            playerId
                        )
                    )
                );
            }

            var player = filteredPlayers.Items.First();

            var personFilterDtoIn = PlayerIdConverter.ToPersonFilterDtoIn(player.Id);

            var filteredPersons = await _gameRepository.GetPersonsByFilter(personFilterDtoIn);

            return Ok(
                PlayerDtoOutConverter.ToApi(
                    source: player,
                    persons: filteredPersons.Items
                )
            );
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(ApiPagedFilterResultDtoOut<ApiPlayerWithPersonsDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterBy(
            [FromQuery] ApiPlayerWithPersonsFilterDtoIn apiPlayerWithPersonsFilterDtoIn
        )
        {
            if (apiPlayerWithPersonsFilterDtoIn.Count.HasValue && apiPlayerWithPersonsFilterDtoIn.Count < 1)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidCountItemPerPage,
                        message: ConstantMessages.InvalidCountItemPerPage
                    )
                );
            }
            if (apiPlayerWithPersonsFilterDtoIn.Page.HasValue && apiPlayerWithPersonsFilterDtoIn.Page < 1)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidPageNumber,
                        message: ConstantMessages.InvalidPageNumber
                    )
                );
            }

            var personFilter = ApiPlayerWithPersonsFilterDtoInConverter.ToPersonFilterRepository(apiPlayerWithPersonsFilterDtoIn);

            var persons = await _gameRepository.GetPersonsByFilter(personFilter);

            var playerIdsFromFilteredPersons = persons
                .Items
                .Select(person => person.PlayerId)
                .Distinct();

            var personFilterWithPlayerIds = PlayerIdsConverter.ToPersonFilterWithPlayerIdsRepository(
                source: playerIdsFromFilteredPersons
            );

            var allPersonsByPlayerIds = await _gameRepository.GetPersonsByFilter(personFilterWithPlayerIds);

            var playerIdsFromAllFilteredPersons = persons
                .Items
                .Select(person => person.PlayerId)
                .Distinct();

            var apiPlayerWithPersonsAndPlayerIdsFilterDtoIn = apiPlayerWithPersonsFilterDtoIn with
            {
                Ids = playerIdsFromAllFilteredPersons
                    .Union(apiPlayerWithPersonsFilterDtoIn.Ids ?? new int[] { })
            };

            var playerFilter = ApiPlayerWithPersonsFilterDtoInConverter.ToPlayerFilterRepository(apiPlayerWithPersonsAndPlayerIdsFilterDtoIn);

            var players = await _gameRepository.GetPlayersByFilter(playerFilter);

            return Ok(
                PagedFilterResultDtoOutConverter.ToApi(
                    source: players,
                    persons: allPersonsByPlayerIds.Items
                )
            );
        }
    }
}
