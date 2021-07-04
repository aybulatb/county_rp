using System.ComponentModel.DataAnnotations;

namespace CountyRP.Services.Game.Infrastructure.Entities
{
    public class AdminLevelDao
    {
        [MaxLength(16)]
        public string Id { get; private set; }

        [MaxLength(64)]
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

        /// <summary>
        /// Конструктор для EF.
        /// </summary>
        public AdminLevelDao()
        {
        }

        public AdminLevelDao(
            string id,
            string name,
            bool ban,
            bool createVehicle,
            bool editVehicle,
            bool deleteVehicle,
            bool createFaction,
            bool editFaction,
            bool deleteFaction,
            bool createHouse,
            bool editHouse,
            bool deleteHouse,
            bool createBusiness,
            bool editBusiness,
            bool deleteBusiness,
            bool createTeleport,
            bool editTeleport,
            bool deleteTeleport,
            bool createGang,
            bool editGang,
            bool deleteGang,
            bool createLockerRoom,
            bool editLockerRoom,
            bool deleteLockerRoom,
            bool createATM,
            bool editATM,
            bool deleteATM,
            bool createRoom,
            bool editRoom,
            bool deleteRoom
        )
        {
            Id = id;
            Name = name;
            Ban = ban;
            CreateVehicle = createVehicle;
            EditVehicle = editVehicle;
            DeleteVehicle = deleteVehicle;
            CreateFaction = createFaction;
            EditFaction = editFaction;
            DeleteFaction = deleteFaction;
            CreateHouse = createHouse;
            EditHouse = editHouse;
            DeleteHouse = deleteHouse;
            CreateBusiness = createBusiness;
            EditBusiness = editBusiness;
            DeleteBusiness = deleteBusiness;
            CreateTeleport = createTeleport;
            EditTeleport = editTeleport;
            DeleteTeleport = deleteTeleport;
            CreateGang = createGang;
            EditGang = editGang;
            DeleteGang = deleteGang;
            CreateLockerRoom = createLockerRoom;
            EditLockerRoom = editLockerRoom;
            DeleteLockerRoom = deleteLockerRoom;
            CreateATM = createATM;
            EditATM = editATM;
            DeleteATM = deleteATM;
            CreateRoom = createRoom;
            EditRoom = editRoom;
            DeleteRoom = deleteRoom;
        }
    }
}
