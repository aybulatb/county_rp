namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiBusinessDtoOut
    {
        public int Id { get; init; }

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

        public ApiBusinessDtoOut(
            int id,
            string name,
            float[] entrancePosition,
            uint entranceDimension,
            float[] exitPosition,
            uint exitDimension,
            int? ownerId,
            bool lockDoors,
            ApiBusinessTypeDto type,
            int price
        )
        {
            Id = id;
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
