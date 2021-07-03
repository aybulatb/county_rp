using CountyRP.Services.Site.API.Models.Api;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.API.Converters
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
