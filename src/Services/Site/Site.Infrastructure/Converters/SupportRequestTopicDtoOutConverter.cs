using CountyRP.Services.Site.Infrastructure.Entities;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.Infrastructure.Converters
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
    }
}
