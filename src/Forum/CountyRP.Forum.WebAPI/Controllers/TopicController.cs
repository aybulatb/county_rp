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
    public class TopicController : ControllerBase
    {
        private readonly ITopicRepository _topicRepository;

        public TopicController(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        /// <summary>
        /// Создание темы на форуме
        /// </summary>
        [HttpPost(nameof(CreateTopic))]
        [ProducesResponseType(typeof(Topic), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateTopic([FromBody] Topic topic)
        {
            try
            {
                var createdTopic = await _topicRepository.CreateTopic(topic);

                return Ok(createdTopic);
            }
            catch (Extra.ApiException ex)
            {
                throw new ForumException(ex.StatusCode, ex.Message);
            }
        }
    }
}
