namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiGarageDtoOut
    {
        public int Id { get; init; }

        public int Type { get; init; }

        public float[] EntrancePosition { get; init; }

        public uint EntranceDimension { get; init; }

        /// <summary>
        /// Угол поворота при телепортации на вход.
        /// </summary>
        public float EntranceRotation { get; init; }

        public uint ExitDimension { get; init; }

        /// <summary>
        /// Состояние дверей.
        /// </summary>
        public bool LockDoors { get; init; }

        public ApiGarageDtoOut(
            int id,
            int type,
            float[] entrancePosition,
            uint entranceDimension,
            float entranceRotation,
            uint exitDimension,
            bool lockDoors
        )
        {
            Id = id;
            Type = type;
            EntrancePosition = entrancePosition;
            EntranceDimension = entranceDimension;
            EntranceRotation = entranceRotation;
            ExitDimension = exitDimension;
            LockDoors = lockDoors;
        }
    }
}
