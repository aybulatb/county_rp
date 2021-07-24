using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Game.Infrastructure.Entities
{
    public class AtmDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [NotMapped]
        public float[] Position
        {
            get => JsonConvert.DeserializeObject<float[]>(_Position);
            set => _Position = JsonConvert.SerializeObject(value);
        }

        public uint Dimension { get; set; }

        public int? BusinessId { get; set; }

        [Column("Position")]
        public string _Position { get; set; }

        /// <summary>
        /// Конструктор для EF.
        /// </summary>
        public AtmDao()
        {
        }

        public AtmDao(
            int id,
            float[] position,
            uint dimension,
            int? businessId
        )
        {
            Id = id;
            Position = position;
            Dimension = dimension;
            BusinessId = businessId;
        }
    }
}
