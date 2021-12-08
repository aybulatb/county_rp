using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.API.Models.Api
{
    public record ApiForumWithModeratorsDtoOut
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public int ParentId { get; init; }

        public int Order { get; init; }

        public IEnumerable<ApiModeratorDtoOut> Moderators { get; init; }

        public ApiForumWithModeratorsDtoOut(
            int id,
            string name,
            int parentId,
            int order,
            IEnumerable<ApiModeratorDtoOut> moderators
        )
        {
            Id = id;
            Name = name;
            ParentId = parentId;
            Order = order;
            Moderators = moderators;
        }
    }
}
