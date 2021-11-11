namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiHouseDtoIn
    {
        public float[] EntrancePosition { get; init; }

        public uint EntranceDimension { get; init; }

        public float[] ExitPosition { get; init; }

        public uint ExitDimension { get; init; }

        public int? OwnerId { get; init; }

        public int? GarageId { get; init; }

        /// <summary>
        /// Состояние дверей.
        /// </summary>
        public bool LockDoors { get; init; }

        /// <summary>
        /// Государственная стоимость.
        /// </summary>
        public int Price { get; init; }

        public float[] SafePosition { get; init; }

        public uint SafeDimension { get; init; }

        /// <summary>
        /// Идентификатор инвентаря, представляемого сейфом.
        /// </summary>
        public int SafeInventoryId { get; init; }
    }
}
