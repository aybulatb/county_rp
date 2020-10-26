using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using CountyRP.Forum.Domain;
using CountyRP.Forum.Domain.Interfaces;
using CountyRP.Forum.Domain.Exceptions;

namespace CountyRP.Forum.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForumController : ControllerBase
    {
        private readonly IForumRepository _forumRepository;
        private readonly ITopicRepository _topicRepository;

        public ForumController(IForumRepository forumRepository, ITopicRepository topicRepository)
        {
            _forumRepository = forumRepository;
            _topicRepository = topicRepository;
        }
        
        /// <summary>
        /// Получение всех форумов
        /// </summary>
        [HttpGet(nameof(GetAll))]
        [ProducesResponseType(typeof(ForumModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var forums = await _forumRepository.GetAll();

                return Ok(forums);
            }
            catch (Extra.ApiException ex)
            {
                throw new ForumException(ex.StatusCode, ex.Message);
            }
        }

        /// <summary>
        /// Получение всех тем на форуме id
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Topic), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _topicRepository.GetByForumId(id);

            return Ok(res);
        }

        /// <summary>
        /// Создание форума
        /// </summary>
        [HttpPost(nameof(CreateForum))]
        [ProducesResponseType(typeof(ForumModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateForum([FromBody] ForumModel forum)
        {
            try
            {
                var createdForum = await _forumRepository.CreateForum(forum);

                return Ok(createdForum);
            }
            catch (Extra.ApiException ex)
            {
                throw new ForumException(ex.StatusCode, ex.Message);
            }
        }
    }
}
