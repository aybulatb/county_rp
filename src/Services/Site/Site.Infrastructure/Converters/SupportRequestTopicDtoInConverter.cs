using CountyRP.Services.Site.Infrastructure.Entities;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.Infrastructure.Converters
{
    public static class SupportRequestTopicDtoInConverter
    {
        public static SupportRequestTopicDao ToDb(
            SupportRequestTopicDtoIn source
        )
        {
            return new SupportRequestTopicDao(
                id: 0,
                type: SupportRequestTopicTypeDtoConverter.ToDb(source.Type),
                caption: source.Caption,
                status: SupportRequestTopicStatusDtoConverter.ToDb(source.Status),
                creatorUserId: source.CreatorUserId,
                creationDate: source.CreationDate,
                refUserId: source.RefUserId,
                showRefUser: source.ShowRefUser
            );
        }
    }
}
