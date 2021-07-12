using CountyRP.Services.Forum.Infrastructure.Entities;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.Infrastructure.Converters
{
    internal static class ReputationDtoInConverter
    {
        public static ReputationDao ToDb(
            ReputationDtoIn source
        )
        {
            return new ReputationDao(
                id: 0,
                userId: source.UserId,
                changedByUserId: source.ChangedByUserId,
                dateTime: source.DateTime,
                action: source.Action,
                text: source.Text
            );
        }

        public static ReputationDtoOut ToDtoOut(
            ReputationDtoIn source,
            int id
        )
        {
            return new ReputationDtoOut(
                id: id,
                userId: source.UserId,
                changedByUserId: source.ChangedByUserId,
                dateTime: source.DateTime,
                action: source.Action,
                text: source.Text
            );
        }
    }
}
