using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClients.ServiceForum;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;
using System.Linq;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Converters
{
    internal static class PagedFilterResultConverter
    {
        public static ForumPagedFilterResultDtoOut<ForumModeratorDtoOut> ToService(
            PagedFilterResultOfApiModeratorDtoOut source
        )
        {
            return new ForumPagedFilterResultDtoOut<ForumModeratorDtoOut>(
                AllCount: source.AllCount,
                Page: source.Page,
                MaxPages: source.MaxPages,
                Items: source.Items
                    .Select(ApiModeratorDtoOutConverter.ToService)
            );
        }
    }
}
