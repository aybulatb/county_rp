namespace CountyRP.Models
{
    public class AdminLevel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Ban { get; set; }
        public bool CreateVehicle { get; set; }
        public bool EditVehicle { get; set; }
        public bool DeleteVehicle { get; set; }
        public bool CreateFaction { get; set; }
        public bool EditFaction { get; set; }
        public bool DeleteFaction { get; set; }
        public bool CreateHouse { get; set; }
        public bool EditHouse { get; set; }
        public bool DeleteHouse { get; set; }
        public bool CreateBusiness { get; set; }
        public bool EditBusiness { get; set; }
        public bool DeleteBusiness { get; set; }
        public bool CreateTeleport { get; set; }
        public bool EditTeleport { get; set; }
        public bool DeleteTeleport { get; set; }
        public bool CreateGang { get; set; }
        public bool EditGang { get; set; }
        public bool DeleteGang { get; set; }
        public bool CreateLockerRoom { get; set; }
        public bool EditLockerRoom { get; set; }
        public bool DeleteLockerRoom { get; set; }
        public bool CreateATM { get; set; }
        public bool EditATM { get; set; }
        public bool DeleteATM { get; set; }
        public bool CreateRoom { get; set; }
        public bool EditRoom { get; set; }
        public bool DeleteRoom { get; set; }
    }
}
