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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ApiLogUnitDtoIn apiLogUnitDtoIn)
        {
            var logsLogUnitDtoIn = ApiLogUnitDtoInConverter.ToService(apiLogUnitDtoIn);

            var logsLogUnitDtoOut = await _logsService.CreateLogUnitAsync(logsLogUnitDtoIn);

            return Ok(
                LogsLogUnitDtoOutConverter.ToApi(logsLogUnitDtoOut)
            );
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
