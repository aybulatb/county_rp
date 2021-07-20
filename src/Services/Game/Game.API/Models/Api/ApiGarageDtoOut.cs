namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiGarageDtoOut
    {
        public int Id { get; }

        public int Type { get; }

        public float[] EntrancePosition { get; }

        public uint EntranceDimension { get; }

        /// <summary>
        /// Угол поворота при телепортации на вход.
        /// </summary>
        public float EntranceRotation { get; }

        public uint ExitDimension { get; }

        /// <summary>
        /// Состояние дверей.
        /// </summary>
        public bool LockDoors { get; }

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
