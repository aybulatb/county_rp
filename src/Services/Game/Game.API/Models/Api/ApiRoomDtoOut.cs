using System;

namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiRoomDtoOut
    {
        public int Id { get; init; }

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

        public ApiRoomDtoOut(
            int id,
            string name,
            float[] entrancePosition,
            uint entranceDimension,
            float[] exitPosition,
            uint exitDimension,
            int typeMarker,
            int[] colorMarker,
            int typeBlip,
            byte colorBlip,
            int? gangId,
            bool lockDoors,
            int price,
            DateTimeOffset lastPaymentDate,
            float[] safePosition,
            uint safeDimension
        )
        {
            Id = id;
            Name = name;
            EntrancePosition = entrancePosition;
            EntranceDimension = entranceDimension;
            ExitPosition = exitPosition;
            ExitDimension = exitDimension;
            TypeMarker = typeMarker;
            ColorMarker = colorMarker;
            TypeBlip = typeBlip;
            ColorBlip = colorBlip;
            GangId = gangId;
            LockDoors = lockDoors;
            Price = price;
            LastPaymentDate = lastPaymentDate;
            SafePosition = safePosition;
            SafeDimension = safeDimension;
        }
    }
}
