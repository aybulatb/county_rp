using System;

namespace CountyRP.Models
{
    public class SiteBan
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int AdminId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime FinishDateTime { get; set; }
        public string IP { get; set; }
        public string Reason { get; set; }
    }
}
