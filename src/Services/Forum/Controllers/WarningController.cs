using CountyRP.Services.Forum.Converters;
using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;
using CountyRP.Services.Forum.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WarningController : ControllerBase
    {
        private readonly ILogger<WarningController> _logger;
        private readonly IForumRepository _forumRepository;

        public WarningController(
            ILogger<WarningController> logger,
            IForumRepository forumRepository
        )
        {
            _logger = logger;
            _forumRepository = forumRepository;
        }

        /// <summary>
        /// Создать предупреждение
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiWarningDtoOut), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] ApiWarningDtoIn apiWarningDtoIn)
        {
            if (apiWarningDtoIn.Text == null || apiWarningDtoIn.Text.Length < 1 || apiWarningDtoIn.Text.Length > 128)
            {
                return BadRequest(ConstantMessages.InvalidTextLength);
            }

            var warningDtoIn = ApiWarningDtoInConverter.ToRepository(apiWarningDtoIn);

            var warningDtoOut = await _forumRepository.CreateWarningAsync(warningDtoIn);

            return Created(
                string.Empty,
                WarningDtoOutConverter.ToApi(warningDtoOut)
            );
        }

        /// <summary>
        /// Получить отфильтрованный список предупреждений
        /// </summary>
        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(PagedFilterResult<ApiWarningDtoOut>), StatusCodes.Status200OK)]
        public async Task<IActionResult> FilterBy([FromQuery] ApiWarningFilterDtoIn filter)
        {
            if (filter.Count < 1 || filter.Count > 100)
            {
                return BadRequest(ConstantMessages.InvalidCountItemPerPage);
            }

            if (filter.Page < 1)
            {
                return BadRequest(ConstantMessages.InvalidPageNumber);
            }

            var warningDtoIn = ApiWarningFilterDtoInConverter.ToRepository(filter);

            var warningReputations = await _forumRepository.GetWarningsByFilterAsync(warningDtoIn);

            return Ok(
                PagedFilterResultConverter.ToApi(warningReputations)
            );
        }

        /// <summary>
        /// Удалить предупреждение по ID
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _forumRepository.DeleteWarningAsync(id);

            return Ok();
        }

        /// <summary>
        /// Удалить все предупреждения у игрока под ID userId
        /// </summary>
        [HttpDelete("ByUserId/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByForumId(int userId)
        {
            var existedUser = await _forumRepository.GetUserByIdAsync(userId);

            if (existedUser == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.UserNotFoundById, userId)
                );
            }

            await _forumRepository.DeleteWarningsOnUserByIdAsync(userId);

            return Ok();
        }
    }
}
