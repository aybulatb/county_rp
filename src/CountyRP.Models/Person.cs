using System;

namespace CountyRP.Models
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
        public float[] Position { get; set; }
    }
}
