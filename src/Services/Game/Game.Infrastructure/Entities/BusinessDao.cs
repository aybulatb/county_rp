using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Game.Infrastructure.Entities
{
    public class BusinessDao
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

        public int OwnerId { get; set; }

        public bool Lock { get; set; }

        public BusinessTypeDao Type { get; set; }

        public int Price { get; set; }

        [Column("EntrancePosition")]
        public string _EntrancePosition { get; set; }

        [Column("ExitPosition")]
        public string _ExitPosition { get; set; }

        /// <summary>
        /// Конструктор для EF.
        /// </summary>
        public BusinessDao()
        {
        }

        public BusinessDao(
            int id,
            string name,
            float[] entrancePosition,
            uint entranceDimension,
            float[] exitPosition,
            uint exitDimension,
            int ownerId,
            bool lockState,
            BusinessTypeDao type,
            int price
        )
        {
            Id = id;
            Name = name;
            EntrancePosition = entrancePosition;
            EntranceDimension = entranceDimension;
            ExitPosition = exitPosition;
            ExitDimension = exitDimension;
            OwnerId = ownerId;
            Lock = lockState;
            Type = type;
            Price = price;
        }
    }
}
