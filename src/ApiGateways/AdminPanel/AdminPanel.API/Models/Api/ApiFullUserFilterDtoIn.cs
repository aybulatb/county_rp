using System;

namespace CountyRP.ApiGateways.AdminPanel.API.Models.Api
{
    public record ApiFullUserFilterDtoIn : ApiPagedFilterDtoIn
    {
        public string LoginLike { get; init; }

        public string PersonNameLike { get; init; }

        public int? GroupId { get; init; }

        public string FactionId { get; init; }

        public DateTimeOffset? StartRegistrationDate { get; init; }

        public DateTimeOffset? FinishRegistrationDate { get; init; }

        public DateTimeOffset? StartLastVisitSiteDate { get; init; }

        public DateTimeOffset? FinishLastVisitSiteDate { get; init; }

        public DateTimeOffset? StartLastVisitGameDate { get; init; }

        public DateTimeOffset? FinishLastVisitGameDate { get; init; }

        public bool? IsBannedOnSite { get; init; }

        public bool? IsBannedInGame { get; init; }

        public DateTimeOffset? StartBanOnSiteDate { get; init; }

        public DateTimeOffset? FinishBanOnSiteDate { get; init; }

        public DateTimeOffset? StartBanInGameDate { get; init; }

        public DateTimeOffset? FinishBanInGameDate { get; init; }

        public bool? AdminPanelAccess { get; init; }

        public bool? AdminInGame { get; init; }
    }
}
