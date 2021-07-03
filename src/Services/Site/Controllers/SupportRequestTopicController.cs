using CountyRP.Services.Site.Converters;
using CountyRP.Services.Site.Models.Api;
using CountyRP.Services.Site.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CountyRP.Services.Site.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupportRequestTopicController : ControllerBase
    {
        private readonly ILogger<SupportRequestTopicController> _logger;
        private readonly ISiteRepository _siteRepository;

        public SupportRequestTopicController(
            ILogger<SupportRequestTopicController> logger,
            ISiteRepository siteRepository
        )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _siteRepository = siteRepository ?? throw new ArgumentNullException(nameof(siteRepository));
        }

        /// <summary>
        /// Создать тему обращения с сообщением.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiSupportRequestTopicDtoOut), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateTopicWithMessage(
            [FromBody] ApiSupportRequestTopicWithMessageDtoIn apiSupportRequestTopicWithMessageDtoIn
        )
        {
            var creatorUser = await _siteRepository.GetUserByIdAsync(apiSupportRequestTopicWithMessageDtoIn.CreatorUserId);

            if (creatorUser == null)
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.SupportRequestTopicNotFoundCreatorUser,
                        apiSupportRequestTopicWithMessageDtoIn.CreatorUserId
                    )
                );
            }

            if (apiSupportRequestTopicWithMessageDtoIn.RefUserId.HasValue)
            {
                var refUser = await _siteRepository.GetUserByIdAsync(apiSupportRequestTopicWithMessageDtoIn.RefUserId.Value);

                if (refUser == null)
                {
                    return NotFound(
                        string.Format(
                            ConstantMessages.SupportRequestTopicNotFoundRefUser,
                            apiSupportRequestTopicWithMessageDtoIn.RefUserId
                        )
                    );
                }
            }

            // Создание темы обращения.
            var supportRequestTopicDtoIn = ApiSupportRequestTopicWithMessageDtoInConverter.ToSupportRequestTopicDtoIn(
                source: apiSupportRequestTopicWithMessageDtoIn
            );

            var supportRequestTopicDtoOut = await _siteRepository.AddSupportRequestTopicAsync(supportRequestTopicDtoIn);

            // Создание сообщения обращения.
            var supportRequestMessageDtoIn = ApiSupportRequestTopicWithMessageDtoInConverter.ToSupportRequestMessageDtoIn(
                source: apiSupportRequestTopicWithMessageDtoIn,
                topicId: supportRequestTopicDtoOut.Id
            );

            await _siteRepository.AddSupportRequestMessageAsync(supportRequestMessageDtoIn);
            
            return Created(
                string.Empty,
                SupportRequestTopicDtoOutConverter.ToApi(supportRequestTopicDtoOut)
            );
        }

        /// <summary>
        /// Постранично получить обращения по фильтру.
        /// </summary>
        [HttpGet("ByFilterByLastMessages")]
        public async Task<IActionResult> GetByFilterByLastMessages(
            [FromQuery] ApiSupportRequestTopicFilterDtoIn apiSupportRequestTopicFilterDtoIn
        )
        {
            var supportRequestTopicFilterDtoIn = ApiSupportRequestTopicFilterDtoInConverter.ToRepository(apiSupportRequestTopicFilterDtoIn);

            var supportRequestTopicsByFirstAndLastMessages = await _siteRepository.GetSupportRequestTopicsByFilterByFirstMessagesAsync(supportRequestTopicFilterDtoIn);

            return Ok(
                PagedFilterResultConverter.ToApi(supportRequestTopicsByFirstAndLastMessages)
            );
        }
    }
}
