namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiBusinessDtoIn
    {
        public string Name { get; set; }

        public float[] EntrancePosition { get; set; }

        public uint EntranceDimension { get; set; }

        public float[] ExitPosition { get; set; }

        public uint ExitDimension { get; set; }

        public int? OwnerId { get; set; }

        public bool LockDoors { get; set; }

        public ApiBusinessTypeDto Type { get; set; }

        /// <summary>
        /// Государственная стоимость.
        /// </summary>
        public int Price { get; set; }
    }
}
