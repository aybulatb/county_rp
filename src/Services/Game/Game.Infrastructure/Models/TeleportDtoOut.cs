namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class TeleportDtoOut
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

        public string FactionId { get; }

        public int GangId { get; }

        public int RoomId { get; }

        public int BusinessId { get; }

        public bool LockDoors { get; }

        public TeleportDtoOut(
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
            string factionId,
            int gangId,
            int roomId,
            int businessId,
            bool lockDoors
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
            FactionId = factionId;
            GangId = gangId;
            RoomId = roomId;
            BusinessId = businessId;
            LockDoors = lockDoors;
        }
    }
}
