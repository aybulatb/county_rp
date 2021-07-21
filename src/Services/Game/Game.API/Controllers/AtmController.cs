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
    public class AtmController : ControllerBase
    {
        private readonly ILogger<AtmController> _logger;
        private readonly IGameRepository _gameRepository;

        public AtmController(
            ILogger<AtmController> logger,
            IGameRepository gameRepository
        )
        {
            _logger = logger;
            _gameRepository = gameRepository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiAtmDtoOut), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
            [FromBody] ApiAtmDtoIn apiAtmDtoIn
        )
        {
            var atmDtoIn = ApiAtmDtoInConverter.ToRepository(apiAtmDtoIn);

            var atmDtoOut = await _gameRepository.AddAtmAsync(atmDtoIn);

            return Created(
                string.Empty,
                AtmDtoOutConverter.ToApi(atmDtoOut)
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AtmDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            int id
        )
        {
            var filteredAtms = await _gameRepository.GetAtmsByFilter(
                new AtmFilterDtoIn(
                    count: 1,
                    page: 1,
                    ids: new[] { id },
                    businessIds: null
                )
            );

            if (!filteredAtms.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.AtmNotFoundById,
                        id
                    )
                );
            }

            var atm = filteredAtms.Items.First();

            return Ok(
                AtmDtoOutConverter.ToApi(atm)
            );
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(ApiPagedFilterResultDtoOut<ApiAtmDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterBy(
            [FromQuery] ApiAtmFilterDtoIn apiAtmFilterDtoIn
        )
        {
            if (apiAtmFilterDtoIn.Count < 1)
            {
                return BadRequest(
                    ConstantMessages.InvalidCountItemPerPage
                );
            }
            if (apiAtmFilterDtoIn.Page < 1)
            {
                return BadRequest(
                    ConstantMessages.InvalidPageNumber
                );
            }

            var filter = ApiAtmFilterDtoInConverter.ToRepository(apiAtmFilterDtoIn);

            var atms = await _gameRepository.GetAtmsByFilter(filter);

            return Ok(
                PagedFilterResultDtoOutConverter.ToApi(atms)
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiAtmDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(
            int id,
            ApiAtmDtoIn apiAtmDtoIn
        )
        {
            var filteredAtms = await _gameRepository.GetAtmsByFilter(
                new AtmFilterDtoIn(
                    count: 1,
                    page: 1,
                    ids: new[] { id },
                    businessIds: null
                )
            );

            if (filteredAtms.AllCount == 0)
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.AtmNotFoundById,
                        id
                    )
                );
            }

            var atmDtoOut = ApiAtmDtoInConverter.ToDtoOutRepository(
                source: apiAtmDtoIn,
                id: id
            );

            var updatedAtmDtoOut = await _gameRepository.UpdateAtmAsync(atmDtoOut);

            return Ok(
                AtmDtoOutConverter.ToApi(updatedAtmDtoOut)
            );
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var filter = new AtmFilterDtoIn(
                count: 1,
                page: 1,
                ids: new[] { id },
                businessIds: null
            );

            var filteredAtms = await _gameRepository.GetAtmsByFilter(filter);

            if (!filteredAtms.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.AtmNotFoundById,
                        id
                    )
                );
            }

            await _gameRepository.DeleteAtmByFilter(filter);

            return Ok();
        }
    }
}
