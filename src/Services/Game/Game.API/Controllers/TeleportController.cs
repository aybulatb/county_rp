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
            var checkedResult = await CheckInputCreatedOrEditedData(apiTeleportDtoIn);
            if (checkedResult != null)
            {
                return checkedResult;
            }

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
                TeleportIdConverter.ToTeleportFilterDtoIn(id)
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
                TeleportIdConverter.ToTeleportFilterDtoIn(id)
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

            var checkedResult = await CheckInputCreatedOrEditedData(apiTeleportDtoIn);
            if (checkedResult != null)
            {
                return checkedResult;
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
            var filter = TeleportIdConverter.ToTeleportFilterDtoIn(id);

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

        private async Task<IActionResult> CheckInputCreatedOrEditedData(ApiTeleportDtoIn apiTeleportDtoIn)
        {
            if (apiTeleportDtoIn.EntrancePosition?.Length != 3)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidPositionCoordinatesCount,
                        message: ConstantMessages.InvalidPositionCoordinatesCount
                    )
                );
            }

            if (apiTeleportDtoIn.ExitPosition?.Length != 3)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidPositionCoordinatesCount,
                        message: ConstantMessages.InvalidPositionCoordinatesCount
                    )
                );
            }

            if (apiTeleportDtoIn.ColorMarker?.Length != 3)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidMarkerColorsCount,
                        message: ConstantMessages.InvalidMarkerColorsCount
                    )
                );
            }

            if (apiTeleportDtoIn.FactionId != null)
            {
                var existedFactions = await _gameRepository.GetFactionsByFilter(
                    FactionIdConverter.ToFactionFilterDtoIn(apiTeleportDtoIn.FactionId)
                );

                if (existedFactions.AllCount == 0)
                {
                    return BadRequest(
                        new ApiErrorResponseDtoOut(
                            code: ApiErrorCodeDto.TeleportFactionNotFoundById,
                            message:
                                string.Format(
                                    ConstantMessages.TeleportFactionNotFoundById,
                                    apiTeleportDtoIn.FactionId
                                )
                        )
                    );
                }
            }

            if (apiTeleportDtoIn.GangId.HasValue)
            {
                var existedGangs = await _gameRepository.GetGangsByFilter(
                    GangIdConverter.ToGangFilterDtoIn(apiTeleportDtoIn.GangId.Value)
                );

                if (existedGangs.AllCount == 0)
                {
                    return BadRequest(
                        new ApiErrorResponseDtoOut(
                            code: ApiErrorCodeDto.TeleportGangNotFoundById,
                            message:
                                string.Format(
                                    ConstantMessages.TeleportGangNotFoundById,
                                    apiTeleportDtoIn.GangId
                                )
                        )
                    );
                }
            }

            if (apiTeleportDtoIn.RoomId.HasValue)
            {
                var existedRooms = await _gameRepository.GetRoomsByFilter(
                    RoomIdConverter.ToRoomFilterDtoIn(apiTeleportDtoIn.RoomId.Value)
                );

                if (existedRooms.AllCount == 0)
                {
                    return BadRequest(
                        new ApiErrorResponseDtoOut(
                            code: ApiErrorCodeDto.TeleportRoomNotFoundById,
                            message:
                                string.Format(
                                    ConstantMessages.TeleportRoomNotFoundById,
                                    apiTeleportDtoIn.RoomId
                                )
                        )
                    );
                }
            }

            if (apiTeleportDtoIn.BusinessId.HasValue)
            {
                var existedBusinesses = await _gameRepository.GetBusinessesByFilter(
                    BusinessIdConverter.ToBusinessFilterDtoIn(apiTeleportDtoIn.BusinessId.Value)
                );

                if (existedBusinesses.AllCount == 0)
                {
                    return BadRequest(
                        new ApiErrorResponseDtoOut(
                            code: ApiErrorCodeDto.TeleportBusinessNotFoundById,
                            message:
                                string.Format(
                                    ConstantMessages.TeleportBusinessNotFoundById,
                                    apiTeleportDtoIn.BusinessId
                                )
                        )
                    );
                }
            }

            return null;
        }
    }
}
