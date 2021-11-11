namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiAdminLevelDtoOut
    {
        public string Id { get; init; }

        public string Name { get; init; }

        /// <summary>
        /// Возможность банить.
        /// </summary>
        public bool Ban { get; init; }

        /// <summary>
        /// Возможность создавать транспортные средства.
        /// </summary>
        public bool CreateVehicle { get; init; }

        /// <summary>
        /// Возможность редактировать транспортные средства.
        /// </summary>
        public bool EditVehicle { get; init; }

        /// <summary>
        /// Возможность удалять транспортные средства.
        /// </summary>
        public bool DeleteVehicle { get; init; }

        /// <summary>
        /// Возможность создавать фракции.
        /// </summary>
        public bool CreateFaction { get; init; }

        /// <summary>
        /// Возможность редактировать фракции.
        /// </summary>
        public bool EditFaction { get; init; }

        /// <summary>
        /// Возможность удалять фракции.
        /// </summary>
        public bool DeleteFaction { get; init; }

        /// <summary>
        /// Возможность создавать дома.
        /// </summary>
        public bool CreateHouse { get; init; }

        /// <summary>
        /// Возможность редактировать дома.
        /// </summary>
        public bool EditHouse { get; init; }

        /// <summary>
        /// Возможность удалять дома.
        /// </summary>
        public bool DeleteHouse { get; init; }

        /// <summary>
        /// Возможность создавать бизнесы.
        /// </summary>
        public bool CreateBusiness { get; init; }

        /// <summary>
        /// Возможность редактировать бизнесы.
        /// </summary>
        public bool EditBusiness { get; init; }

        /// <summary>
        /// Возможность удалять бизнесы.
        /// </summary>
        public bool DeleteBusiness { get; init; }

        /// <summary>
        /// Возможность создавать телепорты.
        /// </summary>
        public bool CreateTeleport { get; init; }

        /// <summary>
        /// Возможность редактировать телепорты.
        /// </summary>
        public bool EditTeleport { get; init; }

        /// <summary>
        /// Возможность удалять телепорты.
        /// </summary>
        public bool DeleteTeleport { get; init; }

        /// <summary>
        /// Возможность создавать банды.
        /// </summary>
        public bool CreateGang { get; init; }

        /// <summary>
        /// Возможность редактировать банды.
        /// </summary>
        public bool EditGang { get; init; }

        /// <summary>
        /// Возможность удалять банды.
        /// </summary>
        public bool DeleteGang { get; init; }

        /// <summary>
        /// Возможность создавать раздевалки.
        /// </summary>
        public bool CreateLockerRoom { get; init; }

        /// <summary>
        /// Возможность редактировать раздевалки.
        /// </summary>
        public bool EditLockerRoom { get; init; }

        /// <summary>
        /// Возможность удалять раздевалки.
        /// </summary>
        public bool DeleteLockerRoom { get; init; }

        /// <summary>
        /// Возможность создавать банкоматы.
        /// </summary>
        public bool CreateAtm { get; init; }

        /// <summary>
        /// Возможность редактировать банкоматы.
        /// </summary>
        public bool EditAtm { get; init; }

        /// <summary>
        /// Возможность удалять банкоматы.
        /// </summary>
        public bool DeleteAtm { get; init; }

        /// <summary>
        /// Возможность создавать помещения.
        /// </summary>
        public bool CreateRoom { get; init; }

        /// <summary>
        /// Возможность редактировать помещения.
        /// </summary>
        public bool EditRoom { get; init; }

        /// <summary>
        /// Возможность удалять помещения.
        /// </summary>
        public bool DeleteRoom { get; init; }

        public ApiAdminLevelDtoOut(
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
            bool createAtm,
            bool editAtm,
            bool deleteAtm,
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
            CreateAtm = createAtm;
            EditAtm = editAtm;
            DeleteAtm = deleteAtm;
            CreateRoom = createRoom;
            EditRoom = editRoom;
            DeleteRoom = deleteRoom;
        }
    }
}
