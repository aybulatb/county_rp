namespace CountyRP.Models
{
    public class Faction
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string[] Ranks { get; set; }
        public FactionType Type { get; set; }
    }

    public enum FactionType
    {
        None = 0
    }
}
