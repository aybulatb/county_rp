using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using CountyRP.Models;
using CountyRP.WebSite.Exceptions;
using CountyRP.WebSite.Services.Interfaces;
using CountyRP.WebSite.Models.ViewModels;

namespace CountyRP.WebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonAdapter _personAdapter;

        public PersonController(IPersonAdapter personAdapter)
        {
            _personAdapter = personAdapter;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Person person;

            try
            {
                person = await _personAdapter.GetById(id);
            }
            catch (AdapterException ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(person);
        }

        [HttpGet("FilterBy")]
        public async Task<IActionResult> FilterBy(int page, string name)
        {
            FilteredModels<Person> persons;

            try
            {
                persons = await _personAdapter.FilterBy(page, 20, name);
            }
            catch (AdapterException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(persons);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody]Person person)
        {
            try
            {
                person = await _personAdapter.Edit(id, person);
            }
            catch (AdapterException ex) when (ex.StatusCode == StatusCodes.Status400BadRequest)
            {
                return BadRequest(ex.Message);
            }
            catch (AdapterException ex) when (ex.StatusCode == StatusCodes.Status404NotFound)
            {
                return NotFound(ex.Message);
            }

            return Ok(person);
        }
    }
}
