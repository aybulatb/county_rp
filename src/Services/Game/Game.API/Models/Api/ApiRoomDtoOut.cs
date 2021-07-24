using System;

namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiRoomDtoOut
    {
        public int Id { get; }

        public string Name { get; }

        public float[] EntrancePosition { get; }

        public uint EntranceDimension { get; }

        public float[] ExitPosition { get; }

        public uint ExitDimension { get; }

        public int TypeMarker { get; }

        /// <summary>
        /// RGB-цвета маркера на карте.
        /// </summary>
        public int[] ColorMarker { get; }

        public int TypeBlip { get; }

        public byte ColorBlip { get; }

        public int? GangId { get; }

        public bool LockDoors { get; }

        public int Price { get; }

        public DateTimeOffset LastPaymentDate { get; }

        public float[] SafePosition { get; }

        public uint SafeDimension { get; }

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
