using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
{
    internal static class ModeratorDtoOutConverter
    {
        public static ApiModeratorDtoOut ToApi(
            ModeratorDtoOut source
        )
        {
            return new ApiModeratorDtoOut()
            {
                Id = source.Id,
                EntityId = source.EntityId,
                EntityType = source.EntityType,
                ForumId = source.ForumId,
                CreateTopics = source.CreateTopics,
                CreatePosts = source.CreatePosts,
                Read = source.Read,
                EditPosts = source.EditPosts,
                DeleteTopics = source.DeleteTopics,
                DeletePosts = source.DeletePosts
            };
        }
    }
}
