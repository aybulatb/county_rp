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
                Type: ApiSupportRequestTopicTypeDtoConverter.ToRepository(source.Type),
                Caption: source.Caption,
                Status: ApiSupportRequestTopicStatusDtoConverter.ToRepository(source.Status),
                CreatorUserId: source.CreatorUserId,
                CreationDate: source.CreationDate,
                RefUserId: source.RefUserId,
                ShowRefUser: source.ShowRefUser
            );
        }
    }
}
