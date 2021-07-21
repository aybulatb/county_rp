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
    public class GarageController : ControllerBase
    {
        private readonly ILogger<GarageController> _logger;
        private readonly IGameRepository _gameRepository;

        public GarageController(
            ILogger<GarageController> logger,
            IGameRepository gameRepository
        )
        {
            _logger = logger;
            _gameRepository = gameRepository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiGarageDtoOut), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
            [FromBody] ApiGarageDtoIn apiGarageDtoIn
        )
        {
            var garageDtoIn = ApiGarageDtoInConverter.ToRepository(apiGarageDtoIn);

            var garageDtoOut = await _gameRepository.AddGarageAsync(garageDtoIn);

            return Created(
                string.Empty,
                GarageDtoOutConverter.ToApi(garageDtoOut)
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GarageDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            int id
        )
        {
            var filteredGarages = await _gameRepository.GetGaragesByFilter(
                new GarageFilterDtoIn(
                    count: 1,
                    page: 1,
                    ids: new[] { id }
                )
            );

            if (!filteredGarages.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.GarageNotFoundById,
                        id
                    )
                );
            }

            var garage = filteredGarages.Items.First();

            return Ok(
                GarageDtoOutConverter.ToApi(garage)
            );
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(ApiPagedFilterResultDtoOut<ApiGarageDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterBy(
            [FromQuery] ApiGarageFilterDtoIn apiGarageFilterDtoIn
        )
        {
            if (apiGarageFilterDtoIn.Count < 1)
            {
                return BadRequest(
                    ConstantMessages.InvalidCountItemPerPage
                );
            }
            if (apiGarageFilterDtoIn.Page < 1)
            {
                return BadRequest(
                    ConstantMessages.InvalidPageNumber
                );
            }

            var filter = ApiGarageFilterDtoInConverter.ToRepository(apiGarageFilterDtoIn);

            var garages = await _gameRepository.GetGaragesByFilter(filter);

            return Ok(
                PagedFilterResultDtoOutConverter.ToApi(garages)
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiGarageDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(
            int id,
            ApiGarageDtoIn apiGarageDtoIn
        )
        {
            var filteredGarages = await _gameRepository.GetGaragesByFilter(
                new GarageFilterDtoIn(
                    count: 1,
                    page: 1,
                    ids: new[] { id }
                )
            );

            if (filteredGarages.AllCount == 0)
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.GarageNotFoundById,
                        id
                    )
                );
            }

            var garageDtoOut = ApiGarageDtoInConverter.ToDtoOutRepository(
                source: apiGarageDtoIn,
                id: id
            );

            var updatedGarageDtoOut = await _gameRepository.UpdateGarageAsync(garageDtoOut);

            return Ok(
                GarageDtoOutConverter.ToApi(updatedGarageDtoOut)
            );
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var filter = new GarageFilterDtoIn(
                count: 1,
                page: 1,
                ids: new[] { id }
            );

            var filteredGarages = await _gameRepository.GetGaragesByFilter(filter);

            if (!filteredGarages.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.GarageNotFoundById,
                        id
                    )
                );
            }

            await _gameRepository.DeleteGarageByFilter(filter);

            return Ok();
        }
    }
}
