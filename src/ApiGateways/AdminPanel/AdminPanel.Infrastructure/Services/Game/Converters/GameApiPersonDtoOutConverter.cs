using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceGame;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models;
using System.Linq;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Converters
{
    internal static class GameApiPersonDtoOutConverter
    {
        public static GamePersonDtoOut ToService(
            ApiPersonDtoOut source
        )
        {
            return new GamePersonDtoOut(
                Id: source.Id,
                Name: source.Name,
                PlayerId: source.PlayerId,
                RegistrationDate: source.RegistrationDate,
                LastVisitDate: source.LastVisitDate,
                AdminLevelId: source.AdminLevelId,
                FactionId: source.FactionId,
                GangId: source.GangId,
                Leader: source.Leader,
                Rank: source.Rank,
                Position: source.Position.ToArray(),
                CommonInventoryId: source.CommonInventoryId,
                PocketsInventoryId: source.PocketsInventoryId
            );
        }
    }
}
