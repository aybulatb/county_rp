using CountyRP.ApiGateways.AdminPanel.Infrastructure.RestClients.ServiceForum;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;
using System.Linq;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Converters
{
    internal static class ApiHierarchicalForumDtoOutConverter
    {
        public static ForumHierarchicalForumDtoOut ToService(
            ApiHierarchicalForumDtoOut source
        )
        {
            return new ForumHierarchicalForumDtoOut(
                Id: source.Id,
                Name: source.Name,
                ParentId: source.ParentId,
                Order: source.Order,
                ChildForums: source.ChildForums
                    ?.Select(ApiHierarchicalForumDtoOutConverter.ToService)
            );
        }
    }
}
