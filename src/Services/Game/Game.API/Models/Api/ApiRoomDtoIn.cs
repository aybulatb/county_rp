using System;

namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiRoomDtoIn
    {
        public string Name { get; set; }

        public float[] EntrancePosition { get; set; }

        public uint EntranceDimension { get; set; }

        public float[] ExitPosition { get; set; }

        public uint ExitDimension { get; set; }

        public int TypeMarker { get; set; }

        /// <summary>
        /// RGB-цвета маркера на карте.
        /// </summary>
        public int[] ColorMarker { get; set; }

        public int TypeBlip { get; set; }

        public byte ColorBlip { get; set; }

        public int? GangId { get; set; }

        public bool LockDoors { get; set; }

        public int Price { get; set; }

        public DateTimeOffset LastPaymentDate { get; set; }

        public float[] SafePosition { get; set; }

        public uint SafeDimension { get; set; }
    }
}
