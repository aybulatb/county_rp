using CountyRP.Services.Site.API.Models.Api;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.API.Converters
{
    public static class SupportRequestTopicDtoOutConverter
    {        public static ApiSupportRequestTopicDtoOut ToApi(
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
