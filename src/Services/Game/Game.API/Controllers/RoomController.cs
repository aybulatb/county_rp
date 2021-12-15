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
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IGameRepository _gameRepository;

        public RoomController(
            ILogger<RoomController> logger,
            IGameRepository gameRepository
        )
        {
            _logger = logger;
            _gameRepository = gameRepository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiRoomDtoOut), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
            [FromBody] ApiRoomDtoIn apiRoomDtoIn
        )
        {
            var validatedResult = await ValidateInputCreatedOrEditedData(apiRoomDtoIn);
            if (validatedResult != null)
            {
                return validatedResult;
            }

            var roomDtoIn = ApiRoomDtoInConverter.ToRepository(apiRoomDtoIn);

            var roomDtoOut = await _gameRepository.AddRoomAsync(roomDtoIn);

            return Created(
                string.Empty,
                RoomDtoOutConverter.ToApi(roomDtoOut)
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RoomDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            int id
        )
        {
            var filteredRooms = await _gameRepository.GetRoomsByFilter(
                RoomIdConverter.ToRoomFilterDtoIn(id)
            );

            if (!filteredRooms.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.RoomNotFoundById,
                        id
                    )
                );
            }

            var room = filteredRooms.Items.First();

            return Ok(
                RoomDtoOutConverter.ToApi(room)
            );
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(ApiPagedFilterResultDtoOut<ApiRoomDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterBy(
            [FromQuery] ApiRoomFilterDtoIn apiRoomFilterDtoIn
        )
        {
            if (apiRoomFilterDtoIn.Count < 1)
            {
                return BadRequest(
                    ConstantMessages.InvalidCountItemPerPage
                );
            }
            if (apiRoomFilterDtoIn.Page < 1)
            {
                return BadRequest(
                    ConstantMessages.InvalidPageNumber
                );
            }

            var filter = ApiRoomFilterDtoInConverter.ToRepository(apiRoomFilterDtoIn);

            var rooms = await _gameRepository.GetRoomsByFilter(filter);

            return Ok(
                PagedFilterResultDtoOutConverter.ToApi(rooms)
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiRoomDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(
            int id,
            ApiRoomDtoIn apiRoomDtoIn
        )
        {
            var filteredRooms = await _gameRepository.GetRoomsByFilter(
                RoomIdConverter.ToRoomFilterDtoIn(id)
            );

            if (filteredRooms.AllCount == 0)
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.RoomNotFoundById,
                        id
                    )
                );
            }

            var validatedResult = await ValidateInputCreatedOrEditedData(apiRoomDtoIn);
            if (validatedResult != null)
            {
                return validatedResult;
            }

            var roomDtoOut = ApiRoomDtoInConverter.ToDtoOutRepository(
                source: apiRoomDtoIn,
                id: id
            );

            var updatedRoomDtoOut = await _gameRepository.UpdateRoomAsync(roomDtoOut);

            return Ok(
                RoomDtoOutConverter.ToApi(updatedRoomDtoOut)
            );
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var filter = RoomIdConverter.ToRoomFilterDtoIn(id);

            var filteredRooms = await _gameRepository.GetRoomsByFilter(filter);

            if (!filteredRooms.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.RoomNotFoundById,
                        id
                    )
                );
            }

            await _gameRepository.DeleteRoomByFilter(filter);

            return Ok();
        }

        private async Task<IActionResult> ValidateInputCreatedOrEditedData(ApiRoomDtoIn apiRoomDtoIn)
        {
            if (apiRoomDtoIn.EntrancePosition?.Length != 3)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidPositionCoordinatesCount,
                        message: ConstantMessages.InvalidPositionCoordinatesCount
                    )
                );
            }

            if (apiRoomDtoIn.ExitPosition?.Length != 3)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidPositionCoordinatesCount,
                        message: ConstantMessages.InvalidPositionCoordinatesCount
                    )
                );
            }

            if (apiRoomDtoIn.ColorMarker?.Length != 3)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidMarkerColorsCount,
                        message: ConstantMessages.InvalidMarkerColorsCount
                    )
                );
            }

            if (apiRoomDtoIn.GangId.HasValue)
            {
                var existedGangs = await _gameRepository.GetGangsByFilter(
                    GangIdConverter.ToGangFilterDtoIn(apiRoomDtoIn.GangId.Value)
                );

                if (existedGangs.AllCount == 0)
                {
                    return BadRequest(
                        new ApiErrorResponseDtoOut(
                            code: ApiErrorCodeDto.RoomGangNotFoundById,
                            message: string.Format(
                                ConstantMessages.RoomGangNotFoundById,
                                apiRoomDtoIn.GangId
                            )
                        )
                    );
                }
            }

            if (apiRoomDtoIn.SafePosition?.Length != 3)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidPositionCoordinatesCount,
                        message: ConstantMessages.InvalidPositionCoordinatesCount
                    )
                );
            }

            return null;
        }
    }
}
