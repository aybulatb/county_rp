namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiHouseDtoOut
    {
        public int Id { get; init; }

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

        public ApiHouseDtoOut(
            int id,
            float[] entrancePosition,
            uint entranceDimension,
            float[] exitPosition,
            uint exitDimension,
            int? ownerId,
            int? garageId,
            bool lockDoors,
            int price,
            float[] safePosition,
            uint safeDimension,
            int safeInventoryId
        )
        {
            Id = id;
            EntrancePosition = entrancePosition;
            EntranceDimension = entranceDimension;
            ExitPosition = exitPosition;
            ExitDimension = exitDimension;
            OwnerId = ownerId;
            GarageId = garageId;
            LockDoors = lockDoors;
            Price = price;
            SafePosition = safePosition;
            SafeDimension = safeDimension;
            SafeInventoryId = safeInventoryId;
        }
    }
}
