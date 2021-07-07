namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class HouseDtoOut
    {
        public int Id { get; }

        public float[] EntrancePosition { get; }

        public uint EntranceDimension { get; }

        public float[] ExitPosition { get; }

        public uint ExitDimension { get; }

        public int OwnerId { get; }

        public int GarageId { get; }

        /// <summary>
        /// Состояние дверей.
        /// </summary>
        public bool LockDoors { get; }

        /// <summary>
        /// Государственная стоимость.
        /// </summary>
        public int Price { get; }

        public float[] SafePosition { get; }

        public uint SafeDimension { get; }

        /// <summary>
        /// Идентификатор инвентаря, представляемого сейфом.
        /// </summary>
        public int SafeInventoryId { get; }

        public HouseDtoOut(
            int id,
            float[] entrancePosition,
            uint entranceDimension,
            float[] exitPosition,
            uint exitDimension,
            int ownerId,
            int garageId,
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
