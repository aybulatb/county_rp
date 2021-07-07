namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class AppearanceDtoIn
    {
        public bool Gender { get; }

        public int MotherBlend { get; }

        public int FatherBlend { get; }

        public float BlendShape { get; }

        public float BlendSkin { get; }

        public int EyeColor { get; }

        public int HairColor { get; }

        public int HairHighlight { get; }

        public float NoseWidth { get; }

        public float NoseHeight { get; }

        public float NoseBridge { get; }

        public float NoseTip { get; }

        public float NoseBridgeShift { get; }

        public float BrowHeight { get; }

        public float BrowWidth { get; }

        public float CBoneHeight { get; }

        public float CBoneWidth { get; }

        public float CheekWidth { get; }

        public float Eyes { get; }

        public float Lips { get; }

        public float JawWidth { get; }

        public float JawHeight { get; }

        public float ChinLength { get; }

        public float ChinPos { get; }

        public float ChinWidth { get; }

        public float ChinShape { get; }

        public float NeckWidth { get; }

        public AppearanceDtoIn(
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
