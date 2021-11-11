namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiGarageDtoIn
    {
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
    }
}
