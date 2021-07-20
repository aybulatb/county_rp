namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiGarageDtoIn
    {
        public int Type { get; set; }

        public float[] EntrancePosition { get; set; }

        public uint EntranceDimension { get; set; }

        /// <summary>
        /// Угол поворота при телепортации на вход.
        /// </summary>
        public float EntranceRotation { get; set; }

        public uint ExitDimension { get; set; }

        /// <summary>
        /// Состояние дверей.
        /// </summary>
        public bool LockDoors { get; set; }
    }
}
