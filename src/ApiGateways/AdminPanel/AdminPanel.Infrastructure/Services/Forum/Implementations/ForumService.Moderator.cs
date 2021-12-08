using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Converters;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Implementations
{
    public partial class ForumService
    {
        public async Task CreateModeratorsAsync(IEnumerable<ForumModeratorDtoIn> moderatorsDtoIn)
        {
            var externalApiModeratorsDtoIn = moderatorsDtoIn
                .Select(ForumModeratorDtoInConverter.ToExternalApi);

            await _moderatorClient.MassivelyCreateAsync(externalApiModeratorsDtoIn);
        }

        public async Task<ForumPagedFilterResultDtoOut<ForumModeratorDtoOut>> GetModeratorsByFilterAsync(ForumModeratorFilterDtoIn filter)
        {
            var externalApiModeratorsDtoOut = await _moderatorClient.FilterByAsync(
                ids: filter.Ids,
                entityId: filter.EntityId,
                entityType: filter.EntityType.HasValue ? (int)filter.EntityType.Value : null,
                forumId: filter.ForumId,
                count: filter.Count,
                page: filter.Page
            );

            return PagedFilterResultConverter.ToService(externalApiModeratorsDtoOut);
        }

        public async Task UpdateModeratorsAsync(IEnumerable<ForumModeratorDtoOut> moderatorsDtoOut)
        {
            var externalApiModeratorsDtoOut = moderatorsDtoOut
                .Select(ForumModeratorDtoOutConverter.ToExternalApi);

            await _moderatorClient.MassivelyEditAsync(externalApiModeratorsDtoOut);
        }

        public async Task DeleteModeratorsByFilterAsync(ForumModeratorFilterDtoIn filter)
        {
            var externalApiFilter = ForumModeratorFilterDtoInConverter.ToExternalApi(filter);

            await _moderatorClient.DeleteByFilterAsync(externalApiFilter);
        }
    }
}
