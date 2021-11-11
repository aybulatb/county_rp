namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiAppearanceDtoIn
    {
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
    }
}
