using System.Collections.Generic;

namespace CountyRP.Services.Game.Infrastructure.Models
{
    public record BusinessFilterDtoIn : PagedFilterDtoIn
    {
        public IEnumerable<int> Ids { get; }

        public string Name { get; }

        public string NameLike { get; }

        public IEnumerable<int> OwnerIds { get; }

        public IEnumerable<BusinessTypeDto> Types { get; }

        public BusinessFilterDtoIn(
            int? count,
            int? page,
            IEnumerable<int> ids,
            string name,
            string nameLike,
            IEnumerable<int> ownerIds,
            IEnumerable<BusinessTypeDto> types
        )
            : base(count, page)
        {
            Ids = ids;
            Name = name;
            NameLike = nameLike;
            OwnerIds = ownerIds;
            Types = types;
        }
    }
}
