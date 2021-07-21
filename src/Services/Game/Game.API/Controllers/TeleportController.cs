using CountyRP.Services.Game.API.Converters;
using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;
using CountyRP.Services.Game.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeleportController : ControllerBase
    {
        private readonly ILogger<TeleportController> _logger;
        private readonly IGameRepository _gameRepository;

        public TeleportController(
            ILogger<TeleportController> logger,
            IGameRepository gameRepository
        )
        {
            _logger = logger;
            _gameRepository = gameRepository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiTeleportDtoOut), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
            [FromBody] ApiTeleportDtoIn apiTeleportDtoIn
        )
        {
            var teleportDtoIn = ApiTeleportDtoInConverter.ToRepository(apiTeleportDtoIn);

            var teleportDtoOut = await _gameRepository.AddTeleportAsync(teleportDtoIn);

            return Created(
                string.Empty,
                TeleportDtoOutConverter.ToApi(teleportDtoOut)
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TeleportDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            int id
        )
        {
            var filteredTeleports = await _gameRepository.GetTeleportsByFilter(
                new TeleportFilterDtoIn(
                    count: 1,
                    page: 1,
                    ids: new[] { id },
                    name: null,
                    nameLike: null,
                    factionIds: null,
                    gangIds: null,
                    roomIds: null,
                    businessIds: null
                )
            );

            if (!filteredTeleports.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.TeleportNotFoundById,
                        id
                    )
                );
            }

            var teleport = filteredTeleports.Items.First();

            return Ok(
                TeleportDtoOutConverter.ToApi(teleport)
            );
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(ApiPagedFilterResultDtoOut<ApiTeleportDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterBy(
            [FromQuery] ApiTeleportFilterDtoIn apiTeleportFilterDtoIn
        )
        {
            if (apiTeleportFilterDtoIn.Count < 1)
            {
                return BadRequest(
                    ConstantMessages.InvalidCountItemPerPage
                );
            }
            if (apiTeleportFilterDtoIn.Page < 1)
            {
                return BadRequest(
                    ConstantMessages.InvalidPageNumber
                );
            }

            var filter = ApiTeleportFilterDtoInConverter.ToRepository(apiTeleportFilterDtoIn);

            var teleports = await _gameRepository.GetTeleportsByFilter(filter);

            return Ok(
                PagedFilterResultDtoOutConverter.ToApi(teleports)
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiTeleportDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(
            int id,
            ApiTeleportDtoIn apiTeleportDtoIn
        )
        {
            var filteredTeleports = await _gameRepository.GetTeleportsByFilter(
                new TeleportFilterDtoIn(
                    count: 1,
                    page: 1,
                    ids: new[] { id },
                    name: null,
                    nameLike: null,
                    factionIds: null,
                    gangIds: null,
                    roomIds: null,
                    businessIds: null
                )
            );

            if (filteredTeleports.AllCount == 0)
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.TeleportNotFoundById,
                        id
                    )
                );
            }

            var teleportDtoOut = ApiTeleportDtoInConverter.ToDtoOutRepository(
                source: apiTeleportDtoIn,
                id: id
            );

            var updatedTeleportDtoOut = await _gameRepository.UpdateTeleportAsync(teleportDtoOut);

            return Ok(
                TeleportDtoOutConverter.ToApi(updatedTeleportDtoOut)
            );
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var filter = new TeleportFilterDtoIn(
                count: 1,
                page: 1,
                ids: new[] { id },
                name: null,
                nameLike: null,
                factionIds: null,
                gangIds: null,
                roomIds: null,
                businessIds: null
            );

            var filteredTeleports = await _gameRepository.GetTeleportsByFilter(filter);

            if (!filteredTeleports.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.TeleportNotFoundById,
                        id
                    )
                );
            }

            await _gameRepository.DeleteTeleportByFilter(filter);

            return Ok();
        }
    }
}
