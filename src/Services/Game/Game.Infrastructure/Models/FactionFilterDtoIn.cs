using System.Collections.Generic;

namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class FactionFilterDtoIn : PagedFilterDtoIn
    {
        public IEnumerable<string> Ids { get; }

        public string IdLike { get; }

        public IEnumerable<string> Names { get; }

        public string NameLike { get; }

        public IEnumerable<FactionTypeDto> Types { get; }

        public FactionFilterDtoIn(
            int? count,
            int? page,
            IEnumerable<string> ids,
            string idLike,
            IEnumerable<string> names,
            string nameLike,
            IEnumerable<FactionTypeDto> types
        )
            : base(count, page)
        {
            Ids = ids;
            IdLike = idLike;
            Names = names;
            NameLike = nameLike;
            Types = types;
        }
    }
}
