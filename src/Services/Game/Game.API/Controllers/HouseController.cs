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
    public class HouseController : ControllerBase
    {
        private readonly ILogger<HouseController> _logger;
        private readonly IGameRepository _gameRepository;

        public HouseController(
            ILogger<HouseController> logger,
            IGameRepository gameRepository
        )
        {
            _logger = logger;
            _gameRepository = gameRepository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiHouseDtoOut), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromBody] ApiHouseDtoIn apiHouseDtoIn
        )
        {
            //var validatedResult = await ValidateInputCreatedOrEditedData(apiAtmDtoIn);
            //if (validatedResult != null)
            //{
            //    return validatedResult;
            //}

            var houseDtoIn = ApiHouseDtoInConverter.ToRepository(apiHouseDtoIn);

            var houseDtoOut = await _gameRepository.AddHouseAsync(houseDtoIn);

            return Created(
                string.Empty,
                HouseDtoOutConverter.ToApi(houseDtoOut)
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(HouseDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            int id
        )
        {
            var filteredHouses = await _gameRepository.GetHousesByFilter(
                HouseIdConverter.ToHouseFilterDtoIn(id)
            );

            if (!filteredHouses.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.HouseNotFoundById,
                        id
                    )
                );
            }

            var house = filteredHouses.Items.First();

            return Ok(
                HouseDtoOutConverter.ToApi(house)
            );
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(ApiPagedFilterResultDtoOut<ApiHouseDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterBy(
            [FromQuery] ApiHouseFilterDtoIn apiHouseFilterDtoIn
        )
        {
            if (apiHouseFilterDtoIn.Count < 1)
            {
                return BadRequest(
                    ConstantMessages.InvalidCountItemPerPage
                );
            }
            if (apiHouseFilterDtoIn.Page < 1)
            {
                return BadRequest(
                    ConstantMessages.InvalidPageNumber
                );
            }

            var filter = ApiHouseFilterDtoInConverter.ToRepository(apiHouseFilterDtoIn);

            var houses = await _gameRepository.GetHousesByFilter(filter);

            return Ok(
                PagedFilterResultDtoOutConverter.ToApi(houses)
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiHouseDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(
            int id,
            ApiHouseDtoIn apiHouseDtoIn
        )
        {
            var filteredHouses = await _gameRepository.GetHousesByFilter(
                HouseIdConverter.ToHouseFilterDtoIn(id)
            );

            if (filteredHouses.AllCount == 0)
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.HouseNotFoundById,
                        id
                    )
                );
            }

            //var validatedResult = await ValidateInputCreatedOrEditedData(apiAtmDtoIn);
            //if (validatedResult != null)
            //{
            //    return validatedResult;
            //}

            var houseDtoOut = ApiHouseDtoInConverter.ToDtoOutRepository(
                source: apiHouseDtoIn,
                id: id
            );

            var updatedHouseDtoOut = await _gameRepository.UpdateHouseAsync(houseDtoOut);

            return Ok(
                HouseDtoOutConverter.ToApi(updatedHouseDtoOut)
            );
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var filter = HouseIdConverter.ToHouseFilterDtoIn(id);

            var filteredHouses = await _gameRepository.GetHousesByFilter(filter);

            if (!filteredHouses.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.HouseNotFoundById,
                        id
                    )
                );
            }

            await _gameRepository.DeleteHouseByFilter(filter);

            return Ok();
        }
    }
}
