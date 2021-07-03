using CountyRP.Services.Site.Converters;
using CountyRP.Services.Site.Models;
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
    public class SupportRequestMessageController : ControllerBase
    {
        private readonly ILogger<SupportRequestMessageController> _logger;
        private readonly ISiteRepository _siteRepository;

        public SupportRequestMessageController(
            ILogger<SupportRequestMessageController> logger,
            ISiteRepository siteRepository
        )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _siteRepository = siteRepository ?? throw new ArgumentNullException(nameof(siteRepository));
        }

        /// <summary>
        /// Создать сообщение в обращении.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiSupportRequestMessageDtoOut), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
            [FromBody] ApiSupportRequestMessageDtoIn apiSupportRequestMessageDtoIn
        )
        {
            var supportRequestMessageDtoIn = ApiSupportRequestMessageDtoInConverter.ToRepository(apiSupportRequestMessageDtoIn);

            var supportRequestMessageDtoOut = await _siteRepository.AddSupportRequestMessageAsync(supportRequestMessageDtoIn);

            return Ok(
                SupportRequestMessageDtoOutConverter.ToApi(supportRequestMessageDtoOut)
            );
        }

        /// <summary>
        /// Постранично получить отфильтрованные сообщения.
        /// </summary>
        [HttpGet("ByFilter")]
        [ProducesResponseType(typeof(ApiPagedFilterResult<ApiSupportRequestMessageDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByFilter(
            [FromQuery] ApiSupportRequestMessageFilterDtoIn apiSupportRequestMessageFilterDtoIn
        )
        {
            if (apiSupportRequestMessageFilterDtoIn.Page < 1)
            {
                return BadRequest(ConstantMessages.InvalidPageNumber);
            }

            if (apiSupportRequestMessageFilterDtoIn.Count <  1)
            {
                return BadRequest(ConstantMessages.InvalidCountItemPerPage);
            }

            var supportRequestMessageFilterDtoIn = ApiSupportRequestMessageFilterDtoInConverter.ToRepository(apiSupportRequestMessageFilterDtoIn);

            var filteredSupportRequestMessages = await _siteRepository.GetSupportRequestMessagesByFilterAsync(supportRequestMessageFilterDtoIn);

            return Ok(
                PagedFilterResultConverter.ToApi(filteredSupportRequestMessages)
            );
        }

        /// <summary>
        /// Удалить сообщение из обращения.
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var filter = new SupportRequestMessageFilterDtoIn(
                    count: 1,
                    page: 1,
                    ids: new[] { id },
                    topicId: null,
                    userId: null
                );

            var supportRequestMessagesByFilter = await _siteRepository.GetSupportRequestMessagesByFilterAsync(filter);

            if (supportRequestMessagesByFilter.AllCount == 0)
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.SupportRequestMessageNotFoundById,
                        id
                    )
                );
            }

            await _siteRepository.DeleteSupportRequestMessagesAsync(filter);

            return Ok();
        }
    }
}
