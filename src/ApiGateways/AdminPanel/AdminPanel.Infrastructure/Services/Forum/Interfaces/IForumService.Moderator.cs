using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Interfaces
{
    public partial interface IForumService
    {
        Task CreateModeratorsAsync(IEnumerable<ForumModeratorDtoIn> moderatorsDtoIn);

        Task<ForumPagedFilterResultDtoOut<ForumModeratorDtoOut>> GetModeratorsByFilterAsync(ForumModeratorFilterDtoIn filter);

        Task UpdateModeratorsAsync(IEnumerable<ForumModeratorDtoOut> moderatorsDtoOut);

        Task DeleteModeratorsByFilterAsync(ForumModeratorFilterDtoIn filter);
    }
}
