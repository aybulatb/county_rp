namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiBusinessDtoIn
    {
        public string Name { get; init; }

        public float[] EntrancePosition { get; init; }

        public uint EntranceDimension { get; init; }

        public float[] ExitPosition { get; init; }

        public uint ExitDimension { get; init; }

        public int? OwnerId { get; init; }

        public bool LockDoors { get; init; }

        public ApiBusinessTypeDto Type { get; init; }

        /// <summary>
        /// Государственная стоимость.
        /// </summary>
        public int Price { get; init; }
    }
}
