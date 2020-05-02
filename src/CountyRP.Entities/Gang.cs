using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CountyRP.Entities
{
    public class Gang
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        [NotMapped]
        public string[] Ranks
        {
            get { return JsonConvert.DeserializeObject<string[]>(_Ranks); }
            set { _Ranks = JsonConvert.SerializeObject(value); }
        }
        public Models.GangType Type { get; set; }

        [Column("Ranks")]
        public string _Ranks { get; set; }
    }
}
