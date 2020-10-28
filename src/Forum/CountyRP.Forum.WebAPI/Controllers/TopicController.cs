using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using CountyRP.Forum.Domain.Interfaces;
using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.WebAPI.ViewModels;

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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(nameof(EditTopic))]
        [ProducesResponseType(typeof(Topic), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditTopic([FromBody] TopicViewModel topicViewModel)
        {
            try
            {
                var topic = new Topic
                {
                    Id = topicViewModel.Id,
                    Caption = topicViewModel.Caption
                };

                var editedTopic = await _topicRepository.Edit(topic);

                return Ok(editedTopic);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteTopic/{id}")]
        [ProducesResponseType(typeof(Topic), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            try
            {
                await _topicRepository.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
