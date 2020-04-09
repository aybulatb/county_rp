using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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
        [ProducesResponseType(typeof(Group), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody]Group createGroup)
        {
            var result = CheckParams(createGroup);
            if (result != null)
                return result;

            if (_groupContext.Groups.FirstOrDefault(g => g.Id == createGroup.Id) != null)
                return BadRequest($"Группа с ID {createGroup.Id} уже существует");

            _groupContext.Groups.Add(createGroup);
            _groupContext.SaveChanges();

            return Created("", createGroup);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Group), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetById(string id)
        {
            Group group = _groupContext.Groups.FirstOrDefault(g => g.Id == id);

            if (group == null)
                return NotFound($"Группа с ID {id} не найдена");

            return Ok(group);
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(List<Group>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            List<Group> group = _groupContext.Groups.ToList();

            return Ok(group);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Group), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Edit(Group group)
        {
            Group existingGroup = _groupContext.Groups.AsNoTracking()
                .FirstOrDefault(g => g.Id == group.Id);

            if (existingGroup == null)
                return NotFound($"Группа с ID {group.Id} не найдена");

            var result = CheckParams(group);
            if (result != null)
                return result;

            _groupContext.Groups.Update(group);
            _groupContext.SaveChanges();

            return Ok(group);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Delete(string id)
        {
            Group group = _groupContext.Groups.FirstOrDefault(g => g.Id == id);

            if (group == null)
                return NotFound($"Группа с ID {id} не найдена");

            _groupContext.Groups.Remove(group);
            _groupContext.SaveChanges();

            return Ok();
        }

        private IActionResult CheckParams(Group group)
        {
            if (group.Id.Length < 3 || group.Id.Length > 16)
                return BadRequest("ID группы должно состоять от 3 до 16 символов");

            if (group.Name.Length < 3 || group.Name.Length > 32)
                return BadRequest("Название группы должно состоять от 3 до 32 символов");

            if (!System.Text.RegularExpressions.Regex.IsMatch(group.Color, "[0-9a-fA-F]{6}"))
                return BadRequest("Цвет должна состоять только из следующих символов: 0-9, A-F");

            return null;
        }
    }
}
