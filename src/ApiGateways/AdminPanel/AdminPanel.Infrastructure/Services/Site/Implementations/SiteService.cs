using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceSite;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Interfaces;
using System;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Implementations
{
    public partial class SiteService : ISiteService
    {
        private readonly UserClient _userClient;
        private readonly GroupClient _groupClient;

        public SiteService(
            UserClient userClient,
            GroupClient groupClient
        )
        {
            _userClient = userClient ?? throw new ArgumentNullException(nameof(userClient));
            _groupClient = groupClient ?? throw new ArgumentNullException(nameof(groupClient));
        }
    }
}
