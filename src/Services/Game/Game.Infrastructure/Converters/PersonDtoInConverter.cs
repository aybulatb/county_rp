using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.Infrastructure.Converters
{
    public static class PersonDtoInConverter
    {
        public static PersonDao ToDb(
            PersonDtoIn source
        )
        {
            return new PersonDao(
                id: 0,
                name: source.Name,
                playerId: source.PlayerId,
                registrationDate: source.RegistrationDate,
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
