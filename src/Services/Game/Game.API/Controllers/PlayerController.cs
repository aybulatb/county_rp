using CountyRP.Services.Game.API.Converters;
using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;
using CountyRP.Services.Game.Infrastructure.Repositories;
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
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromBody] ApiPlayerDtoIn apiPlayerDtoIn
        )
        {
            if (apiPlayerDtoIn.Login == null || apiPlayerDtoIn.Login.Length < 3 || apiPlayerDtoIn.Login.Length > 32)
            {
                return BadRequest(
                    ConstantMessages.PlayerInvalidLoginLength
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
                new PlayerFilterDtoIn(
                    count: 1,
                    page: 1,
                    ids: null,
                    logins: new[] { apiPlayerDtoIn.Login },
                    startRegistrationDate: null,
                    finishRegistrationDate: null,
                    startLastVisitDate: null,
                    finishLastVisitDate: null
                )
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
        [ProducesResponseType(typeof(PlayerDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var filteredPlayers = await _gameRepository.GetPlayersByFilter(
                new PlayerFilterDtoIn(
                    count: 1,
                    page: 1,
                    ids: new[] { id },
                    logins: null,
                    startRegistrationDate: null,
                    finishRegistrationDate: null,
                    startLastVisitDate: null,
                    finishLastVisitDate: null
                )
            );

            if (!filteredPlayers.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.PlayerNotFoundById,
                        id
                    )
                );
            }

            var player = filteredPlayers.Items.First();

            return Ok(
                PlayerDtoOutConverter.ToApi(player)
            );
        }

        [HttpGet("FilterBy")]
        public async Task<IActionResult> FilterBy(
            [FromQuery] ApiPlayerFilterDtoIn apiPlayerFilterDtoIn
        )
        {
            var filter = ApiPlayerFilterDtoInConverter.ToRepository(apiPlayerFilterDtoIn);

            var players = await _gameRepository.GetPlayersByFilter(filter);

            return Ok(
                PagedFilterResultDtoOutConverter.ToApi(players)
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PlayerDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(
            int id,
            ApiEditedPlayerDtoIn apiEditedPlayerDtoIn
        )
        {
            var filteredPlayers = await _gameRepository.GetPlayersByFilter(
                new PlayerFilterDtoIn(
                    count: 1,
                    page: 1,
                    ids: new[] { id },
                    logins: null,
                    startRegistrationDate: null,
                    finishRegistrationDate: null,
                    startLastVisitDate: null,
                    finishLastVisitDate: null
                )
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
                    new PlayerFilterDtoIn(
                        count: 1,
                        page: 1,
                        ids: null,
                        logins: new[] { apiEditedPlayerDtoIn.Login },
                        startRegistrationDate: null,
                        finishRegistrationDate: null,
                        startLastVisitDate: null,
                        finishLastVisitDate: null
                    )
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
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var filter = new PlayerFilterDtoIn(
                count: 1,
                page: 1,
                ids: new[] { id },
                logins: null,
                startRegistrationDate: null,
                finishRegistrationDate: null,
                startLastVisitDate: null,
                finishLastVisitDate: null
            );

            var filteredPlayers = await _gameRepository.GetPlayersByFilter(filter);

            if (!filteredPlayers.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.PlayerNotFoundById,
                        id
                    )
                );
            }

            await _gameRepository.DeletePlayerByFilter(filter);

            return Ok();
        }
    }
}
