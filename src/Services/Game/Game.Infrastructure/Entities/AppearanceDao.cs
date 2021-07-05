using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Game.Infrastructure.Entities
{
    public class AppearanceDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public bool Gender { get; set; }

        public int MotherBlend { get; set; }

        public int FatherBlend { get; set; }

        public float BlendShape { get; set; }

        public float BlendSkin { get; set; }

        public int EyeColor { get; set; }

        public int HairColor { get; set; }

        public int HairHighlight { get; set; }

        public float NoseWidth { get; set; }

        public float NoseHeight { get; set; }

        public float NoseBridge { get; set; }

        public float NoseTip { get; set; }

        public float NoseBridgeShift { get; set; }

        public float BrowHeight { get; set; }

        public float BrowWidth { get; set; }

        public float CBoneHeight { get; set; }

        public float CBoneWidth { get; set; }

        public float CheekWidth { get; set; }

        public float Eyes { get; set; }

        public float Lips { get; set; }

        public float JawWidth { get; set; }

        public float JawHeight { get; set; }

        public float ChinLength { get; set; }

        public float ChinPos { get; set; }

        public float ChinWidth { get; set; }

        public float ChinShape { get; set; }

        public float NeckWidth { get; set; }

        /// <summary>
        /// Конструктор для EF.
        /// </summary>
        public AppearanceDao()
        {
        }

        public AppearanceDao(
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
