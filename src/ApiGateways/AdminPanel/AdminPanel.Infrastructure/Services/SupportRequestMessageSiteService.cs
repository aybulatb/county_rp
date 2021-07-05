using CountyRP.ApiGateways.AdminPanel.Infrastructure.Models;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClient.ServiceSite;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Interfaces;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services
{
    public class SupportRequestMessageSiteService : ISupportRequestMessageSiteService
    {
        private SupportRequestMessageClient _supportRequestMessageClient;

        public SupportRequestMessageSiteService(
            SupportRequestMessageClient supportRequestMessageClient
        )
        {
            _supportRequestMessageClient = supportRequestMessageClient;
        }

        public async Task<SupportRequestMessageDtoOut> Create(SupportRequestMessageDtoIn supportRequestMessageDtoIn)
        {
            await _supportRequestMessageClient.CreateAsync(new ApiSupportRequestMessageDtoIn
            {
                UserId = 1
            });

            return new SupportRequestMessageDtoOut();
        }
    }
}
