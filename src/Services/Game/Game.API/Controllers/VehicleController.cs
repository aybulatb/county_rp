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
    public class VehicleController : ControllerBase
    {
        private readonly ILogger<VehicleController> _logger;
        private readonly IGameRepository _gameRepository;

        public VehicleController(
            ILogger<VehicleController> logger,
            IGameRepository gameRepository
        )
        {
            _logger = logger;
            _gameRepository = gameRepository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiVehicleDtoOut), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
            [FromBody] ApiVehicleDtoIn apiVehicleDtoIn
        )
        {
            var vehicleDtoIn = ApiVehicleDtoInConverter.ToRepository(apiVehicleDtoIn);

            var vehicleDtoOut = await _gameRepository.AddVehicleAsync(vehicleDtoIn);

            return Created(
                string.Empty,
                VehicleDtoOutConverter.ToApi(vehicleDtoOut)
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VehicleDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            int id
        )
        {
            var filteredVehicles = await _gameRepository.GetVehiclesByFilter(
                new VehicleFilterDtoIn(
                    count: 1,
                    page: 1,
                    ids: new[] { id },
                    models: null,
                    ownerIds: null,
                    factionIds: null,
                    licensePlate: null,
                    licensePlateLike: null
                )
            );

            if (!filteredVehicles.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.VehicleNotFoundById,
                        id
                    )
                );
            }

            var vehicle = filteredVehicles.Items.First();

            return Ok(
                VehicleDtoOutConverter.ToApi(vehicle)
            );
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(ApiPagedFilterResultDtoOut<ApiVehicleDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterBy(
            [FromQuery] ApiVehicleFilterDtoIn apiVehicleFilterDtoIn
        )
        {
            if (apiVehicleFilterDtoIn.Count < 1)
            {
                return BadRequest(
                    ConstantMessages.InvalidCountItemPerPage
                );
            }
            if (apiVehicleFilterDtoIn.Page < 1)
            {
                return BadRequest(
                    ConstantMessages.InvalidPageNumber
                );
            }

            var filter = ApiVehicleFilterDtoInConverter.ToRepository(apiVehicleFilterDtoIn);

            var vehicles = await _gameRepository.GetVehiclesByFilter(filter);

            return Ok(
                PagedFilterResultDtoOutConverter.ToApi(vehicles)
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiVehicleDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(
            int id,
            ApiVehicleDtoIn apiVehicleDtoIn
        )
        {
            var filteredVehicles = await _gameRepository.GetVehiclesByFilter(
                new VehicleFilterDtoIn(
                    count: 1,
                    page: 1,
                    ids: new[] { id },
                    models: null,
                    ownerIds: null,
                    factionIds: null,
                    licensePlate: null,
                    licensePlateLike: null
                )
            );

            if (filteredVehicles.AllCount == 0)
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.VehicleNotFoundById,
                        id
                    )
                );
            }

            var vehicleDtoOut = ApiVehicleDtoInConverter.ToDtoOut(
                source: apiVehicleDtoIn,
                id: id
            );

            var updatedVehicleDtoOut = await _gameRepository.UpdateVehicleAsync(vehicleDtoOut);

            return Ok(
                VehicleDtoOutConverter.ToApi(updatedVehicleDtoOut)
            );
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var filter = new VehicleFilterDtoIn(
                count: 1,
                page: 1,
                ids: new[] { id },
                models: null,
                ownerIds: null,
                factionIds: null,
                licensePlate: null,
                licensePlateLike: null
            );

            var filteredVehicles = await _gameRepository.GetVehiclesByFilter(filter);

            if (!filteredVehicles.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.VehicleNotFoundById,
                        id
                    )
                );
            }

            await _gameRepository.DeleteVehicleByFilter(filter);

            return Ok();
        }
    }
}
