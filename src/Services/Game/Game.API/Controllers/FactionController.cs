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
    public class FactionController : ControllerBase
    {
        private readonly ILogger<FactionController> _logger;
        private readonly IGameRepository _gameRepository;

        public FactionController(
            ILogger<FactionController> logger,
            IGameRepository gameRepository
        )
        {
            _logger = logger;
            _gameRepository = gameRepository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiFactionDtoOut), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
            [FromBody] ApiFactionDtoIn apiFactionDtoIn
        )
        {
            var factionDtoIn = ApiFactionDtoInConverter.ToRepository(apiFactionDtoIn);

            var factionDtoOut = await _gameRepository.AddFactionAsync(factionDtoIn);

            return Created(
                string.Empty,
                FactionDtoOutConverter.ToApi(factionDtoOut)
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FactionDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            string id
        )
        {
            var filteredFactions = await _gameRepository.GetFactionsByFilter(
                new FactionFilterDtoIn(
                    count: 1,
                    page: 1,
                    ids: new[] { id },
                    idLike: null,
                    names: null,
                    nameLike: null,
                    types: null
                )
            );

            if (!filteredFactions.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.FactionNotFoundById,
                        id
                    )
                );
            }

            var faction = filteredFactions.Items.First();

            return Ok(
                FactionDtoOutConverter.ToApi(faction)
            );
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(ApiPagedFilterResultDtoOut<ApiFactionDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterBy(
            [FromQuery] ApiFactionFilterDtoIn apiFactionFilterDtoIn
        )
        {
            if (apiFactionFilterDtoIn.Count < 1)
            {
                return BadRequest(
                    ConstantMessages.InvalidCountItemPerPage
                );
            }
            if (apiFactionFilterDtoIn.Page < 1)
            {
                return BadRequest(
                    ConstantMessages.InvalidPageNumber
                );
            }

            var filter = ApiFactionFilterDtoInConverter.ToRepository(apiFactionFilterDtoIn);

            var factions = await _gameRepository.GetFactionsByFilter(filter);

            return Ok(
                PagedFilterResultDtoOutConverter.ToApi(factions)
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiFactionDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(
            string id,
            ApiFactionDtoIn apiFactionDtoIn
        )
        {
            var filteredFactions = await _gameRepository.GetFactionsByFilter(
                new FactionFilterDtoIn(
                    count: 1,
                    page: 1,
                    ids: new[] { id },
                    idLike: null,
                    names: null,
                    nameLike: null,
                    types: null
                )
            );

            if (filteredFactions.AllCount == 0)
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.FactionNotFoundById,
                        id
                    )
                );
            }

            var factionDtoOut = ApiFactionDtoInConverter.ToDtoOutRepository(
                source: apiFactionDtoIn,
                id: id
            );

            var updatedFactionDtoOut = await _gameRepository.UpdateFactionAsync(factionDtoOut);

            return Ok(
                FactionDtoOutConverter.ToApi(updatedFactionDtoOut)
            );
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            var filter = new FactionFilterDtoIn(
                count: 1,
                page: 1,
                ids: new[] { id },
                idLike: null,
                names: null,
                nameLike: null,
                types: null
            );

            var filteredFactions = await _gameRepository.GetFactionsByFilter(filter);

            if (!filteredFactions.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.FactionNotFoundById,
                        id
                    )
                );
            }

            await _gameRepository.DeleteFactionByFilter(filter);

            return Ok();
        }
    }
}
