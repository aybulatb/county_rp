using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Models;

namespace CountyRP.Services.Game.API.Converters
{
    public class ApiEditedPersonDtoInConverter
    {
        public static EditedPersonDtoIn ToRepository(
            ApiEditedPersonDtoIn source,
            int id
        )
        {
            return new EditedPersonDtoIn(
                id: id,
                name: source.Name,
                playerId: source.PlayerId,
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
