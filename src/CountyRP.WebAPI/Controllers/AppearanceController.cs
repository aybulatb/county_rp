using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using CountyRP.Models;
using CountyRP.WebAPI.Models;

namespace CountyRP.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppearanceController : ControllerBase
    {
        private AppearanceContext _appearanceContext;

        public AppearanceController(AppearanceContext appearanceContext)
        {
            _appearanceContext = appearanceContext;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Appearance), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var appearance = _appearanceContext.Appearances.AsNoTracking().FirstOrDefault(a => a.Id == id);

            if (appearance == null)
                return NotFound($"Внешность с ID {id} не найдена");

            return Ok(MapToModel(appearance));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Appearance), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody]Appearance appearance)
        {
            var error = CheckParams(appearance);
            if (error != null)
                return error;

            var appearanceEntity = MapToEntity(appearance);
            appearanceEntity.Id = 0;

            _appearanceContext.Appearances.Add(appearanceEntity);
            _appearanceContext.SaveChanges();

            return Created("", MapToModel(appearanceEntity));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Appearance), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Edit(int id, [FromBody]Appearance appearance)
        {
            if (appearance.Id != id)
                return BadRequest($"Указанный ID {id} не соответствует ID {appearance.Id} внешности");

            var appearanceEntity = _appearanceContext.Appearances.FirstOrDefault(a => a.Id == id);

            if (appearanceEntity == null)
                return NotFound($"Внешность с ID {id} не найдена");

            var error = CheckParams(appearance);
            if (error != null)
                return error;

            appearanceEntity.Gender = appearance.Gender;
            appearanceEntity.MotherBlend = appearance.MotherBlend;
            appearanceEntity.FatherBlend = appearance.FatherBlend;
            appearanceEntity.BlendShape = appearance.BlendShape;
            appearanceEntity.BlendSkin = appearance.BlendSkin;
            appearanceEntity.EyeColor = appearance.EyeColor;
            appearanceEntity.HairColor = appearance.HairColor;
            appearanceEntity.HairHighlight = appearance.HairHighlight;
            appearanceEntity.NoseWidth = appearance.NoseWidth;
            appearanceEntity.NoseHeight = appearance.NoseHeight;
            appearanceEntity.NoseBridge = appearance.NoseBridge;
            appearanceEntity.NoseTip = appearance.NoseTip;
            appearanceEntity.NoseBridgeShift = appearance.NoseBridgeShift;
            appearanceEntity.BrowHeight = appearance.BrowHeight;
            appearanceEntity.BrowWidth = appearance.BrowWidth;
            appearanceEntity.CBoneHeight = appearance.CBoneHeight;
            appearanceEntity.CBoneWidth = appearance.CBoneWidth;
            appearanceEntity.CheekWidth = appearance.CheekWidth;
            appearanceEntity.EyeColor = appearance.EyeColor;
            appearanceEntity.Lips = appearance.Lips;
            appearanceEntity.JawWidth = appearance.JawWidth;
            appearanceEntity.JawHeight = appearance.JawHeight;
            appearanceEntity.ChinLength = appearance.ChinLength;
            appearanceEntity.ChinPos = appearance.ChinPos;
            appearanceEntity.ChinWidth = appearance.ChinWidth;
            appearanceEntity.ChinShape = appearance.ChinShape;
            appearanceEntity.NeckWidth = appearance.NeckWidth;

            _appearanceContext.SaveChanges();

            return Ok(appearance);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var appearance = _appearanceContext.Appearances.FirstOrDefault(a => a.Id == id);

            if (appearance == null)
                return NotFound($"Внешность с ID {id} не найдена");

            _appearanceContext.Appearances.Remove(appearance);
            _appearanceContext.SaveChanges();

            return Ok();
        }

        private Entities.Appearance MapToEntity(Appearance a)
        {
            return new Entities.Appearance
            {
                Id = a.Id,
                Gender = a.Gender,
                MotherBlend = a.MotherBlend,
                FatherBlend = a.FatherBlend,
                BlendShape = a.BlendShape,
                BlendSkin = a.BlendSkin,
                EyeColor = a.EyeColor,
                HairColor = a.HairColor,
                HairHighlight = a.HairHighlight,
                NoseWidth = a.NoseWidth,
                NoseHeight = a.NoseHeight,
                NoseBridge = a.NoseBridge,
                NoseTip = a.NoseTip,
                NoseBridgeShift = a.NoseBridgeShift,
                BrowHeight = a.BrowHeight,
                BrowWidth = a.BrowWidth,
                CBoneHeight = a.CBoneHeight,
                CBoneWidth = a.CBoneWidth,
                CheekWidth = a.CheekWidth,
                Eyes = a.Eyes,
                Lips = a.Lips,
                JawWidth = a.JawWidth,
                JawHeight = a.JawHeight,
                ChinLength = a.ChinLength,
                ChinPos = a.ChinPos,
                ChinWidth = a.ChinWidth,
                ChinShape = a.ChinShape,
                NeckWidth = a.NeckWidth
        };
        }

        private Appearance MapToModel(Entities.Appearance a)
        {
            return new Appearance
            {
                Id = a.Id,
                Gender = a.Gender,
                MotherBlend = a.MotherBlend,
                FatherBlend = a.FatherBlend,
                BlendShape = a.BlendShape,
                BlendSkin = a.BlendSkin,
                EyeColor = a.EyeColor,
                HairColor = a.HairColor,
                HairHighlight = a.HairHighlight,
                NoseWidth = a.NoseWidth,
                NoseHeight = a.NoseHeight,
                NoseBridge = a.NoseBridge,
                NoseTip = a.NoseTip,
                NoseBridgeShift = a.NoseBridgeShift,
                BrowHeight = a.BrowHeight,
                BrowWidth = a.BrowWidth,
                CBoneHeight = a.CBoneHeight,
                CBoneWidth = a.CBoneWidth,
                CheekWidth = a.CheekWidth,
                Eyes = a.Eyes,
                Lips = a.Lips,
                JawWidth = a.JawWidth,
                JawHeight = a.JawHeight,
                ChinLength = a.ChinLength,
                ChinPos = a.ChinPos,
                ChinWidth = a.ChinWidth,
                ChinShape = a.ChinShape,
                NeckWidth = a.NeckWidth
            };
        }

        private IActionResult CheckParams(Appearance appearance)
        {
            if (appearance.BlendShape < 0.0f || appearance.BlendShape > 1.0f ||
                appearance.BlendSkin < 0.0f || appearance.BlendSkin > 1.0f ||
                appearance.NoseWidth < 0.0f || appearance.NoseWidth > 1.0f ||
                appearance.NoseHeight < 0.0f || appearance.NoseHeight > 1.0f ||
                appearance.NoseBridge < 0.0f || appearance.NoseBridge > 1.0f ||
                appearance.NoseTip < 0.0f || appearance.NoseTip > 1.0f ||
                appearance.NoseBridgeShift < 0.0f || appearance.NoseBridgeShift > 1.0f ||
                appearance.BrowHeight < 0.0f || appearance.BrowHeight > 1.0f ||
                appearance.BrowWidth < 0.0f || appearance.BrowWidth > 1.0f ||
                appearance.CBoneHeight < 0.0f || appearance.CBoneHeight > 1.0f ||
                appearance.CBoneWidth < 0.0f || appearance.CBoneWidth > 1.0f ||
                appearance.CheekWidth < 0.0f || appearance.CheekWidth > 1.0f ||
                appearance.Eyes < 0.0f || appearance.Eyes > 1.0f ||
                appearance.Lips < 0.0f || appearance.Lips > 1.0f ||
                appearance.JawWidth < 0.0f || appearance.JawWidth > 1.0f ||
                appearance.JawHeight < 0.0f || appearance.JawHeight > 1.0f ||
                appearance.ChinLength < 0.0f || appearance.ChinLength > 1.0f ||
                appearance.ChinPos < 0.0f || appearance.ChinPos > 1.0f ||
                appearance.ChinWidth < 0.0f || appearance.ChinWidth > 1.0f ||
                appearance.ChinShape < 0.0f || appearance.ChinShape > 1.0f ||
                appearance.NeckWidth < 0.0f || appearance.NeckWidth > 1.0f)
                return BadRequest("Вещественные параметры должны быть от 0.0 до 1.0");

            return null;
        }
    }
}
