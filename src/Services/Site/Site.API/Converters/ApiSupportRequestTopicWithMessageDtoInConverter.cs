using CountyRP.Services.Site.API.Models.Api;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.API.Converters
{
    public static class ApiSupportRequestTopicWithMessageDtoInConverter
    {
        public static SupportRequestTopicDtoIn ToSupportRequestTopicDtoIn(
            ApiSupportRequestTopicWithMessageDtoIn source
        )
        {
            return new SupportRequestTopicDtoIn(
                type: ApiSupportRequestTopicTypeDtoConverter.ToRepository(source.Type),
                caption: source.Caption,
                status: ApiSupportRequestTopicStatusDtoConverter.ToRepository(source.Status),
                creatorUserId: source.CreatorUserId,
                creationDate: source.CreationDate,
                refUserId: source.RefUserId,
                showRefUser: source.ShowRefUser
            );
        }

        public static SupportRequestMessageDtoIn ToSupportRequestMessageDtoIn(
            ApiSupportRequestTopicWithMessageDtoIn source,
            int topicId
        )
        {
            return new SupportRequestMessageDtoIn(
                topicId: topicId,
                text: source.Text,
                userId: source.CreatorUserId,
                creationDate: source.CreationDate,
                editionDate: null
            );
        }
    }
}
