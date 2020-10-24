using System;

namespace CountyRP.Models
{
    public class LogUnit
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Login { get; set; }
        public string IP { get; set; }
        public LogAction ActionId { get; set; }
        public string Comment { get; set; }
    }

    public enum LogAction
    {
        BanInGame = 0,
        BanOnSite = 1
    }
}
