using System;

namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiRoomDtoIn
    {
        public string Name { get; init; }

        public float[] EntrancePosition { get; init; }

        public uint EntranceDimension { get; init; }

        public float[] ExitPosition { get; init; }

        public uint ExitDimension { get; init; }

        public int TypeMarker { get; init; }

        /// <summary>
        /// RGB-цвета маркера на карте.
        /// </summary>
        public int[] ColorMarker { get; init; }

        public int TypeBlip { get; init; }

        public byte ColorBlip { get; init; }

        public int? GangId { get; init; }

        public bool LockDoors { get; init; }

        public int Price { get; init; }

        public DateTimeOffset LastPaymentDate { get; init; }

        public float[] SafePosition { get; init; }

        public uint SafeDimension { get; init; }
    }
}
