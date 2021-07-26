using CountyRP.Services.Game.API.Converters;
using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;
using CountyRP.Services.Game.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text.RegularExpressions;
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
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromBody] ApiVehicleDtoIn apiVehicleDtoIn
        )
        {
            var checkedResult = await CheckInputCreatedOrEditedData(apiVehicleDtoIn);
            if (checkedResult != null)
            {
                return checkedResult;
            }

            var vehicleDtoIn = ApiVehicleDtoInConverter.ToRepository(apiVehicleDtoIn);

            var vehicleDtoOut = await _gameRepository.AddVehicleAsync(vehicleDtoIn);

            return Created(
                string.Empty,
                VehicleDtoOutConverter.ToApi(vehicleDtoOut)
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VehicleDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            int id
        )
        {
            var filteredVehicles = await _gameRepository.GetVehiclesByFilter(
                VehicleIdConverter.ToVehicleFilterDtoIn(id)
            );

            if (!filteredVehicles.Items.Any())
            {
                return NotFound(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.VehicleNotFoundById,
                        message:
                            string.Format(
                                ConstantMessages.VehicleNotFoundById,
                                id
                            )
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
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterBy(
            [FromQuery] ApiVehicleFilterDtoIn apiVehicleFilterDtoIn
        )
        {
            if (apiVehicleFilterDtoIn.Count < 1)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidCountItemPerPage,
                        message: ConstantMessages.InvalidCountItemPerPage
                    )
                );
            }
            if (apiVehicleFilterDtoIn.Page < 1)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidPageNumber,
                        message: ConstantMessages.InvalidPageNumber
                    )
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
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(
            int id,
            ApiVehicleDtoIn apiVehicleDtoIn
        )
        {
            var filteredVehicles = await _gameRepository.GetVehiclesByFilter(
                VehicleIdConverter.ToVehicleFilterDtoIn(id)
            );

            if (filteredVehicles.AllCount == 0)
            {
                return NotFound(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.VehicleNotFoundById,
                        message:
                            string.Format(
                                ConstantMessages.VehicleNotFoundById,
                                id
                            )
                    )
                );
            }

            var checkedResult = await CheckInputCreatedOrEditedData(apiVehicleDtoIn);
            if (checkedResult != null)
            {
                return checkedResult;
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
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var filter = VehicleIdConverter.ToVehicleFilterDtoIn(id);

            var filteredVehicles = await _gameRepository.GetVehiclesByFilter(filter);

            if (!filteredVehicles.Items.Any())
            {
                return NotFound(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.VehicleNotFoundById,
                        message:
                            string.Format(
                                ConstantMessages.VehicleNotFoundById,
                                id
                            )
                    )
                );
            }

            await _gameRepository.DeleteVehicleByFilter(filter);

            return Ok();
        }

        private async Task<IActionResult> CheckInputCreatedOrEditedData(
            ApiVehicleDtoIn apiVehicleDtoIn
        )
        {
            if (apiVehicleDtoIn.Position?.Length != 3)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidPositionCoordinatesCount,
                        message: ConstantMessages.InvalidPositionCoordinatesCount
                    )
                );
            }

            if (apiVehicleDtoIn.OwnerId.HasValue)
            {
                var existedOwners = await _gameRepository.GetPersonsByFilter(
                    PersonIdConverter.ToPersonFilterDtoIn(apiVehicleDtoIn.OwnerId.Value)
                );

                if (existedOwners.AllCount == 0)
                {
                    return BadRequest(
                        new ApiErrorResponseDtoOut(
                            code: ApiErrorCodeDto.VehicleOwnerNotFoundById,
                            message:
                                string.Format(
                                    ConstantMessages.VehicleOwnerNotFoundById,
                                    apiVehicleDtoIn.OwnerId
                                )
                        )
                    );
                }
            }

            if (apiVehicleDtoIn.FactionId != null)
            {
                var existedFactions = await _gameRepository.GetFactionsByFilter(
                    FactionIdConverter.ToFactionFilterDtoIn(apiVehicleDtoIn.FactionId)
                );

                if (existedFactions.AllCount == 0)
                {
                    return BadRequest(
                        new ApiErrorResponseDtoOut(
                            code: ApiErrorCodeDto.VehicleFactionNotFoundById,
                            message:
                                string.Format(
                                    ConstantMessages.VehicleFactionNotFoundById,
                                    apiVehicleDtoIn.FactionId
                                )
                        )
                    );
                }
            }

            if (!Regex.IsMatch(apiVehicleDtoIn.LicensePlate, @"^\d[A-Z]{3}\d{3}$"))
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.VehicleInvalidLicensePlate,
                        message: ConstantMessages.VehicleInvalidLicensePlate
                    )
                );
            }

            return null;
        }
    }
}
