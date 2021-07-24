namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class BusinessDtoIn
    {
        public string Name { get; }

        public float[] EntrancePosition { get; }

        public uint EntranceDimension { get; }

        public float[] ExitPosition { get; }

        public uint ExitDimension { get; }

        public int? OwnerId { get; }

        public bool LockDoors { get; }

        public BusinessTypeDto Type { get; }

        /// <summary>
        /// Государственная стоимость.
        /// </summary>
        public int Price { get; }

        public BusinessDtoIn(
            string name,
            float[] entrancePosition,
            uint entranceDimension,
            float[] exitPosition,
            uint exitDimension,
            int? ownerId,
            bool lockDoors,
            BusinessTypeDto type,
            int price
        )
        {
            Name = name;
            EntrancePosition = entrancePosition;
            EntranceDimension = entranceDimension;
            ExitPosition = exitPosition;
            ExitDimension = exitDimension;
            OwnerId = ownerId;
            LockDoors = lockDoors;
            Type = type;
            Price = price;
        }
    }
}
