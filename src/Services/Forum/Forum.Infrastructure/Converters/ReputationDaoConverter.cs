using CountyRP.Services.Forum.Infrastructure.Entities;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.Infrastructure.Converters
{
    internal static class ReputationDaoConverter
    {
        public static ReputationDtoOut ToRepository(
            ReputationDao source
        )
        {
            return new ReputationDtoOut(
                id: source.Id,
                userId: source.UserId,
                changedByUserId: source.ChangedByUserId,
                dateTime: source.DateTime,
                action: source.Action,
                text: source.Text
            );
        }
    }
}
