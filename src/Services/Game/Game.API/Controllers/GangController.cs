using CountyRP.Services.Game.API.Converters;
using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;
using CountyRP.Services.Game.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GangController : ControllerBase
    {
        private readonly ILogger<GangController> _logger;
        private readonly IGameRepository _gameRepository;

        public GangController(
            ILogger<GangController> logger,
            IGameRepository gameRepository
        )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiGangDtoOut), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromBody] ApiGangDtoIn apiGangDtoIn
        )
        {
            //var validatedResult = await ValidateInputCreatedOrEditedData(apiAtmDtoIn);
            //if (validatedResult != null)
            //{
            //    return validatedResult;
            //}

            var gangDtoIn = ApiGangDtoInConverter.ToRepository(apiGangDtoIn);

            var gangDtoOut = await _gameRepository.AddGangAsync(gangDtoIn);

            return Created(
                string.Empty,
                GangDtoOutConverter.ToApi(gangDtoOut)
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiGangDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var filteredGangs = await _gameRepository.GetGangsByFilter(
                GangIdConverter.ToGangFilterDtoIn(id)
            );

            if (!filteredGangs.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.GangNotFoundById,
                        id
                    )
                );
            }

            var gang = filteredGangs.Items.First();

            return Ok(
                GangDtoOutConverter.ToApi(gang)
            );
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(ApiPagedFilterResultDtoOut<ApiGangDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterBy(
            [FromQuery] ApiGangFilterDtoIn apiGangFilterDtoIn
        )
        {
            if (apiGangFilterDtoIn.Count < 1)
            {
                return BadRequest(
                    ConstantMessages.InvalidCountItemPerPage
                );
            }
            if (apiGangFilterDtoIn.Page < 1)
            {
                return BadRequest(
                    ConstantMessages.InvalidPageNumber
                );
            }

            var filter = ApiGangFilterDtoInConverter.ToRepository(apiGangFilterDtoIn);

            var gangs = await _gameRepository.GetGangsByFilter(filter);

            return Ok(
                PagedFilterResultDtoOutConverter.ToApi(gangs)
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiGangDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(
            int id,
            ApiEditedGangDtoIn apiEditedGangDtoIn
        )
        {
            var filteredGangs = await _gameRepository.GetGangsByFilter(
                GangIdConverter.ToGangFilterDtoIn(id)
            );

            if (filteredGangs.AllCount == 0)
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.GangNotFoundById,
                        id
                    )
                );
            }

            //var validatedResult = await ValidateInputCreatedOrEditedData(apiAtmDtoIn);
            //if (validatedResult != null)
            //{
            //    return validatedResult;
            //}

            var editedGangDtoIn = ApiEditedGangDtoInConverter.ToRepository(
                source: apiEditedGangDtoIn,
                id: id
            );

            var gangDtoOut = await _gameRepository.UpdateGangAsync(editedGangDtoIn);

            return Ok(
                GangDtoOutConverter.ToApi(gangDtoOut)
            );
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var filter = GangIdConverter.ToGangFilterDtoIn(id);

            var filteredGangs = await _gameRepository.GetGangsByFilter(filter);

            if (!filteredGangs.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.GangNotFoundById,
                        id
                    )
                );
            }

            await _gameRepository.DeleteGangByFilter(filter);

            return Ok();
        }
    }
}
