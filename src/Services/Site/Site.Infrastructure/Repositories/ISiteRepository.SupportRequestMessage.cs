using CountyRP.Services.Site.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Site.Infrastructure.Repositories
{
    public partial interface ISiteRepository
    {
        Task<SupportRequestMessageDtoOut> AddSupportRequestMessageAsync(SupportRequestMessageDtoIn supportRequestMessageDtoIn);

        Task<PagedFilterResult<SupportRequestMessageDtoOut>> GetSupportRequestMessagesByFilterAsync(SupportRequestMessageFilterDtoIn filter);

        Task<SupportRequestMessageDtoOut> UpdateSupportRequestMessageAsync(SupportRequestMessageDtoOut supportRequestMessageDtoOut);

        Task DeleteSupportRequestMessagesAsync(SupportRequestMessageFilterDtoIn filter);
    }
}
