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
    public class PostController : ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private readonly IForumRepository _forumRepository;

        public PostController(
            ILogger<PostController> logger,
            IForumRepository forumRepository
        )
        {
            _logger = logger;
            _forumRepository = forumRepository;
        }

        /// <summary>
        /// Создать сообщение
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiPostDtoOut), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] ApiPostDtoIn apiPostDtoIn)
        {
            var postDtoIn = ApiPostDtoInConverter.ToRepository(apiPostDtoIn);

            var postDtoOut = await _forumRepository.CreatePostAsync(postDtoIn);

            return Created(
                string.Empty,
                PostDtoOutConverter.ToApi(postDtoOut)
            );
        }

        /// <summary>
        /// Получить данные сообщения по ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiPostDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var postDtoOut = await _forumRepository.GetPostByIdAsync(id);

            if (postDtoOut == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.PostNotFoundById, id)
                );
            }

            return Ok(
                PostDtoOutConverter.ToApi(postDtoOut)
            );
        }

        /// <summary>
        /// Получить отфильтрованный список сообщений
        /// </summary>
        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(PagedFilterResult<ApiPostDtoOut>), StatusCodes.Status200OK)]
        public async Task<IActionResult> FilterBy([FromQuery] ApiPostFilterDtoIn filter)
        {
            if (filter.Count < 1 || filter.Count > 100)
            {
                return BadRequest(ConstantMessages.CountItemPerPageMoreThan100);
            }

            if (filter.Page < 1)
            {
                return BadRequest(ConstantMessages.InvalidPageNumber);
            }

            var filterDtoIn = ApiPostFilterDtoInConverter.ToRepository(filter);

            var filteredPosts = await _forumRepository.GetPostByFilterAsync(filterDtoIn);

            return Ok(
                PagedFilterResultConverter.ToApi(filteredPosts)
            );
        }

        /// <summary>
        /// Изменить данные сообщения по ID
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiPostDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, [FromBody] ApiPostDtoIn apiPostDtoIn)
        {
            var existedPost = await _forumRepository.GetPostByIdAsync(id);

            if (existedPost == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.PostNotFoundById, id)
                );
            }

            var postDtoIn = ApiPostDtoInConverter.ToRepository(apiPostDtoIn);

            var PostDtoOut = PostDtoInConverter.ToDtoOut(
                source: postDtoIn,
                id: id
            );

            var updatedPostDtoOut = await _forumRepository.UpdatePostAsync(PostDtoOut);

            return Ok(
                PostDtoOutConverter.ToApi(updatedPostDtoOut)
            );
        }

        /// <summary>
        /// Удалить сообщение по ID
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var existedPost = await _forumRepository.GetPostByIdAsync(id);

            if (existedPost == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.PostNotFoundById, id)
                );
            }

            await _forumRepository.DeletePostByIdAsync(id);

            return Ok();
        }

        /// <summary>
        /// Удалить все сообщения в теме с ID topicId
        /// </summary>
        [HttpDelete("ByTopicId/{topicId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByForumId(int topicId)
        {
            var existedTopic = await _forumRepository.GetTopicByIdAsync(topicId);

            if (existedTopic == null)
            {
                return NotFound(
                    string.Format(ConstantMessages.TopicNotFoundById, topicId)
                );
            }

            await _forumRepository.DeletePostsOnTopicByIdAsync(topicId);

            return Ok();
        }
    }
}
