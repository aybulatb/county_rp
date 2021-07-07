using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Game.Infrastructure.Entities
{
    public class GarageDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public int Type { get; set; }

        [NotMapped]
        public float[] EntrancePosition
        {
            get => JsonConvert.DeserializeObject<float[]>(_EntrancePosition);
            set => _EntrancePosition = JsonConvert.SerializeObject(value);
        }

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

        [Column("EntrancePosition")]
        public string _EntrancePosition { get; set; }

        /// <summary>
        /// Конструктор для EF.
        /// </summary>
        public GarageDao()
        {
        }

        public GarageDao(
            int id,
            int type,
            float[] entrancePosition,
            uint entranceDimension,
            float entranceRotation,
            uint exitDimension,
            bool lockDoors
        )
        {
            Id = id;
            Type = type;
            EntrancePosition = entrancePosition;
            EntranceDimension = entranceDimension;
            EntranceRotation = entranceRotation;
            ExitDimension = exitDimension;
            LockDoors = lockDoors;
        }
    }
}
