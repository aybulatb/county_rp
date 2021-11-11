namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiAppearanceDtoOut
    {
        public int Id { get; init; }

        public bool Gender { get; init; }

        public int MotherBlend { get; init; }

        public int FatherBlend { get; init; }

        public float BlendShape { get; init; }

        public float BlendSkin { get; init; }

        public int EyeColor { get; init; }

        public int HairColor { get; init; }

        public int HairHighlight { get; init; }

        public float NoseWidth { get; init; }

        public float NoseHeight { get; init; }

        public float NoseBridge { get; init; }

        public float NoseTip { get; init; }

        public float NoseBridgeShift { get; init; }

        public float BrowHeight { get; init; }

        public float BrowWidth { get; init; }

        public float CBoneHeight { get; init; }

        public float CBoneWidth { get; init; }

        public float CheekWidth { get; init; }

        public float Eyes { get; init; }

        public float Lips { get; init; }

        public float JawWidth { get; init; }

        public float JawHeight { get; init; }

        public float ChinLength { get; init; }

        public float ChinPos { get; init; }

        public float ChinWidth { get; init; }

        public float ChinShape { get; init; }

        public float NeckWidth { get; init; }

        public ApiAppearanceDtoOut(
            int id,
            bool gender,
            int motherBlend,
            int fatherBlend,
            float blendShape,
            float blendSkin,
            int eyeColor,
            int hairColor,
            int hairHighlight,
            float noseWidth,
            float noseHeight,
            float noseBridge,
            float noseTip,
            float noseBridgeShift,
            float browHeight,
            float browWidth,
            float cBoneHeight,
            float cBoneWidth,
            float cheekWidth,
            float eyes,
            float lips,
            float jawWidth,
            float jawHeight,
            float chinLength,
            float chinPos,
            float chinWidth,
            float chinShape,
            float neckWidth
        )
        {
            Id = id;
            Gender = gender;
            MotherBlend = motherBlend;
            FatherBlend = fatherBlend;
            BlendShape = blendShape;
            BlendSkin = blendSkin;
            EyeColor = eyeColor;
            HairColor = hairColor;
            HairHighlight = hairHighlight;
            NoseWidth = noseWidth;
            NoseHeight = noseHeight;
            NoseBridge = noseBridge;
            NoseTip = noseTip;
            NoseBridgeShift = noseBridgeShift;
            BrowHeight = browHeight;
            BrowWidth = browWidth;
            CBoneHeight = cBoneHeight;
            CBoneWidth = cBoneWidth;
            CheekWidth = cheekWidth;
            Eyes = eyes;
            Lips = lips;
            JawWidth = jawWidth;
            JawHeight = jawHeight;
            ChinLength = chinLength;
            ChinPos = chinPos;
            ChinWidth = chinWidth;
            ChinShape = chinShape;
            NeckWidth = neckWidth;
        }
    }
}
