using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CountyRP.Entities
{
    public class Faction
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public string[] Ranks
        {
            get { return JsonConvert.DeserializeObject<string[]>(_Ranks); }
            set { _Ranks = JsonConvert.SerializeObject(value); }
        }
        public FactionType Type { get; set; }

        [Column("Ranks")]
        public string _Ranks { get; set; }
    }

    public enum FactionType
    {
        None = 0
    }
}
