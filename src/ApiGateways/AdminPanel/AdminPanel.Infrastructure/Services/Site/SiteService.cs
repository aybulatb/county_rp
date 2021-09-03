using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceSite;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Interfaces;
using System;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site
{
    public partial class SiteService : ISiteService
    {
        private UserClient _userClient;

        public SiteService(
            UserClient userClient
        )
        {
            _userClient = userClient ?? throw new ArgumentNullException(nameof(userClient));
        }
    }
}
