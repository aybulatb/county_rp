using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class AppearanceDtoOutConverter
    {
        public static ApiAppearanceDtoOut ToApi(
            AppearanceDtoOut source
        )
        {
            return new ApiAppearanceDtoOut(
                id: source.Id,
                gender: source.Gender,
                motherBlend: source.MotherBlend,
                fatherBlend: source.FatherBlend,
                blendShape: source.BlendShape,
                blendSkin: source.BlendSkin,
                eyeColor: source.EyeColor,
                hairColor: source.HairColor,
                hairHighlight: source.HairHighlight,
                noseWidth: source.NoseWidth,
                noseHeight: source.NoseHeight,
                noseBridge: source.NoseBridge,
                noseTip: source.NoseTip,
                noseBridgeShift: source.NoseBridgeShift,
                browHeight: source.BrowHeight,
                browWidth: source.BrowWidth,
                cBoneHeight: source.CBoneHeight,
                cBoneWidth: source.CBoneWidth,
                cheekWidth: source.CheekWidth,
                eyes: source.Eyes,
                lips: source.Lips,
                jawWidth: source.JawWidth,
                jawHeight: source.JawHeight,
                chinLength: source.ChinLength,
                chinPos: source.ChinPos,
                chinWidth: source.ChinWidth,
                chinShape: source.ChinShape,
                neckWidth: source.NeckWidth
            );
        }
    }
}
