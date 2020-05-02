using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CountyRP.Models;
using CountyRP.WebAPI.Extensions;
using CountyRP.WebAPI.Models;

namespace CountyRP.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessController : ControllerBase
    {
        private PlayerContext _playerContext;
        private PropertyContext _propertyContext;

        public BusinessController(PlayerContext playerContext, PropertyContext propertyContext)
        {
            _playerContext = playerContext;
            _propertyContext = propertyContext;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Business), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody]Business business)
        {
            var result = CheckParams(business);
            if (result != null)
                return result;

            Entities.Business businessEntity = new Entities.Business().Format(business);

            _propertyContext.Businesses.Add(businessEntity);
            _propertyContext.SaveChanges();

            business.Id = businessEntity.Id;

            return Ok(business);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Business), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            Entities.Business business = _propertyContext.Businesses
                .FirstOrDefault(b => b.Id == id);
            if (business == null)
                return NotFound($"Бизнес с ID {id} не найден");

            return Ok(new Business().Format(business));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Business), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Edit(int id, [FromBody]Business business)
        {
            if (id != business.Id)
                return BadRequest($"Указанный ID {id} не соответствует ID бизнеса {business.Id}");

            Entities.Business businessEntity = _propertyContext.Businesses.FirstOrDefault(b => b.Id == id);
            if (businessEntity == null)
                return NotFound($"Бизнес с ID {id} не найден");

            var result = CheckParams(business);
            if (result != null)
                return result;

            businessEntity = businessEntity.Format(business);

            _propertyContext.Businesses.Update(businessEntity);
            _propertyContext.SaveChanges();

            return Ok(business);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            Entities.Business business = _propertyContext.Businesses.FirstOrDefault(b => b.Id == id);
            if (business == null)
                return NotFound($"Бизнес с ID {id} не найден");

            _propertyContext.Businesses.Remove(business);
            _propertyContext.SaveChanges();

            return Ok();
        }

        private IActionResult CheckParams(Business business)
        {
            var result = CheckOwner(business);
            if (result != null)
                return result;

            return null;
        }

        private IActionResult CheckOwner(Business business)
        {
            if (business.OwnerId != 0 &&
                _playerContext.Persons.FirstOrDefault(p => p.Id == business.OwnerId) == null)
                return BadRequest($"Персонаж с ID {business.OwnerId} не найден");

            return null;
        }
    }
}
