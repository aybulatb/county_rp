using System.Collections.Generic;

namespace CountyRP.Services.Game.Infrastructure.Models
{
    public record GangFilterDtoIn : PagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; }

        public string Name { get; }

        public string NameLike { get; }

        public IEnumerable<GangTypeDto> Types { get; }

        public GangFilterDtoIn(
            int? count,
            int? page,
            IEnumerable<int> ids,
            string name,
            string nameLike,
            IEnumerable<GangTypeDto> types
        )
            : base(count, page)
        {
            Ids = ids;
            Name = name;
            NameLike = nameLike;
            Types = types;
        }
    }
}
