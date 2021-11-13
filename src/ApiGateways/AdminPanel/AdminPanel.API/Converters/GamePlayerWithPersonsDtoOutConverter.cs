using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models;
using System;
using System.Linq;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters
{
    internal static class GamePlayerWithPersonsDtoOutConverter
    {
        public static ApiFullUserDtoOut ToApiFullUserDtoOutApi(
            GamePlayerWithPersonsDtoOut source,
            SiteUserDtoOut user
        )
        {
            return new ApiFullUserDtoOut(
                id: user.Id,
                login: user.Login,
                registrationDate: DateTimeOffset.Now,
                lastVisitDate: DateTimeOffset.Now,
                groupId: user.GroupId,
                persons: source.Persons
                    .Select(GamePersonDtoOutConverter.ToApiFullUserPersonDtoOutApi)
            );
        }
    }
}
