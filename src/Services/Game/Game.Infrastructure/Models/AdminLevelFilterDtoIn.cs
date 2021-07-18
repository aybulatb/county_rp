using System.Collections.Generic;

namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class AdminLevelFilterDtoIn : PagedFilterDtoIn
    {
        public IEnumerable<string> Ids { get; }

        public IEnumerable<string> Names { get; }

        public string NameLike { get; }

        public AdminLevelFilterDtoIn(
            int? count,
            int? page,
            IEnumerable<string> ids,
            IEnumerable<string> names,
            string nameLike
        )
            : base(count, page)
        {
            Ids = ids;
            Names = names;
            NameLike = nameLike;
        }
    }
}
