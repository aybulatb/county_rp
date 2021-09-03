using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Site.Models
{
    public class SiteUserFilterDtoIn
    {
        public int? Count { get; }

        public int? Page { get; }

        public string Login { get; }

        public IEnumerable<string> GroupIds { get; }

        public SiteUserFilterDtoIn(
            string login,
            IEnumerable<string> groupIds
        )
        {
            Login = login;
            GroupIds = groupIds;
        }
    }
}
