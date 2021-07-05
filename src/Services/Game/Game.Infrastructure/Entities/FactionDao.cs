using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Game.Infrastructure.Entities
{
    public class FactionDao
    {
        [Key]
        [MaxLength(16)]
        public string Id { get; private set; }

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

        public FactionTypeDao Type { get; set; }

        [Column("Ranks")]
        public string _Ranks { get; set; }

        /// <summary>
        /// Конструктор для EF.
        /// </summary>
        public FactionDao()
        {
        }

        public FactionDao(
            string id,
            string name,
            string color,
            string[] ranks,
            FactionTypeDao type
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
