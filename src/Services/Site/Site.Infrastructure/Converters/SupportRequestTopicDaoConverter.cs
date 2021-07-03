using CountyRP.Services.Site.Infrastructure.Entities;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.Infrastructure.Converters
{
    public static class SupportRequestTopicDaoConverter
    {
        public static SupportRequestTopicDtoOut ToRepository(
            SupportRequestTopicDao source
        )
        {
            return new SupportRequestTopicDtoOut(
                id: source.Id,
                type: SupportRequestTopicTypeDaoConverter.ToRepository(source.Type),
                caption: source.Caption,
                status: SupportRequestTopicStatusDaoConverter.ToRepository(source.Status),
                creatorUserId: source.CreatorUserId,
                creationDate: source.CreationDate,
                refUserId: source.RefUserId,
                showRefUser: source.ShowRefUser
            );
        }
    }
}
