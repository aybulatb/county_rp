using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceSite;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Converters
{
    internal static class SiteUserDtoInConverter
    {
        public static ApiUserDtoIn ToExternalApi(
            SiteUserDtoIn source
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
