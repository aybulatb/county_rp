namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class GarageDtoIn
    {
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

        public GarageDtoIn(
            int type,
            float[] entrancePosition,
            uint entranceDimension,
            float entranceRotation,
            uint exitDimension,
            bool lockDoors
        )
        {
            Type = type;
            EntrancePosition = entrancePosition;
            EntranceDimension = entranceDimension;
            EntranceRotation = entranceRotation;
            ExitDimension = exitDimension;
            LockDoors = lockDoors;
        }
    }
}
