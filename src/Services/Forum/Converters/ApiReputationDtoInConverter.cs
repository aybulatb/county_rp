using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;

namespace CountyRP.Services.Forum.Converters
{
    internal static class ApiReputationDtoInConverter
    {
        public static ReputationDtoIn ToRepository(
            ApiReputationDtoIn source
        )
        {
            return new ReputationDtoIn(
                userId: source.UserId,
                changedByUserId: source.ChangedByUserId,
                dateTime: source.DateTime,
                action: source.Action,
                text: source.Text
            );
        }
    }
}
