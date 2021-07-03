using CountyRP.Services.Site.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Site.Repositories
{
    public partial interface ISiteRepository
    {
        Task<SupportRequestMessageDtoOut> AddSupportRequestMessageAsync(SupportRequestMessageDtoIn supportRequestMessageDtoIn);

        Task<PagedFilterResult<SupportRequestMessageDtoOut>> GetSupportRequestMessagesByFilterAsync(SupportRequestMessageFilterDtoIn filter);

        Task<SupportRequestMessageDtoOut> UpdateSupportRequestMessageAsync(SupportRequestMessageDtoOut supportRequestMessageDtoOut);

        Task DeleteSupportRequestMessagesAsync(SupportRequestMessageFilterDtoIn filter);
    }
}
