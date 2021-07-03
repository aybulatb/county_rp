using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Models.Api;

namespace CountyRP.Services.Site.Converters
{
    public static class ApiSupportRequestTopicDtoInConverter
    {
        public static SupportRequestTopicDtoIn ToRepository(
            ApiSupportRequestTopicDtoIn source
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
    }
}
