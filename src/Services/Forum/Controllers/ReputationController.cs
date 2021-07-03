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
    public class ReputationController : ControllerBase
    {
        private readonly ILogger<ReputationController> _logger;
        private readonly IForumRepository _forumRepository;

        public ReputationController(
            ILogger<ReputationController> logger,
            IForumRepository forumRepository
        )
        {
            _logger = logger;
            _forumRepository = forumRepository;
        }

        /// <summary>
        /// Создать изменение репутации
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiReputationDtoOut), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] ApiReputationDtoIn apiReputationDtoIn)
        {
            if (apiReputationDtoIn.Text == null || apiReputationDtoIn.Text.Length < 1 || apiReputationDtoIn.Text.Length > 128)
            {
                return BadRequest(ConstantMessages.InvalidTextLength);
            }

            var reputationDtoIn = ApiReputationDtoInConverter.ToRepository(apiReputationDtoIn);

            var reputationDtoOut = await _forumRepository.CreateReputationAsync(reputationDtoIn);

            return Created(
                string.Empty,
                ReputationDtoOutConverter.ToApi(reputationDtoOut)
            );
        }

        /// <summary>
        /// Получить отфильтрованный список изменений репутации
        /// </summary>
        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(PagedFilterResult<ApiReputationDtoOut>), StatusCodes.Status200OK)]
        public async Task<IActionResult> FilterBy([FromQuery] ApiReputationFilterDtoIn filter)
        {
            if (filter.Count < 1 || filter.Count > 100)
            {
                return BadRequest(ConstantMessages.CountItemPerPageMoreThan100);
            }

            if (filter.Page < 1)
            {
                return BadRequest(ConstantMessages.InvalidPageNumber);
            }

            var filterDtoIn = ApiReputationFilterDtoInConverter.ToRepository(filter);

            var filteredReputations = await _forumRepository.GetReputationsByFilterAsync(filterDtoIn);

            return Ok(
                PagedFilterResultConverter.ToApi(filteredReputations)
            );
        }

        /// <summary>
        /// Удалить изменение репутации по ID
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _forumRepository.DeleteReputationAsync(id);

            return Ok();
        }

        /// <summary>
        /// Удалить все изменений репутаций у игрока под ID userId
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

            await _forumRepository.DeleteReputationsOnUserByIdAsync(userId);

            return Ok();
        }
    }
}
