using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class AdminLevelDtoOutConverter
    {
        public static AdminLevelDao ToDb(
            AdminLevelDtoOut source
        )
        {
            return new AdminLevelDao(
                id: source.Id,
                name: source.Name,
                ban: source.Ban,
                createVehicle: source.CreateVehicle,
                editVehicle: source.EditVehicle,
                deleteVehicle: source.DeleteVehicle,
                createFaction: source.CreateFaction,
                editFaction: source.EditFaction,
                deleteFaction: source.DeleteFaction,
                createHouse: source.CreateHouse,
                editHouse: source.EditHouse,
                deleteHouse: source.DeleteHouse,
                createBusiness: source.CreateBusiness,
                editBusiness: source.EditBusiness,
                deleteBusiness: source.DeleteBusiness,
                createTeleport: source.CreateTeleport,
                editTeleport: source.EditTeleport,
                deleteTeleport: source.DeleteTeleport,
                createGang: source.CreateGang,
                editGang: source.EditGang,
                deleteGang: source.DeleteGang,
                createLockerRoom: source.CreateLockerRoom,
                editLockerRoom: source.EditLockerRoom,
                deleteLockerRoom: source.DeleteLockerRoom,
                createAtm: source.CreateAtm,
                editAtm: source.EditAtm,
                deleteAtm: source.DeleteAtm,
                createRoom: source.CreateRoom,
                editRoom: source.EditRoom,
                deleteRoom: source.DeleteRoom
            );
        }
    }
}
