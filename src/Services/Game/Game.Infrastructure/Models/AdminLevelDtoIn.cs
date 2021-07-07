namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class AdminLevelDtoIn
    {
        public string Id { get; }

        public string Name { get; }

        /// <summary>
        /// Возможность банить.
        /// </summary>
        public bool Ban { get; }

        /// <summary>
        /// Возможность создавать транспортные средства.
        /// </summary>
        public bool CreateVehicle { get; }

        /// <summary>
        /// Возможность редактировать транспортные средства.
        /// </summary>
        public bool EditVehicle { get; }

        /// <summary>
        /// Возможность удалять транспортные средства.
        /// </summary>
        public bool DeleteVehicle { get; }

        /// <summary>
        /// Возможность создавать фракции.
        /// </summary>
        public bool CreateFaction { get; }

        /// <summary>
        /// Возможность редактировать фракции.
        /// </summary>
        public bool EditFaction { get; }

        /// <summary>
        /// Возможность удалять фракции.
        /// </summary>
        public bool DeleteFaction { get; }

        /// <summary>
        /// Возможность создавать дома.
        /// </summary>
        public bool CreateHouse { get; }

        /// <summary>
        /// Возможность редактировать дома.
        /// </summary>
        public bool EditHouse { get; }

        /// <summary>
        /// Возможность удалять дома.
        /// </summary>
        public bool DeleteHouse { get; }

        /// <summary>
        /// Возможность создавать бизнесы.
        /// </summary>
        public bool CreateBusiness { get; }

        /// <summary>
        /// Возможность редактировать бизнесы.
        /// </summary>
        public bool EditBusiness { get; }

        /// <summary>
        /// Возможность удалять бизнесы.
        /// </summary>
        public bool DeleteBusiness { get; }

        /// <summary>
        /// Возможность создавать телепорты.
        /// </summary>
        public bool CreateTeleport { get; }

        /// <summary>
        /// Возможность редактировать телепорты.
        /// </summary>
        public bool EditTeleport { get; }

        /// <summary>
        /// Возможность удалять телепорты.
        /// </summary>
        public bool DeleteTeleport { get; }

        /// <summary>
        /// Возможность создавать банды.
        /// </summary>
        public bool CreateGang { get; }

        /// <summary>
        /// Возможность редактировать банды.
        /// </summary>
        public bool EditGang { get; }

        /// <summary>
        /// Возможность удалять банды.
        /// </summary>
        public bool DeleteGang { get; }

        /// <summary>
        /// Возможность создавать раздевалки.
        /// </summary>
        public bool CreateLockerRoom { get; }

        /// <summary>
        /// Возможность редактировать раздевалки.
        /// </summary>
        public bool EditLockerRoom { get; }

        /// <summary>
        /// Возможность удалять раздевалки.
        /// </summary>
        public bool DeleteLockerRoom { get; }

        /// <summary>
        /// Возможность создавать банкоматы.
        /// </summary>
        public bool CreateATM { get; }

        /// <summary>
        /// Возможность редактировать банкоматы.
        /// </summary>
        public bool EditATM { get; }

        /// <summary>
        /// Возможность удалять банкоматы.
        /// </summary>
        public bool DeleteATM { get; }

        /// <summary>
        /// Возможность создавать помещения.
        /// </summary>
        public bool CreateRoom { get; }

        /// <summary>
        /// Возможность редактировать помещения.
        /// </summary>
        public bool EditRoom { get; }

        /// <summary>
        /// Возможность удалять помещения.
        /// </summary>
        public bool DeleteRoom { get; }

        public AdminLevelDtoIn(
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
