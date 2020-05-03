using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using CountyRP.Models;
using CountyRP.WebAPI.Models;
using CountyRP.WebAPI.Extensions;

namespace CountyRP.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GangController : ControllerBase
    {
        private GangContext _gangContext;

        public GangController(GangContext gangContext)
        {
            _gangContext = gangContext;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Gang), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Create(Gang gang)
        {
            var result = CheckParams(gang);
            if (result != null)
                return result;

            Entities.Gang gangEntity = new Entities.Gang().Format(gang);

            _gangContext.Gangs.Add(gangEntity);
            _gangContext.SaveChanges();

            gang.Id = gangEntity.Id;

            return Created("", gang);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Gang), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            Entities.Gang gang = _gangContext.Gangs.FirstOrDefault(g => g.Id == id);

            if (gang == null)
                return NotFound($"Группировка с ID {id} не найдена");

            return Ok(new Gang().Format(gang));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Gang>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            List<Gang> gangs = _gangContext.Gangs
                .Select(g => new Gang().Format(g))
                .ToList();

            return Ok(gangs);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Gang), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Edit(int id, Gang gang)
        {
            if (id != gang.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID {gang.Id} группировки");

            Entities.Gang gangEntity = _gangContext.Gangs.FirstOrDefault(g => g.Id == id);
            if (gangEntity == null)
                return NotFound($"Группировка с ID {id} не найдена");

            var result = CheckParams(gang);
            if (result != null)
                return result;

            gangEntity = gangEntity.Format(gang);

            _gangContext.SaveChanges();

            return Ok(gang);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            Entities.Gang gang = _gangContext.Gangs
                .FirstOrDefault(g => g.Id == id);

            if (gang == null)
                return NotFound($"Группировка с ID {id} не найдена");

            _gangContext.Gangs.Remove(gang);
            _gangContext.SaveChanges();

            return Ok();
        }

        private IActionResult CheckParams(Gang gang)
        {
            TrimParams(gang);

            if (gang.Name == null || gang.Name.Length < 3 || gang.Name.Length > 32)
                return BadRequest("Название должно быть от 3 до 32 символов");

            if (gang.Ranks == null || gang.Ranks.Length != Constants.MaxGangRanks)
                return BadRequest($"Количество рангов должно быть {Constants.MaxGangRanks}");

            foreach (string rank in gang.Ranks)
            {
                if (rank == null || rank.Length < 1 || rank.Length > 32)
                    return BadRequest("Название ранга должно быть от 1 до 32 символов");
            }

            if (gang.Type < GangType.None)
                return BadRequest("Тип группировки должно быть от 0 до 1");

            return null;
        }

        private void TrimParams(Gang gang)
        {
            gang.Name = gang.Name?.Trim();
            for (int i = 0; i < gang.Ranks?.Length; i++)
                gang.Ranks[i] = gang.Ranks[i]?.Trim();
        }
    }
}
