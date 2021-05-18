using CountyRP.Services.Forum.Models;
using CountyRP.Services.Forum.Models.Api;

namespace CountyRP.Services.Forum.Converters
{
    internal class ApiPostFilterDtoInConverter
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
