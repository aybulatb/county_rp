using CountyRP.Services.Forum.API.Converters;
using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;
using CountyRP.Services.Forum.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopicController : ControllerBase
    {
        private readonly ILogger<TopicController> _logger;
        private readonly IForumRepository _forumRepository;

        public TopicController(
            ILogger<TopicController> logger,
            IForumRepository forumRepository
        )
        {
            _logger = logger;
            _forumRepository = forumRepository;
        }

        /// <summary>
        /// Создать тему
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiTopicDtoOut), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] ApiTopicDtoIn apiTopicDtoIn)
        {
            if (apiTopicDtoIn.Caption == null || apiTopicDtoIn.Caption.Length < 1 || apiTopicDtoIn.Caption.Length > 128)
            {
                return BadRequest(ConstantMessages.TopicInvalidCaptionLength);
            }
            
            var topicDtoIn = ApiTopicDtoInConverter.ToRepository(apiTopicDtoIn);

            var topicDtoOut = await _forumRepository.CreateTopicAsync(topicDtoIn);

            return Created(
                string.Empty,
                TopicDtoOutConverter.ToApi(topicDtoOut)
            );
        }

        /// <summary>
        /// Получить данные темы по ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiTopicDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var topicDtoOut = await _forumRepository.GetTopicByIdAsync(id);

            if (topicDtoOut == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.TopicNotFoundById, id)
                );
            }

            return Ok(
                TopicDtoOutConverter.ToApi(topicDtoOut)
            );
        }

        /// <summary>
        /// Получить отфильтрованный список тем.
        /// </summary>
        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(PagedFilterResult<ApiTopicDtoOut>), StatusCodes.Status200OK)]
        public async Task<IActionResult> FilterBy([FromQuery] ApiTopicFilterDtoIn filter)
        {
            if (filter.Count < 1 || filter.Count > 100)
            {
                return BadRequest(ConstantMessages.CountItemPerPageMoreThan100);
            }

            if (filter.Page < 1)
            {
                return BadRequest(ConstantMessages.InvalidPageNumber);
            }

            var filterDtoIn = ApiTopicFilterDtoInConverter.ToRepository(filter);

            var filteredTopics = await _forumRepository.GetTopicByFilterAsync(filterDtoIn);

            return Ok(
                PagedFilterResultConverter.ToApi(filteredTopics)
            );
        }

        /// <summary>
        /// Изменить данные темы по ID
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, [FromBody] ApiTopicDtoIn apiTopicDtoIn)
        {
            var existedTopic = await _forumRepository.GetTopicByIdAsync(id);

            if (existedTopic == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.TopicNotFoundById, id)
                );
            }

            if (apiTopicDtoIn.Caption == null || apiTopicDtoIn.Caption.Length < 1 || apiTopicDtoIn.Caption.Length > 128)
            {
                return BadRequest(ConstantMessages.TopicInvalidCaptionLength);
            }

            var topicDtoOut = ApiTopicDtoInConverter.ToDtoOut(
                source: apiTopicDtoIn,
                id: id
            );

            await _forumRepository.UpdateTopicAsync(topicDtoOut);

            return NoContent();
        }

        /// <summary>
        /// Удалить тему по ID.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var existedTopic = await _forumRepository.GetTopicByIdAsync(id);

            if (existedTopic == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.TopicNotFoundById, id)
                );
            }

            await _forumRepository.DeleteTopicByIdAsync(id);

            return Ok();
        }

        /// <summary>
        /// Удалить все темы на форуме с ID forumId
        /// </summary>
        [HttpDelete("ByForumId/{forumId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByForumId(int forumId)
        {
            var existedForum = await _forumRepository.GetForumByIdAsync(forumId);

            if (existedForum == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.ForumNotFoundById, forumId)
                );
            }

            await _forumRepository.DeleteTopicsOnForumByIdAsync(forumId);

            return Ok();
        }
    }
}
