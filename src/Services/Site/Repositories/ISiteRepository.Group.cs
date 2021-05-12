using CountyRP.Services.Site.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Site.Repositories
{
    public partial interface ISiteRepository
    {
        Task<GroupDtoOut> AddGroupAsync(GroupDtoIn groupDtoIn);

        Task<GroupDtoOut> GetGroupAsync(string id);

        Task<PagedFilterResult<GroupDtoOut>> GetGroupsByFilterAsync(GroupFilterDtoIn filter);

        Task<GroupDtoOut> UpdateGroupAsync(GroupDtoOut groupDtoOut);

        Task DeleteGroupAsync(string id);
    }
}
