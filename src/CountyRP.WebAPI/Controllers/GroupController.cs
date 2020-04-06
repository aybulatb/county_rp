using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using CountyRP.Entities;
using CountyRP.WebAPI.Models;

namespace CountyRP.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase 
    {
        private GroupContext _groupContext;

        public GroupController(GroupContext groupContext)
        {
            _groupContext = groupContext;
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(Group), StatusCodes.Status201Created)]
        public IActionResult Create([FromBody]Group createGroup)
        {
            _groupContext.Groups.Add(createGroup);
            _groupContext.SaveChanges();

            return Created("", createGroup);
        }

        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(Group), StatusCodes.Status200OK)]
        public IActionResult GetById(string id)
        {
            Group group = _groupContext.Groups.FirstOrDefault(g => g.Id == id);

            if (group == null)
                return BadRequest();

            return Ok(group);
        }
    }
}
