using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceSite;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Converters
{
    internal static class ApiUserDtoOutConverter
    {
        public static SiteUserDtoOut ToService(
            ApiUserDtoOut source
        )
        {
            return new SiteUserDtoOut(
                Id: source.Id,
                Login: source.Login,
                Password: source.Password,
                PlayerId: source.PlayerId,
                ForumUserId: source.ForumUserId,
                GroupId: source.GroupId
            );
        }
    }
}
