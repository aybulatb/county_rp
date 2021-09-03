using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceGame;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models;
using System.Linq;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Converters
{
    internal static class GameApiPersonDtoOutConverter
    {
        public static GamePersonDtoOut ToService(
            ApiPersonDtoOut source
        )
        {
            return new GamePersonDtoOut(
                id: source.Id,
                name: source.Name,
                playerId: source.PlayerId,
                registrationDate: source.RegistrationDate,
                lastVisitDate: source.LastVisitDate,
                adminLevelId: source.AdminLevelId,
                factionId: source.FactionId,
                gangId: source.GangId,
                leader: source.Leader,
                rank: source.Rank,
                position: source.Position.ToArray(),
                commonInventoryId: source.CommonInventoryId,
                pocketsInventoryId: source.PocketsInventoryId
            );
        }
    }
}
