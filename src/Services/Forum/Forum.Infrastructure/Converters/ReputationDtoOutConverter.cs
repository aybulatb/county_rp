using CountyRP.Services.Forum.Infrastructure.Entities;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.Infrastructure.Converters
{
    internal static class ReputationDtoOutConverter
    {
        public static ReputationDao ToDb(
            ReputationDtoOut source
        )
        {
            return new ReputationDao(
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
