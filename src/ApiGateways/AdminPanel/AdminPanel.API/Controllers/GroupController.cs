using CountyRP.ApiGateways.AdminPanel.API.Converters;
using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly ILogger<GroupController> _logger;
        private readonly ISiteService _siteService;
        
        public GroupController(
            ILogger<GroupController> logger,
            ISiteService siteService
        )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _siteService = siteService ?? throw new ArgumentNullException(nameof(siteService));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ApiGroupDtoIn apiGroupDtoIn)
        {
            var siteGroupDtoIn = ApiGroupDtoInConverter.ToService(apiGroupDtoIn);

            var siteGroupDtoOut = await _siteService.AddGroupAsync(siteGroupDtoIn);

            return Ok(
                SiteGroupDtoOutConverter.ToApi(siteGroupDtoOut)
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var siteGroupDtoOut = await _siteService.GetGroupByIdAsync(id);

            return Ok(
                SiteGroupDtoOutConverter.ToApi(siteGroupDtoOut)
            );
        }

        [HttpGet("FilterBy")]
        public async Task<IActionResult> GetByFilter([FromQuery] ApiGroupFilterDtoIn apiGroupFilterDtoIn)
        {
            var siteGroupFilterDtoIn = ApiGroupFilterDtoInConverter.ToService(apiGroupFilterDtoIn);

            var siteGroupsDtoOut = await _siteService.GetGroupsByFilterAsync(siteGroupFilterDtoIn);

            return Ok(
                SitePagedFilterResultDtoOutConverter.ToApi(siteGroupsDtoOut)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, [FromBody] ApiUpdatedGroupDtoIn apiUpdatedGroupDtoIn)
        {
            var siteUpdatedGroupDtoIn = ApiUpdatedGroupDtoInConverter.ToService(apiUpdatedGroupDtoIn);

            var siteGroupDtoOut = await _siteService.EditGroupAsync(id, siteUpdatedGroupDtoIn);

            return Ok(
                SiteGroupDtoOutConverter.ToApi(siteGroupDtoOut)
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _siteService.DeleteGroupAsync(id);

            return Ok();
        }
    }
}
