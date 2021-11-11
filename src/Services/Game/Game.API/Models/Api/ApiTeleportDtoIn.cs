namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiTeleportDtoIn
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

        public string FactionId { get; init; }

        public int? GangId { get; init; }

        public int? RoomId { get; init; }

        public int? BusinessId { get; init; }

        public bool LockDoors { get; init; }
    }
}
