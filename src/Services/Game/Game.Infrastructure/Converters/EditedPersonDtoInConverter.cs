using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class EditedPersonDtoInConverter
    {
        public static PersonDao ToDb(
            EditedPersonDtoIn source,
            PersonDtoOut personDtoOut
        )
        {
            return new PersonDao(
                id: source.Id,
                name: source.Name,
                playerId: source.PlayerId,
                registrationDate: personDtoOut.RegistrationDate,
                lastVisitDate: source.LastVisitDate,
                adminLevelId: source.AdminLevelId,
                factionId: source.FactionId,
                gangId: source.GangId,
                leader: source.Leader,
                rank: source.Rank,
                position: source.Position,
                commonInventoryId: source.CommonInventoryId,
                pocketsInventoryId: source.PocketsInventoryId
            );
        }
    }
}
