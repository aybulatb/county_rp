using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceSite;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Converters
{
    internal static class SiteUserDtoOutConverter
    {
        public static ApiUserDtoOut ToExternalApi(
            SiteUserDtoOut source
        )
        {
            return new ApiUserDtoOut
            {
                Id = source.Id,
                Login = source.Login,
                Password = source.Password,
                PlayerId = source.PlayerId,
                ForumUserId = source.ForumUserId,
                GroupId = source.GroupId
            };
        }

        public static ApiUserDtoIn ToDtoInExternalApi(
            SiteUserDtoOut source
        )
        {
            return new ApiUserDtoIn
            {
                Login = source.Login,
                Password = source.Password,
                PlayerId = source.PlayerId,
                ForumUserId = source.ForumUserId,
                GroupId = source.GroupId
            };
        }
    }
}
