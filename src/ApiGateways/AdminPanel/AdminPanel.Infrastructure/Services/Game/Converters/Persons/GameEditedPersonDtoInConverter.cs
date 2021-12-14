using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceGame;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models.Persons;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Converters.Persons
{
    internal static class GameEditedPersonDtoInConverter
    {
        public static ApiEditedPersonDtoIn ToExternalApi(
            GameEditedPersonDtoIn source
        )
        {
            return new ApiEditedPersonDtoIn
            {
                Id = source.Id,
                Name = source.Name,
                PlayerId = source.PlayerId,
                LastVisitDate = source.LastVisitDate,
                AdminLevelId = source.AdminLevelId,
                FactionId = source.FactionId,
                GangId = source.GangId,
                Leader = source.Leader,
                Rank = source.Rank,
                Position = source.Position,
                CommonInventoryId = source.CommonInventoryId,
                PocketsInventoryId = source.PocketsInventoryId
            };
        }
    }
}
