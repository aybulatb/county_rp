using CountyRP.Services.Game.API.Converters;
using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly IGameRepository _gameRepository;

        public PlayerController(
            ILogger<PlayerController> logger,
            IGameRepository gameRepository
        )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiPlayerDtoOut), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromBody] ApiPlayerDtoIn apiPlayerDtoIn
        )
        {
            if (apiPlayerDtoIn.Login == null || apiPlayerDtoIn.Login.Length < 3 || apiPlayerDtoIn.Login.Length > 32)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.PlayerInvalidLoginLength,
                        message: ConstantMessages.PlayerInvalidLoginLength
                    )
                );
            }
            if (!Regex.IsMatch(apiPlayerDtoIn.Login, @"^([0-9a-zA-Z]{3,32}|[0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31}|[0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31})$"))
            {
                return BadRequest(
                    ConstantMessages.PlayerInvalidLogin
                );
            }
            if (apiPlayerDtoIn.Password == null || apiPlayerDtoIn.Password.Length < 8 || apiPlayerDtoIn.Password.Length > 64)
            {
                return BadRequest(
                    ConstantMessages.PlayerInvalidPasswordLength
                );
            }
            if (!Regex.IsMatch(apiPlayerDtoIn.Password, @"^[0-9a-zA-Z!@#№$%^&?*()\-=\[\]{}~`]{8,64}$"))
            {
                return BadRequest(
                    ConstantMessages.PlayerInvalidPassword
                );
            }

            var existedPlayers = await _gameRepository.GetPlayersByFilter(
                PlayerLoginConverter.ToPlayerFilterDtoIn(apiPlayerDtoIn.Login)
            );

            if (existedPlayers.AllCount != 0)
            {
                return BadRequest(
                    string.Format(
                        ConstantMessages.PlayerAlreadyExistedWithLogin,
                        apiPlayerDtoIn.Login
                    )
                );
            }

            var playerDtoIn = ApiPlayerDtoInConverter.ToRepository(apiPlayerDtoIn);

            var playerDtoOut = await _gameRepository.AddPlayerAsync(playerDtoIn);

            return Created(
                string.Empty,
                PlayerDtoOutConverter.ToApi(playerDtoOut)
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiPlayerDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var filteredPlayers = await _gameRepository.GetPlayersByFilter(
                PlayerIdConverter.ToPlayerFilterDtoIn(id)
            );

            if (!filteredPlayers.Items.Any())
            {
                return NotFound(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.PlayerNotFoundById,
                        message: string.Format(
                            ConstantMessages.PlayerNotFoundById,
                            id
                        )
                    )
                );
            }

            var player = filteredPlayers.Items.First();

            return Ok(
                PlayerDtoOutConverter.ToApi(player)
            );
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(ApiPagedFilterResultDtoOut<ApiPlayerDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterBy(
            [FromQuery] ApiPlayerFilterDtoIn apiPlayerFilterDtoIn
        )
        {
            if (apiPlayerFilterDtoIn.Count.HasValue && apiPlayerFilterDtoIn.Count < 1)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidCountItemPerPage,
                        message: ConstantMessages.InvalidCountItemPerPage
                    )
                );
            }
            if (apiPlayerFilterDtoIn.Page.HasValue && apiPlayerFilterDtoIn.Page < 1)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidPageNumber,
                        message: ConstantMessages.InvalidPageNumber
                    )
                );
            }

            var filter = ApiPlayerFilterDtoInConverter.ToRepository(apiPlayerFilterDtoIn);

            var players = await _gameRepository.GetPlayersByFilter(filter);

            return Ok(
                PagedFilterResultDtoOutConverter.ToApi(players)
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiPlayerDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(
            int id,
            ApiEditedPlayerDtoIn apiEditedPlayerDtoIn
        )
        {
            var filteredPlayers = await _gameRepository.GetPlayersByFilter(
                PlayerIdConverter.ToPlayerFilterDtoIn(id)
            );

            if (filteredPlayers.AllCount == 0)
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.PlayerNotFoundById,
                        id
                    )
                );
            }

            var currentPlayer = filteredPlayers.Items.First();

            if (currentPlayer.Login != apiEditedPlayerDtoIn.Login)
            {
                if (apiEditedPlayerDtoIn.Login == null || apiEditedPlayerDtoIn.Login.Length < 3 || apiEditedPlayerDtoIn.Login.Length > 32)
                {
                    return BadRequest(
                        ConstantMessages.PlayerInvalidLoginLength
                    );
                }
                if (!Regex.IsMatch(apiEditedPlayerDtoIn.Login, @"^([0-9a-zA-Z]{3,32}|[0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31}|[0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31})$"))
                {
                    return BadRequest(
                        ConstantMessages.PlayerInvalidLogin
                    );
                }

                var existedPlayersWithNewLogin = await _gameRepository.GetPlayersByFilter(
                    PlayerLoginConverter.ToPlayerFilterDtoIn(apiEditedPlayerDtoIn.Login)
                );

                if (existedPlayersWithNewLogin.AllCount != 0)
                {
                    return BadRequest(
                        string.Format(
                            ConstantMessages.PlayerAlreadyExistedWithLogin,
                            apiEditedPlayerDtoIn.Login
                        )
                    );
                }
            }
            if (currentPlayer.Password != apiEditedPlayerDtoIn.Password)
            {
                if (apiEditedPlayerDtoIn.Password == null || apiEditedPlayerDtoIn.Password.Length < 8 || apiEditedPlayerDtoIn.Password.Length > 64)
                {
                    return BadRequest(
                        ConstantMessages.PlayerInvalidPasswordLength
                    );
                }
                if (!Regex.IsMatch(apiEditedPlayerDtoIn.Password, @"^[0-9a-zA-Z!@#№$%^&?*()\-=\[\]{}~`]{8,64}$"))
                {
                    return BadRequest(
                        ConstantMessages.PlayerInvalidPassword
                    );
                }
            }

            var editedPlayerDtoIn = ApiEditedPlayerDtoInConverter.ToRepository(
                source: apiEditedPlayerDtoIn,
                id: id
            );

            var playerDtoOut = await _gameRepository.UpdatePlayerAsync(editedPlayerDtoIn);

            return Ok(
                PlayerDtoOutConverter.ToApi(playerDtoOut)
            );
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var filterForPlayer = PlayerIdConverter.ToPlayerFilterDtoIn(id);

            var filteredPlayers = await _gameRepository.GetPlayersByFilter(filterForPlayer);

            if (!filteredPlayers.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.PlayerNotFoundById,
                        id
                    )
                );
            }

            await _gameRepository.DeletePlayerByFilter(filterForPlayer);

            var filterForPersons = PlayerIdConverter.ToPersonFilterDtoIn(id);

            await _gameRepository.DeletePersonByFilter(filterForPersons);

            return NoContent();
        }
    }
}
