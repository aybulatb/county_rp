using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using CountyRP.Models;
using CountyRP.WebAPI.Extensions;
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
        public IActionResult Create([FromBody]Group group)
        {
            var result = CheckParams(group);
            if (result != null)
                return result;

            if (_groupContext.Groups.FirstOrDefault(g => g.Id == group.Id) != null)
                return BadRequest($"Группа с ID {group.Id} уже существует");

            Entities.Group groupEntity = new Entities.Group().Format(group);

            _groupContext.Groups.Add(groupEntity);
            _groupContext.SaveChanges();

            return Created("", group);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Group), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetById(string id)
        {
            Entities.Group group = _groupContext.Groups.FirstOrDefault(g => g.Id == id);

            if (group == null)
                return NotFound($"Группа с ID {id} не найдена");

            return Ok(new Group().Format(group));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Group>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            List<Entities.Group> group = _groupContext.Groups.ToList();

            return Ok(group.Select(g => new Group().Format(g)).ToList());
        }

        [HttpGet("GetWithPageAndCount")]
        [ProducesResponseType(typeof(List<Group>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult GetWithPageAndCount(int page, int count)
        {
            if (page < 1)
                return BadRequest("Номер страницы групп не может быть меньше 1");

            if (count < 1 || count > 50)
                return BadRequest("Количество групп на одной странице должно быть от 1 до 50");

            List<Entities.Group> group = _groupContext.Groups
                .Skip((page - 1) * count)
                .Take(count)
                .ToList();

            return Ok(group.Select(g => new Group().Format(g)).ToList());
        }

        [HttpGet("Count")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public IActionResult GetCount()
        {
            return Ok(_groupContext.Groups.Count());
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Group), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Edit(string id, Group group)
        {
            if (id != group.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID группы {group.Id}");

            Entities.Group groupEntity = _groupContext.Groups.AsNoTracking()
                .FirstOrDefault(g => g.Id == id);

            if (groupEntity == null)
                return NotFound($"Группа с ID {id} не найдена");

            var result = CheckParams(group);
            if (result != null)
                return result;

            groupEntity = groupEntity.Format(group);

            _groupContext.Groups.Update(groupEntity);
            _groupContext.SaveChanges();

            return Ok(group);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Delete(string id)
        {
            Entities.Group group = _groupContext.Groups.FirstOrDefault(g => g.Id == id);

            if (group == null)
                return NotFound($"Группа с ID {id} не найдена");

            _groupContext.Groups.Remove(group);
            _groupContext.SaveChanges();

            return Ok();
        }

        private IActionResult CheckParams(Group group)
        {
            TrimParams(group);

            if (group.Id == null || group.Id.Length < 3 || group.Id.Length > 16)
                return BadRequest("ID группы должно состоять от 3 до 16 символов");

            if (group.Name == null || group.Name.Length < 3 || group.Name.Length > 32)
                return BadRequest("Название группы должно состоять от 3 до 32 символов");

            if (group.Color == null || !System.Text.RegularExpressions.Regex.IsMatch(group.Color, "^[0-9a-fA-F]{6}$"))
                return BadRequest("Цвет должна состоять только из следующих символов: 0-9, A-F");

            return null;
        }

        private void TrimParams(Group group)
        {
            group.Id = group.Id?.Trim();
            group.Name = group.Name?.Trim();
            group.Color = group.Color?.Trim();
        }
    }
}
