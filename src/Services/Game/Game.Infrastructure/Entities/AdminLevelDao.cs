using System.ComponentModel.DataAnnotations;

namespace CountyRP.Services.Game.Infrastructure.Entities
{
    public class AdminLevelDao
    {
        [Key]
        [MaxLength(16)]
        public string Id { get; private set; }

        [MaxLength(64)]
        public string Name { get; set; }

        /// <summary>
        /// Возможность банить.
        /// </summary>
        public bool Ban { get; set; }

        /// <summary>
        /// Возможность создавать транспортные средства.
        /// </summary>
        public bool CreateVehicle { get; set; }

        /// <summary>
        /// Возможность редактировать транспортные средства.
        /// </summary>
        public bool EditVehicle { get; set; }

        /// <summary>
        /// Возможность удалять транспортные средства.
        /// </summary>
        public bool DeleteVehicle { get; set; }

        /// <summary>
        /// Возможность создавать фракции.
        /// </summary>
        public bool CreateFaction { get; set; }

        /// <summary>
        /// Возможность редактировать фракции.
        /// </summary>
        public bool EditFaction { get; set; }

        /// <summary>
        /// Возможность удалять фракции.
        /// </summary>
        public bool DeleteFaction { get; set; }

        /// <summary>
        /// Возможность создавать дома.
        /// </summary>
        public bool CreateHouse { get; set; }

        /// <summary>
        /// Возможность редактировать дома.
        /// </summary>
        public bool EditHouse { get; set; }

        /// <summary>
        /// Возможность удалять дома.
        /// </summary>
        public bool DeleteHouse { get; set; }

        /// <summary>
        /// Возможность создавать бизнесы.
        /// </summary>
        public bool CreateBusiness { get; set; }

        /// <summary>
        /// Возможность редактировать бизнесы.
        /// </summary>
        public bool EditBusiness { get; set; }

        /// <summary>
        /// Возможность удалять бизнесы.
        /// </summary>
        public bool DeleteBusiness { get; set; }

        /// <summary>
        /// Возможность создавать телепорты.
        /// </summary>
        public bool CreateTeleport { get; set; }

        /// <summary>
        /// Возможность редактировать телепорты.
        /// </summary>
        public bool EditTeleport { get; set; }

        /// <summary>
        /// Возможность удалять телепорты.
        /// </summary>
        public bool DeleteTeleport { get; set; }

        /// <summary>
        /// Возможность создавать банды.
        /// </summary>
        public bool CreateGang { get; set; }

        /// <summary>
        /// Возможность редактировать банды.
        /// </summary>
        public bool EditGang { get; set; }

        /// <summary>
        /// Возможность удалять банды.
        /// </summary>
        public bool DeleteGang { get; set; }

        /// <summary>
        /// Возможность создавать раздевалки.
        /// </summary>
        public bool CreateLockerRoom { get; set; }

        /// <summary>
        /// Возможность редактировать раздевалки.
        /// </summary>
        public bool EditLockerRoom { get; set; }

        /// <summary>
        /// Возможность удалять раздевалки.
        /// </summary>
        public bool DeleteLockerRoom { get; set; }

        /// <summary>
        /// Возможность создавать банкоматы.
        /// </summary>
        public bool CreateATM { get; set; }

        /// <summary>
        /// Возможность редактировать банкоматы.
        /// </summary>
        public bool EditATM { get; set; }

        /// <summary>
        /// Возможность удалять банкоматы.
        /// </summary>
        public bool DeleteATM { get; set; }

        /// <summary>
        /// Возможность создавать помещения.
        /// </summary>
        public bool CreateRoom { get; set; }

        /// <summary>
        /// Возможность редактировать помещения.
        /// </summary>
        public bool EditRoom { get; set; }

        /// <summary>
        /// Возможность удалять помещения.
        /// </summary>
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
