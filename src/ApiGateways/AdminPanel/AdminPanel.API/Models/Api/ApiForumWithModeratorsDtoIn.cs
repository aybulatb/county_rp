using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.API.Models.Api
{
    public class ApiForumWithModeratorsDtoIn
    {
        public string Name { get; init; }

        public int ParentId { get; init; }

        public int Order { get; init; }

        public IEnumerable<ApiModeratorDtoIn> Moderators { get; init; }

        public ApiForumWithModeratorsDtoIn(
            string name,
            int parentId,
            int order,
            IEnumerable<ApiModeratorDtoIn> moderators
        )
        {
            Name = name;
            ParentId = parentId;
            Order = order;
            Moderators = moderators;
        }
    }
}
