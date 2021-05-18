using CountyRP.Services.Forum.Entities;
using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;

namespace CountyRP.Services.Forum.Converters
{
    internal class PostDtoOutConverter
    {
        public static PostDao ToDb(
            PostDtoOut source
        )
        {
            return new PostDao(
                id: source.Id,
                text: source.Text,
                topicId: source.TopicId,
                userId: source.UserId,
                lastEditorId: source.LastEditorid,
                creationDateTime: source.CreationDateTime,
                editionDateTime: source.EditionDateTime
            );
        }
        public static ApiPostDtoOut ToApi(
            PostDtoOut source
        )
        {
            return new ApiPostDtoOut()
            {
                Id = source.Id,
                Text = source.Text,
                TopicId = source.TopicId,
                UserId = source.UserId,
                LastEditorId = source.LastEditorid,
                CreationDateTime = source.CreationDateTime,
                EditionDateTime = source.EditionDateTime
            };
        }
    }
}
