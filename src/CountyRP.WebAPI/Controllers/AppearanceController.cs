using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using CountyRP.Models;
using CountyRP.WebAPI.DbContexts;

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
        public async Task<IActionResult> Create([FromBody]Appearance appearance)
        {
            var error = CheckParams(appearance);
            if (error != null)
                return error;

            var appearanceDAO = MapToDAO(appearance);
            appearanceDAO.Id = 0;

            _appearanceContext.Appearances.Add(appearanceDAO);
            await _appearanceContext.SaveChangesAsync();

            return Created("", MapToModel(appearanceDAO));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Appearance), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(int id, [FromBody]Appearance appearance)
        {
            if (appearance.Id != id)
                return BadRequest($"Указанный ID {id} не соответствует ID {appearance.Id} внешности");

            var appearanceDAO = _appearanceContext.Appearances.AsNoTracking().FirstOrDefault(a => a.Id == id);

            if (appearanceDAO == null)
                return NotFound($"Внешность с ID {id} не найдена");

            var error = CheckParams(appearance);
            if (error != null)
                return error;

            appearanceDAO = MapToDAO(appearance);

            _appearanceContext.Appearances.Update(appearanceDAO);
            await _appearanceContext.SaveChangesAsync();

            return Ok(appearance);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var appearance = _appearanceContext.Appearances.FirstOrDefault(a => a.Id == id);

            if (appearance == null)
                return NotFound($"Внешность с ID {id} не найдена");

            _appearanceContext.Appearances.Remove(appearance);
            await _appearanceContext.SaveChangesAsync();

            return Ok();
        }

        private DAO.Appearance MapToDAO(Appearance appearance)
        {
            return new DAO.Appearance
            {
                Id = appearance.Id,
                Gender = appearance.Gender,
                MotherBlend = appearance.MotherBlend,
                FatherBlend = appearance.FatherBlend,
                BlendShape = appearance.BlendShape,
                BlendSkin = appearance.BlendSkin,
                EyeColor = appearance.EyeColor,
                HairColor = appearance.HairColor,
                HairHighlight = appearance.HairHighlight,
                NoseWidth = appearance.NoseWidth,
                NoseHeight = appearance.NoseHeight,
                NoseBridge = appearance.NoseBridge,
                NoseTip = appearance.NoseTip,
                NoseBridgeShift = appearance.NoseBridgeShift,
                BrowHeight = appearance.BrowHeight,
                BrowWidth = appearance.BrowWidth,
                CBoneHeight = appearance.CBoneHeight,
                CBoneWidth = appearance.CBoneWidth,
                CheekWidth = appearance.CheekWidth,
                Eyes = appearance.Eyes,
                Lips = appearance.Lips,
                JawWidth = appearance.JawWidth,
                JawHeight = appearance.JawHeight,
                ChinLength = appearance.ChinLength,
                ChinPos = appearance.ChinPos,
                ChinWidth = appearance.ChinWidth,
                ChinShape = appearance.ChinShape,
                NeckWidth = appearance.NeckWidth
        };
        }

        private Appearance MapToModel(DAO.Appearance appearance)
        {
            return new Appearance
            {
                Id = appearance.Id,
                Gender = appearance.Gender,
                MotherBlend = appearance.MotherBlend,
                FatherBlend = appearance.FatherBlend,
                BlendShape = appearance.BlendShape,
                BlendSkin = appearance.BlendSkin,
                EyeColor = appearance.EyeColor,
                HairColor = appearance.HairColor,
                HairHighlight = appearance.HairHighlight,
                NoseWidth = appearance.NoseWidth,
                NoseHeight = appearance.NoseHeight,
                NoseBridge = appearance.NoseBridge,
                NoseTip = appearance.NoseTip,
                NoseBridgeShift = appearance.NoseBridgeShift,
                BrowHeight = appearance.BrowHeight,
                BrowWidth = appearance.BrowWidth,
                CBoneHeight = appearance.CBoneHeight,
                CBoneWidth = appearance.CBoneWidth,
                CheekWidth = appearance.CheekWidth,
                Eyes = appearance.Eyes,
                Lips = appearance.Lips,
                JawWidth = appearance.JawWidth,
                JawHeight = appearance.JawHeight,
                ChinLength = appearance.ChinLength,
                ChinPos = appearance.ChinPos,
                ChinWidth = appearance.ChinWidth,
                ChinShape = appearance.ChinShape,
                NeckWidth = appearance.NeckWidth
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
