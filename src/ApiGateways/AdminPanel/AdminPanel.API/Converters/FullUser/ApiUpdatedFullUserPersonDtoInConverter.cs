using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models.Persons;
using System;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters.FullUser
{
    internal static class ApiUpdatedFullUserPersonDtoInConverter
    {
        public static GameEditedPersonDtoIn ToService(
            ApiUpdatedFullUserPersonDtoIn source,
            int playerId
        )
        {
            return new GameEditedPersonDtoIn(
                Id: source.Id,
                Name: source.Name,
                PlayerId: playerId,
                LastVisitDate: DateTimeOffset.Now,
                AdminLevelId: source.AdminLevelId,
                FactionId: source.FactionId,
                GangId: source.GangId,
                Leader: source.Leader,
                Rank: source.Rank,
                Position: new[] { 0F },
                CommonInventoryId: 0,
                PocketsInventoryId: 0
            );
        }
    }
}
