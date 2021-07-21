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
    public class LockerRoomController : ControllerBase
    {
        private readonly ILogger<LockerRoomController> _logger;
        private readonly IGameRepository _gameRepository;

        public LockerRoomController(
            ILogger<LockerRoomController> logger,
            IGameRepository gameRepository
        )
        {
            _logger = logger;
            _gameRepository = gameRepository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiLockerRoomDtoOut), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
            [FromBody] ApiLockerRoomDtoIn apiLockerRoomDtoIn
        )
        {
            var lockerRoomDtoIn = ApiLockerRoomDtoInConverter.ToRepository(apiLockerRoomDtoIn);

            var lockerRoomDtoOut = await _gameRepository.AddLockerRoomAsync(lockerRoomDtoIn);

            return Created(
                string.Empty,
                LockerRoomDtoOutConverter.ToApi(lockerRoomDtoOut)
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LockerRoomDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            int id
        )
        {
            var filteredLockerRooms = await _gameRepository.GetLockerRoomsByFilter(
                new LockerRoomFilterDtoIn(
                    count: 1,
                    page: 1,
                    ids: new[] { id },
                    factionIds: null
                )
            );

            if (!filteredLockerRooms.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.LockerRoomNotFoundById,
                        id
                    )
                );
            }

            var lockerRoom = filteredLockerRooms.Items.First();

            return Ok(
                LockerRoomDtoOutConverter.ToApi(lockerRoom)
            );
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(ApiPagedFilterResultDtoOut<ApiLockerRoomDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterBy(
            [FromQuery] ApiLockerRoomFilterDtoIn apiLockerRoomFilterDtoIn
        )
        {
            if (apiLockerRoomFilterDtoIn.Count < 1)
            {
                return BadRequest(
                    ConstantMessages.InvalidCountItemPerPage
                );
            }
            if (apiLockerRoomFilterDtoIn.Page < 1)
            {
                return BadRequest(
                    ConstantMessages.InvalidPageNumber
                );
            }

            var filter = ApiLockerRoomFilterDtoInConverter.ToRepository(apiLockerRoomFilterDtoIn);

            var lockerRooms = await _gameRepository.GetLockerRoomsByFilter(filter);

            return Ok(
                PagedFilterResultDtoOutConverter.ToApi(lockerRooms)
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiLockerRoomDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(
            int id,
            ApiLockerRoomDtoIn apiLockerRoomDtoIn
        )
        {
            var filteredLockerRooms = await _gameRepository.GetLockerRoomsByFilter(
                new LockerRoomFilterDtoIn(
                    count: 1,
                    page: 1,
                    ids: new[] { id },
                    factionIds: null
                )
            );

            if (filteredLockerRooms.AllCount == 0)
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.LockerRoomNotFoundById,
                        id
                    )
                );
            }

            var lockerRoomDtoOut = ApiLockerRoomDtoInConverter.ToDtoOutRepository(
                source: apiLockerRoomDtoIn,
                id: id
            );

            var updatedLockerRoomDtoOut = await _gameRepository.UpdateLockerRoomAsync(lockerRoomDtoOut);

            return Ok(
                LockerRoomDtoOutConverter.ToApi(updatedLockerRoomDtoOut)
            );
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var filter = new LockerRoomFilterDtoIn(
                count: 1,
                page: 1,
                ids: new[] { id },
                factionIds: null
            );

            var filteredLockerRooms = await _gameRepository.GetLockerRoomsByFilter(filter);

            if (!filteredLockerRooms.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.LockerRoomNotFoundById,
                        id
                    )
                );
            }

            await _gameRepository.DeleteLockerRoomByFilter(filter);

            return Ok();
        }
    }
}
