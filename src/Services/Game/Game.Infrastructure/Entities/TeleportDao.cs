using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Game.Infrastructure.Entities
{
    public class TeleportDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

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

        [NotMapped]
        public int[] ColorMarker
        {
            get { return JsonConvert.DeserializeObject<int[]>(_ColorMarker); }
            set { _ColorMarker = JsonConvert.SerializeObject(value); }
        }

        public int TypeBlip { get; set; }

        public byte ColorBlip { get; set; }

        public string FactionId { get; set; }

        public int GangId { get; set; }

        public int RoomId { get; set; }

        public int BusinessId { get; set; }

        public bool Lock { get; set; }

        [Column("EntrancePosition")]
        public string _EntrancePosition { get; set; }

        [Column("ExitPosition")]
        public string _ExitPosition { get; set; }

        [Column("ColorMarker")]
        public string _ColorMarker { get; set; }

        /// <summary>
        /// Конструктор для EF.
        /// </summary>
        public TeleportDao()
        {
        }

        public TeleportDao(
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
            string factionId,
            int gangId,
            int roomId,
            int businessId,
            bool lockState
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
            FactionId = factionId;
            GangId = gangId;
            RoomId = roomId;
            BusinessId = businessId;
            Lock = lockState;
        }
    }
}
