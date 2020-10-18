using System;

namespace CountyRP.DAO
{
    public class GameBan
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int PersonId { get; set; }
        public int AdminId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime FinishDateTime { get; set; }
        public string IP { get; set; }
        public string Reason { get; set; }
    }
}
