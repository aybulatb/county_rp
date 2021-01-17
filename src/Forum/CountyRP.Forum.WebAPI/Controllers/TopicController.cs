using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.WebAPI.ViewModels;
using CountyRP.Forum.WebAPI.Services.Interfaces;

namespace CountyRP.Forum.WebAPI.Controllers
{
    [ApiController]
    [Route("Forum/api/[controller]")]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        /// <summary>
        /// Получить все темы с форума на странице page
        /// </summary>
        [HttpGet("{forumId}/{page}")]
        [ProducesResponseType(typeof(TopicFilterViewModel[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterBy(int forumId, int page)
        {
            try
            {
                return Ok(await _topicService.FilterByPage(forumId, page));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Topic), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] TopicCreateViewModel topic)
        {
            try
            {
                return Ok(await _topicService.CreateTopicAndMessage(topic));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Topic), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Edit(int id, [FromBody] TopicEditViewModel topicViewModel)
        {
            try
            {
                var topic = new Topic
                {
                    Caption = topicViewModel.Caption
                };

                var editedTopic = await _topicService.Edit(id, topic);

                return Ok(editedTopic);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Topic), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _topicService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
