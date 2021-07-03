using CountyRP.Services.Site.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Удалить сообщение из обращения.
        /// </summary>
        //[HttpDelete]
        //[ProducesResponseType(typeof(void), StatusCodes.Status201Created)]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    //var supportRequestTopicDtoOut = await _siteRepository.Ge(supportRequestTopicDtoIn);

        //    //return Created(
        //    //    string.Empty,
        //    //    SupportRequestTopicDtoOutConverter.ToApi(supportRequestTopicDtoOut)
        //    //);
        //}
    }
}
