using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Game.Infrastructure.Entities
{
    public class LockerRoomDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [NotMapped]
        public float[] Position
        {
            get { return JsonConvert.DeserializeObject<float[]>(_Position); }
            set { _Position = JsonConvert.SerializeObject(value); }
        }

        public uint Dimension { get; set; }

        public int TypeMarker { get; set; }

        [NotMapped]
        public int[] ColorMarker
        {
            get { return JsonConvert.DeserializeObject<int[]>(_ColorMarker); }
            set { _ColorMarker = JsonConvert.SerializeObject(value); }
        }

        public string FactionId { get; set; }

        [Column("Position")]
        public string _Position { get; set; }

        [Column("ColorMarker")]
        public string _ColorMarker { get; set; }

        /// <summary>
        /// Конструктор для EF.
        /// </summary>
        public LockerRoomDao()
        {
        }

        public LockerRoomDao(
            int id,
            float[] position,
            uint dimension,
            int typeMarker,
            int[] colorMarker,
            string factionId
        )
        {
            Id = id;
            Position = position;
            Dimension = dimension;
            TypeMarker = typeMarker;
            ColorMarker = colorMarker;
            FactionId = factionId;
        }
    }
}
