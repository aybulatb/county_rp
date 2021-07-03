using CountyRP.Services.Site.Entities;
using CountyRP.Services.Site.Models;
using CountyRP.Services.Site.Models.Api;

namespace CountyRP.Services.Site.Converters
{
    public static class SupportRequestTopicDtoOutConverter
    {
        public static SupportRequestTopicDao ToDb(
            SupportRequestTopicDtoOut source
        )
        {
            return new SupportRequestTopicDao(
                id: source.Id,
                type: SupportRequestTopicTypeDtoConverter.ToDb(source.Type),
                caption: source.Caption,
                status: SupportRequestTopicStatusDtoConverter.ToDb(source.Status),
                creatorUserId: source.CreatorUserId,
                creationDate: source.CreationDate,
                refUserId: source.RefUserId,
                showRefUser: source.ShowRefUser
            );
        }

        public static ApiSupportRequestTopicDtoOut ToApi(
            SupportRequestTopicDtoOut source
        )
        {
            return new ApiSupportRequestTopicDtoOut(
                id: source.Id,
                type: SupportRequestTopicTypeDtoConverter.ToApi(source.Type),
                caption: source.Caption,
                status: SupportRequestTopicStatusDtoConverter.ToApi(source.Status),
                creatorUserId: source.CreatorUserId,
                creationDate: source.CreationDate,
                refUserId: source.RefUserId,
                showRefUser: source.ShowRefUser
            );
        }
    }
}
