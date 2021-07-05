using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Game.Infrastructure.Entities
{
    public class HouseDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [NotMapped]
        public float[] EntrancePosition
        {
            get { return JsonConvert.DeserializeObject<float[]>(_EntrancePosition); }
            set { _EntrancePosition = JsonConvert.SerializeObject(value); }
        }

        public uint EntranceDimension { get; set; }

        [NotMapped]
        public float[] ExitPosition
        {
            get { return JsonConvert.DeserializeObject<float[]>(_ExitPosition); }
            set { _ExitPosition = JsonConvert.SerializeObject(value); }
        }

        public uint ExitDimension { get; set; }

        public int OwnerId { get; set; }

        public int GarageId { get; set; }

        /// <summary>
        /// Состояние дверей.
        /// </summary>
        public bool LockDoors { get; set; }

        /// <summary>
        /// Государственная стоимость.
        /// </summary>
        public int Price { get; set; }

        [NotMapped]
        public float[] SafePosition
        {
            get => JsonConvert.DeserializeObject<float[]>(_SafePosition);
            set => _SafePosition = JsonConvert.SerializeObject(value);
        }

        public uint SafeDimension { get; set; }

        /// <summary>
        /// Идентификатор инвентаря, представляемого сейфом.
        /// </summary>
        public int SafeInventoryId { get; set; }

        [Column("EntrancePosition")]
        public string _EntrancePosition { get; set; }

        [Column("ExitPosition")]
        public string _ExitPosition { get; set; }

        [Column("SafePosition")]
        public string _SafePosition { get; set; }

        /// <summary>
        /// Конструктор для EF.
        /// </summary>
        public HouseDao()
        {
        }

        public HouseDao(
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
