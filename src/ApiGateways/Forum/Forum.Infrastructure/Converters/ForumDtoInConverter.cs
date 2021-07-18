using CountyRP.ApiGateways.Forum.Infrastructure.Models;
using CountyRP.Gateways.Forum.Infrastructure.RestClients.ServiceForum;

namespace CountyRP.ApiGateways.Forum.Infrastructure.Converters
{
    internal static class ForumDtoInConverter
    {
        public static ApiForumDtoIn ToExternalService(
            ForumDtoIn source
        )
        {
            return new ApiForumDtoIn 
            { 
                Name = source.Name, 
                Order = source.Order, 
                ParentId = source.ParentId 
            };
        }
    }
}
