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
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromBody] ApiAtmDtoIn apiAtmDtoIn
        )
        {
            var validatedResult = await ValidateInputCreatedOrEditedData(apiAtmDtoIn);
            if (validatedResult != null)
            {
                return validatedResult;
            }

            var atmDtoIn = ApiAtmDtoInConverter.ToRepository(apiAtmDtoIn);

            var atmDtoOut = await _gameRepository.AddAtmAsync(atmDtoIn);

            return Created(
                string.Empty,
                AtmDtoOutConverter.ToApi(atmDtoOut)
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AtmDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            int id
        )
        {
            var filteredAtms = await _gameRepository.GetAtmsByFilter(
                AtmIdConverter.ToAtmFilterDtoIn(id)
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
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(
            int id,
            ApiAtmDtoIn apiAtmDtoIn
        )
        {
            var filteredAtms = await _gameRepository.GetAtmsByFilter(
                AtmIdConverter.ToAtmFilterDtoIn(id)
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

            var validatedResult = await ValidateInputCreatedOrEditedData(apiAtmDtoIn);
            if (validatedResult != null)
            {
                return validatedResult;
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
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var filter = AtmIdConverter.ToAtmFilterDtoIn(id);

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

        private async Task<IActionResult> ValidateInputCreatedOrEditedData(ApiAtmDtoIn apiAtmDtoIn)
        {
            if (apiAtmDtoIn.Position?.Length != 3)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidPositionCoordinatesCount,
                        message: ConstantMessages.InvalidPositionCoordinatesCount
                    )
                );
            }

            if (apiAtmDtoIn.BusinessId.HasValue)
            {
                var existedBusinesses = await _gameRepository.GetBusinessesByFilter(
                    BusinessIdConverter.ToBusinessFilterDtoIn(apiAtmDtoIn.BusinessId.Value)
                );

                if (existedBusinesses.AllCount == 0)
                {
                    return BadRequest(
                        new ApiErrorResponseDtoOut(
                            code: ApiErrorCodeDto.AtmBusinessNotFoundById,
                            message:
                                string.Format(
                                    ConstantMessages.AtmBusinessNotFoundById,
                                    apiAtmDtoIn.BusinessId
                                )
                        )
                    );
                }
            }

            return null;
        }
    }
}
