using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
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
