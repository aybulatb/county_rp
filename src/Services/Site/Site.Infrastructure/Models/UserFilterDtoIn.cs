using System.Collections.Generic;

namespace CountyRP.Services.Site.Infrastructure.Models
{
    public class UserFilterDtoIn : PagedFilter
    {
        public string Login { get; }

        public IEnumerable<string> GroupIds { get; }

        public UserFilterDtoIn(
            int count,
            int page,
            string login,
            IEnumerable<string> groupIds
        )
            : base(count, page)
        {
            Login = login;
            GroupIds = groupIds;
        }
    }
}
