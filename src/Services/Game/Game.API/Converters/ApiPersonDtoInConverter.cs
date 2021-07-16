using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public static class ApiPersonDtoInConverter
    {
        public static PersonDtoIn ToRepository(
            ApiPersonDtoIn source
        )
        {
            return new PersonDtoIn(
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
