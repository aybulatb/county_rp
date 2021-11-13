using System;

namespace CountyRP.ApiGateways.AdminPanel.API.Models.Api
{
    public record ApiPlayerFilterDtoIn : ApiPagedFilterDtoIn
    {
        public string LoginLike { get; init; }

        public string NameLike { get; init; }

        public string GroupId { get; init; }

        public bool? IsBanned { get; init; }

        public bool? IsAdmin { get; init; }

        public string FactionId { get; init; }

        public DateTimeOffset? StartRegistrationDate { get; init; }

        public DateTimeOffset? FinishRegistrationDate { get; init; }

        public DateTimeOffset? StartLastVisitSiteDate { get; init; }

        public DateTimeOffset? FinishLastVisitSiteDate { get; init; }

        public DateTimeOffset? StartLastVisitGameDate { get; init; }

        public DateTimeOffset? FinishLastVisitGameDate { get; init; }
    }
}
