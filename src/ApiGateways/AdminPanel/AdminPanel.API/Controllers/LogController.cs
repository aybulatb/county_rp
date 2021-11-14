using CountyRP.ApiGateways.AdminPanel.API.Converters;
using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Logs.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private readonly ILogger<LogController> _logger;
        private readonly ILogsService _logsService;

        public LogController(
            ILogger<LogController> logger,
            ILogsService logsService
        )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _logsService = logsService ?? throw new ArgumentNullException(nameof(logsService));
        }

        [HttpGet("FilterBy")]
        public async Task<IActionResult> GetByFilter([FromQuery] ApiLogUnitFilterDtoIn filter)
        {
            var logsLogUnitFilterDtoIn = ApiLogUnitFilterDtoInConverter.ToService(filter);

            var filteredLogUnitsDtoOut = await _logsService.GetLogUnitsByFilterAsync(logsLogUnitFilterDtoIn);

            return Ok(
                LogsPagedFilterResultDtoOutConverter.ToApi(filteredLogUnitsDtoOut)
            );
        }
    }
}
