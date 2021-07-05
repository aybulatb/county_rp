using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupportRequestMessageController : ControllerBase
    {
        private readonly ISupportRequestMessageSiteService _supportRequestMessageSiteService;

        public SupportRequestMessageController(
            ISupportRequestMessageSiteService supportRequestMessageSiteService
        )
        {
            _supportRequestMessageSiteService = supportRequestMessageSiteService ?? throw new ArgumentNullException(nameof(supportRequestMessageSiteService));
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] ApiSupportRequestMessageDtoIn apiSupportRequestMessageDtoIn)
        {
            await _supportRequestMessageSiteService.Create(new Infrastructure.Models.SupportRequestMessageDtoIn());

            return Created(
                string.Empty,
                null
            );
        }
    }
}
