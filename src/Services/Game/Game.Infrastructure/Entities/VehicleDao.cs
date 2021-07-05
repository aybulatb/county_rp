using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Game.Infrastructure.Entities
{
    public class VehicleDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public int Model { get; set; }

        [NotMapped]
        public float[] Position
        {
            get { return JsonConvert.DeserializeObject<float[]>(_Position); }
            set { _Position = JsonConvert.SerializeObject(value); }
        }

        public float Rotation { get; set; }

        public uint Dimension { get; set; }

        public int Color1 { get; set; }

        public int Color2 { get; set; }

        public double Fuel { get; set; }

        public int OwnerId { get; set; }

        public string FactionId { get; set; }

        public bool Lock { get; set; }

        public string LicensePlate { get; set; }

        [Column("Position")]
        public string _Position { get; set; }

        /// <summary>
        /// Конструктор для EF.
        /// </summary>
        public VehicleDao()
        {
        }

        public VehicleDao(
            int id,
            int model,
            float rotation,
            uint dimension,
            int color1,
            int color2,
            double fuel,
            int ownerId,
            string factionId,
            bool lockState,
            string licensePlate
        )
        {
            Id = id;
            Model = model;
            Rotation = rotation;
            Dimension = dimension;
            Color1 = color1;
            Color2 = color2;
            Fuel = fuel;
            OwnerId = ownerId;
            FactionId = factionId;
            Lock = lockState;
            LicensePlate = licensePlate;
        }
    }
}
