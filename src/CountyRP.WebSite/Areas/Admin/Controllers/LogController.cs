using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CountyRP.Models;
using CountyRP.WebSite.Exceptions;
using CountyRP.WebSite.Models.ViewModels;
using CountyRP.WebSite.Services.Interfaces;

namespace CountyRP.WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    public class LogController : ControllerBase
    {
        private ILogAdapter _logAdapter;

        public LogController(ILogAdapter logAdapter)
        {
            _logAdapter = logAdapter;
        }

        public async Task<IActionResult> FilterBy(int page)
        {
            FilteredModels<LogUnit> filteredLogUnits;

            try
            {
                filteredLogUnits = await _logAdapter.FilterBy(page, 50);
            }
            catch (AdapterException ex) when (ex.StatusCode == StatusCodes.Status400BadRequest)
            {
                return BadRequest(ex.Message);
            }

            return Ok(filteredLogUnits);
        }
    }
}
