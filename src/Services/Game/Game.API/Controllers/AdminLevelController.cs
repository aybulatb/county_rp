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
    public class AdminLevelController : ControllerBase
    {
        private readonly ILogger<AdminLevelController> _logger;
        private readonly IGameRepository _gameRepository;

        public AdminLevelController(
            ILogger<AdminLevelController> logger,
            IGameRepository gameRepository
        )
        {
            _logger = logger;
            _gameRepository = gameRepository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiAdminLevelDtoOut), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
            [FromBody] ApiAdminLevelDtoIn apiAdminLevelDtoIn
        )
        {
            var checkedResult = await CheckInputCreatedData(apiAdminLevelDtoIn);
            if (checkedResult != null)
            {
                return checkedResult;
            }

            var adminLevelDtoIn = ApiAdminLevelDtoInConverter.ToRepository(apiAdminLevelDtoIn);

            var adminLevelDtoOut = await _gameRepository.AddAdminLevelAsync(adminLevelDtoIn);

            return Created(
                string.Empty,
                AdminLevelDtoOutConverter.ToApi(adminLevelDtoOut)
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AdminLevelDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            string id
        )
        {
            var filteredAdminLevels = await _gameRepository.GetAdminLevelsByFilter(
                AdminLevelIdConverter.ToAdminLevelFilterDtoIn(id)
            );

            if (!filteredAdminLevels.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.AdminLevelNotFoundById,
                        id
                    )
                );
            }

            var adminLevel = filteredAdminLevels.Items.First();

            return Ok(
                AdminLevelDtoOutConverter.ToApi(adminLevel)
            );
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(ApiPagedFilterResultDtoOut<ApiAdminLevelDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterBy(
            [FromQuery] ApiAdminLevelFilterDtoIn apiAdminLevelFilterDtoIn
        )
        {
            if (apiAdminLevelFilterDtoIn.Count < 1)
            {
                return BadRequest(
                    ConstantMessages.InvalidCountItemPerPage
                );
            }
            if (apiAdminLevelFilterDtoIn.Page < 1)
            {
                return BadRequest(
                    ConstantMessages.InvalidPageNumber
                );
            }

            var filter = ApiAdminLevelFilterDtoInConverter.ToRepository(apiAdminLevelFilterDtoIn);

            var adminLevels = await _gameRepository.GetAdminLevelsByFilter(filter);

            return Ok(
                PagedFilterResultDtoOutConverter.ToApi(adminLevels)
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiAdminLevelDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(
            string id,
            ApiEditedAdminLevelDtoIn apiEditedAdminLevelDtoIn
        )
        {
            var checkedResult = await CheckInputEditedData(id, apiEditedAdminLevelDtoIn);
            if (checkedResult != null)
            {
                return checkedResult;
            }

            var filteredAdminLevels = await _gameRepository.GetAdminLevelsByFilter(
                AdminLevelIdConverter.ToAdminLevelFilterDtoIn(id)
            );

            if (filteredAdminLevels.AllCount == 0)
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.AdminLevelNotFoundById,
                        id
                    )
                );
            }

            var adminLevelDtoOut = ApiEditedAdminLevelDtoInConverter.ToDtoOutRepository(
                source: apiEditedAdminLevelDtoIn,
                id: id
            );

            var updatedAdminLevelDtoOut = await _gameRepository.UpdateAdminLevelAsync(adminLevelDtoOut);

            return Ok(
                AdminLevelDtoOutConverter.ToApi(updatedAdminLevelDtoOut)
            );
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            var filter = AdminLevelIdConverter.ToAdminLevelFilterDtoIn(id);

            var filteredAdminLevels = await _gameRepository.GetAdminLevelsByFilter(filter);

            if (!filteredAdminLevels.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.AdminLevelNotFoundById,
                        id
                    )
                );
            }

            await _gameRepository.DeleteAdminLevelByFilter(filter);

            return Ok();
        }

        private async Task<IActionResult> CheckInputCreatedData(ApiAdminLevelDtoIn apiAdminLevelDtoIn)
        {
            if (!Regex.IsMatch(apiAdminLevelDtoIn.Id ?? string.Empty, @"^[a-zA-Z0-9_]{3,16}$"))
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.AdminLevelInvalidId,
                        message: ConstantMessages.AdminLevelInvalidId
                    )
                );
            }

            if (apiAdminLevelDtoIn.Name == null || apiAdminLevelDtoIn.Name.Length > 64)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.AdminLevelInvalidNameLength,
                        message: ConstantMessages.AdminLevelInvalidNameLength
                    )
                );
            }

            if (!Regex.IsMatch(apiAdminLevelDtoIn.Name, @"^\w+(([\w\s]*\w)|\w*)$"))
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.AdminLevelInvalidName,
                        message: ConstantMessages.AdminLevelInvalidName
                    )
                );
            }

            var existedAdminLevelsWithName = await _gameRepository.GetAdminLevelsByFilter(
                new AdminLevelFilterDtoIn(
                    count: 1,
                    page: 1,
                    ids: null,
                    names: new[] { apiAdminLevelDtoIn.Name },
                    nameLike: null
                )
            );

            if (existedAdminLevelsWithName.AllCount != 0)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.AdminLevelAlreadyExistsWithName,
                        message: ConstantMessages.AdminLevelAlreadyExistsWithName
                    )
                );
            }

            return null;
        }

        private async Task<IActionResult> CheckInputEditedData(string id, ApiEditedAdminLevelDtoIn apiEditedAdminLevelDtoIn)
        {
            if (apiEditedAdminLevelDtoIn.Name == null || apiEditedAdminLevelDtoIn.Name.Length > 64)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.AdminLevelInvalidNameLength,
                        message: ConstantMessages.AdminLevelInvalidNameLength
                    )
                );
            }

            if (!Regex.IsMatch(apiEditedAdminLevelDtoIn.Name, @"^\w+(([\w\s]*\w)|\w*)$"))
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.AdminLevelInvalidName,
                        message: ConstantMessages.AdminLevelInvalidName
                    )
                );
            }

            var existedAdminLevelsWithName = await _gameRepository.GetAdminLevelsByFilter(
                new AdminLevelFilterDtoIn(
                    count: 1,
                    page: 1,
                    ids: null,
                    names: new[] { apiEditedAdminLevelDtoIn.Name },
                    nameLike: null
                )
            );

            if (existedAdminLevelsWithName.AllCount != 0)
            {
                var existedAdminLevelWithName = existedAdminLevelsWithName.Items.First();

                if (existedAdminLevelWithName.Id != id)
                {
                    return BadRequest(
                        new ApiErrorResponseDtoOut(
                            code: ApiErrorCodeDto.AdminLevelAlreadyExistsWithName,
                            message: ConstantMessages.AdminLevelAlreadyExistsWithName
                        )
                    );
                }
            }

            return null;
        }
    }
}
