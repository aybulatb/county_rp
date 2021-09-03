using System;

namespace CountyRP.ApiGateways.AdminPanel.API.Models.Api
{
    public class ApiPlayerFilterDtoIn : ApiPagedFilterDtoIn
    {
        public string LoginLike { get; set; }

        public string NameLike { get; set; }

        public string GroupId { get; set; }

        public bool? IsBanned { get; set; }

        public bool? IsAdmin { get; set; }

        public string FactionId { get; set; }

        public DateTimeOffset? StartRegistrationDate { get; set; }

        public DateTimeOffset? FinishRegistrationDate { get; set; }

        public DateTimeOffset? StartLastVisitSiteDate { get; set; }

        public DateTimeOffset? FinishLastVisitSiteDate { get; set; }

        public DateTimeOffset? StartLastVisitGameDate { get; set; }

        public DateTimeOffset? FinishLastVisitGameDate { get; set; }
    }
}
