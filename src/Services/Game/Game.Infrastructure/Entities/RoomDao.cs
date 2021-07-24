using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Game.Infrastructure.Entities
{
    public class RoomDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [MaxLength(64)]
        public string Name { get; set; }

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

        public int TypeMarker { get; set; }

        /// <summary>
        /// RGB-цвета маркера на карте.
        /// </summary>
        [NotMapped]
        public int[] ColorMarker
        {
            get { return JsonConvert.DeserializeObject<int[]>(_ColorMarker); }
            set { _ColorMarker = JsonConvert.SerializeObject(value); }
        }

        public int TypeBlip { get; set; }

        public byte ColorBlip { get; set; }

        public int? GangId { get; set; }

        public bool LockDoors { get; set; }

        public int Price { get; set; }

        public DateTimeOffset LastPaymentDate { get; set; }

        [NotMapped]
        public float[] SafePosition
        {
            get { return JsonConvert.DeserializeObject<float[]>(_SafePosition); }
            set { _SafePosition = JsonConvert.SerializeObject(value); }
        }

        public uint SafeDimension { get; set; }

        [Column("EntrancePosition")]
        public string _EntrancePosition { get; set; }

        [Column("ExitPosition")]
        public string _ExitPosition { get; set; }

        [Column("ColorMarker")]
        public string _ColorMarker { get; set; }

        [Column("SafePosition")]
        public string _SafePosition { get; set; }

        /// <summary>
        /// Конструктор для EF.
        /// </summary>
        public RoomDao()
        {
        }

        public RoomDao(
            int id,
            string name,
            float[] entrancePosition,
            uint entranceDimension,
            float[] exitPosition,
            uint exitDimension,
            int typeMarker,
            int[] colorMarker,
            int typeBlip,
            byte colorBlip,
            int? gangId,
            bool lockDoors,
            int price,
            DateTimeOffset lastPaymentDate,
            float[] safePosition,
            uint safeDimension
        )
        {
            Id = id;
            Name = name;
            EntrancePosition = entrancePosition;
            EntranceDimension = entranceDimension;
            ExitPosition = exitPosition;
            ExitDimension = exitDimension;
            TypeMarker = typeMarker;
            ColorMarker = colorMarker;
            TypeBlip = typeBlip;
            ColorBlip = colorBlip;
            GangId = gangId;
            LockDoors = lockDoors;
            Price = price;
            LastPaymentDate = lastPaymentDate;
            SafePosition = safePosition;
            SafeDimension = safeDimension;
        }
    }
}
