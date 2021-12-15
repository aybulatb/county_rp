using CountyRP.Services.Game.API.Converters;
using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;
using CountyRP.Services.Game.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppearanceController : ControllerBase
    {
        private readonly ILogger<AppearanceController> _logger;
        private readonly IGameRepository _gameRepository;

        public AppearanceController(
            ILogger<AppearanceController> logger,
            IGameRepository gameRepository
        )
        {
            _logger = logger;
            _gameRepository = gameRepository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiAppearanceDtoOut), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromBody] ApiAppearanceDtoIn apiAppearanceDtoIn
        )
        {
            var appearanceDtoIn = ApiAppearanceDtoInConverter.ToRepository(apiAppearanceDtoIn);

            var appearanceDtoOut = await _gameRepository.AddAppearanceAsync(appearanceDtoIn);

            return Created(
                string.Empty,
                AppearanceDtoOutConverter.ToApi(appearanceDtoOut)
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AppearanceDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            int id
        )
        {
            var filteredAppearances = await _gameRepository.GetAppearancesByFilter(
                AppearanceIdConverter.ToAppearanceFilterDtoIn(id)
            );

            if (!filteredAppearances.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.AppearanceNotFoundById,
                        id
                    )
                );
            }

            var appearance = filteredAppearances.Items.First();

            return Ok(
                AppearanceDtoOutConverter.ToApi(appearance)
            );
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(ApiPagedFilterResultDtoOut<ApiAppearanceDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterBy(
            [FromQuery] ApiAppearanceFilterDtoIn apiAppearanceFilterDtoIn
        )
        {
            if (apiAppearanceFilterDtoIn.Count < 1)
            {
                return BadRequest(
                    ConstantMessages.InvalidCountItemPerPage
                );
            }
            if (apiAppearanceFilterDtoIn.Page < 1)
            {
                return BadRequest(
                    ConstantMessages.InvalidPageNumber
                );
            }

            var filter = ApiAppearanceFilterDtoInConverter.ToRepository(apiAppearanceFilterDtoIn);

            var appearances = await _gameRepository.GetAppearancesByFilter(filter);

            return Ok(
                PagedFilterResultDtoOutConverter.ToApi(appearances)
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiAppearanceDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(
            int id,
            ApiAppearanceDtoIn apiAppearanceDtoIn
        )
        {
            var filteredAppearances = await _gameRepository.GetAppearancesByFilter(
                AppearanceIdConverter.ToAppearanceFilterDtoIn(id)
            );

            if (filteredAppearances.AllCount == 0)
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.AppearanceNotFoundById,
                        id
                    )
                );
            }

            var appearanceDtoOut = ApiAppearanceDtoInConverter.ToDtoOutRepository(
                source: apiAppearanceDtoIn,
                id: id
            );

            var updatedAppearanceDtoOut = await _gameRepository.UpdateAppearanceAsync(appearanceDtoOut);

            return Ok(
                AppearanceDtoOutConverter.ToApi(updatedAppearanceDtoOut)
            );
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var filter = AppearanceIdConverter.ToAppearanceFilterDtoIn(id);

            var filteredAppearances = await _gameRepository.GetAppearancesByFilter(filter);

            if (!filteredAppearances.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.AppearanceNotFoundById,
                        id
                    )
                );
            }

            await _gameRepository.DeleteAppearanceByFilter(filter);

            return Ok();
        }
    }
}
