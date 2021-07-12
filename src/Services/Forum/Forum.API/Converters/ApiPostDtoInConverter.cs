using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
{
    internal static class ApiPostDtoInConverter
    {
        public static PostDtoIn ToRepository(
            ApiPostDtoIn source
        )
        {
            return new PostDtoIn(
                text: source.Text,
                topicId: source.TopicId,
                userId: source.UserId,
                lastEditorId: source.LastEditorid,
                creationDateTime: source.CreationDateTime,
                editionDateTime: source.EditionDateTime
            );
        }

        public static PostDtoOut ToDtoOut(
           ApiPostDtoIn source,
           int id
        )
        {
            return new PostDtoOut(
                id: id,
                text: source.Text,
                topicId: source.TopicId,
                userId: source.UserId,
                lastEditorId: source.LastEditorid,
                creationDateTime: source.CreationDateTime,
                editionDateTime: source.EditionDateTime
            );
        }
    }
}
