namespace CountyRP.Models
{
    public enum GangType
    {
        None = 0
    }

    public class Gang
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string[] Ranks { get; set; }
        public GangType Type { get; set; }
    }
}
