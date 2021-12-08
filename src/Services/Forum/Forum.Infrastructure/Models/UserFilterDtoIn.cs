using System.Collections.Generic;

namespace CountyRP.Services.Forum.Infrastructure.Models
{
    public class UserFilterDtoIn : PagedFilter
    {
        public string Login { get; }

        public string SortingFlag { get; }

        public IEnumerable<int> GroupIds { get; }

        public UserFilterDtoIn(
            int? count,
            int? page,
            string login,
            string sortingFlag,
            IEnumerable<int> groupIds
        )
            : base(count, page)
        {
            Login = login;
            GroupIds = groupIds;
            SortingFlag = sortingFlag;
        }
    }
}
