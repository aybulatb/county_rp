using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Game.Infrastructure.Entities
{
    public class GangDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [MaxLength(64)]
        public string Name { get; set; }

        /// <summary>
        /// Цвет формата RRGGBB.
        /// </summary>
        [MaxLength(6)]
        public string Color { get; set; }

        [NotMapped]
        public string[] Ranks
        {
            get { return JsonConvert.DeserializeObject<string[]>(_Ranks); }
            set { _Ranks = JsonConvert.SerializeObject(value); }
        }

        public GangTypeDao Type { get; set; }

        [Column("Ranks")]
        public string _Ranks { get; set; }

        public GangDao()
        {
        }

        public GangDao(
            int id,
            string name,
            string color,
            string[] ranks,
            GangTypeDao type
        )
        {
            Id = id;
            Name = name;
            Color = color;
            Ranks = ranks;
            Type = type;
        }
    }
}
