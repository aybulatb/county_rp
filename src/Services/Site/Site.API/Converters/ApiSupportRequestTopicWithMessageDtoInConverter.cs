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
                Type: ApiSupportRequestTopicTypeDtoConverter.ToRepository(source.Type),
                Caption: source.Caption,
                Status: ApiSupportRequestTopicStatusDtoConverter.ToRepository(source.Status),
                CreatorUserId: source.CreatorUserId,
                CreationDate: source.CreationDate,
                RefUserId: source.RefUserId,
                ShowRefUser: source.ShowRefUser
            );
        }

        public static SupportRequestMessageDtoIn ToSupportRequestMessageDtoIn(
            ApiSupportRequestTopicWithMessageDtoIn source,
            int topicId
        )
        {
            return new SupportRequestMessageDtoIn(
                TopicId: topicId,
                Text: source.Text,
                UserId: source.CreatorUserId,
                CreationDate: source.CreationDate,
                EditionDate: null
            );
        }
    }
}
