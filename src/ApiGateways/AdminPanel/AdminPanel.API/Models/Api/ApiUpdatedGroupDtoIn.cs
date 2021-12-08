using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.API.Models.Api
{
    public record ApiUpdatedGroupDtoIn
    {
        public string Name { get; init; }

        public string Color { get; init; }

        public bool Admin { get; init; }

        public bool AdminPanel { get; init; }

        public bool CreateUsers { get; init; }

        public bool DeleteUsers { get; init; }

        public bool ChangeLogin { get; init; }

        public bool ChangeGroup { get; init; }

        public bool EditGroups { get; init; }

        public int MaxBan { get; init; }

        public IEnumerable<int> BanGroupIds { get; init; }

        public bool SeeLogs { get; init; }
    }
}
