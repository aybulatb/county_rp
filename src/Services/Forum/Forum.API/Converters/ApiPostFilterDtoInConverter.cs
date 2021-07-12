using CountyRP.Services.Forum.API.Models.Api;
using CountyRP.Services.Forum.Infrastructure.Models;

namespace CountyRP.Services.Forum.API.Converters
{
    internal static class ApiPostFilterDtoInConverter
    {
        public static PostFilterDtoIn ToRepository(
            ApiPostFilterDtoIn source
        )
        {
            return new PostFilterDtoIn(
                count: source.Count,
                page: source.Page,
                text: source.Text,
                creationDateTime: source.CreationDateTime,
                editionDateTime: source.EditionDateTime
            );
        }
    }
}
