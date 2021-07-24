namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiHouseDtoIn
    {
        public float[] EntrancePosition { get; set; }

        public uint EntranceDimension { get; set; }

        public float[] ExitPosition { get; set; }

        public uint ExitDimension { get; set; }

        public int? OwnerId { get; set; }

        public int? GarageId { get; set; }

        /// <summary>
        /// Состояние дверей.
        /// </summary>
        public bool LockDoors { get; set; }

        /// <summary>
        /// Государственная стоимость.
        /// </summary>
        public int Price { get; set; }

        public float[] SafePosition { get; set; }

        public uint SafeDimension { get; set; }

        /// <summary>
        /// Идентификатор инвентаря, представляемого сейфом.
        /// </summary>
        public int SafeInventoryId { get; set; }
    }
}
