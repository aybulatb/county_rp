using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CountyRP.DAO
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlayerId { get; set; }
        public DateTime RegDate { get; set; }
        public DateTime LastDate { get; set; }
        public string AdminLevelId { get; set; }
        public string FactionId { get; set; }
        public int GroupId { get; set; }
        public bool Leader { get; set; }
        public int Rank { get; set; }
        [NotMapped]
        public float[] Position
        {
            get { return JsonConvert.DeserializeObject<float[]>(_Position); }
            set { _Position = JsonConvert.SerializeObject(value); }
        }
        public int CommonInventoryId { get; set; }
        public int PocketsInventoryId { get; set; }

        [Column("Position")]
        public string _Position { get; set; }
    }
}
