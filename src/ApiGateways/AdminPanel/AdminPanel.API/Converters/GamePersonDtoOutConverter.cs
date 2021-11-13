using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters
{
    internal static class GamePersonDtoOutConverter
    {
        public static ApiFullUserPersonDtoOut ToApiFullUserPersonDtoOutApi(
            GamePersonDtoOut source
        )
        {
            return new ApiFullUserPersonDtoOut(
                id: source.Id,
                name: source.Name,
                registrationDate: source.RegistrationDate,
                lastVisitDate: source.LastVisitDate,
                adminLevelId: source.AdminLevelId,
                factionId: source.FactionId,
                gangId: source.GangId,
                leader: source.Leader,
                rank: source.Rank
            );
        }
    }
}
