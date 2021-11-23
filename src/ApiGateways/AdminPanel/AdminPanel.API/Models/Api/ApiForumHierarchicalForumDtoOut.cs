using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.API.Models.Api
{
    public record ApiForumHierarchicalForumDtoOut
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public int ParentId { get; init; }

        public int Order { get; init; }

        public IEnumerable<ApiForumHierarchicalForumDtoOut> ChildForums { get; init; }

        public ApiForumHierarchicalForumDtoOut(
            int id,
            string name,
            int parentId,
            int order,
            IEnumerable<ApiForumHierarchicalForumDtoOut> childForums
        )
        {
            Id = id;
            Name = name;
            ParentId = parentId;
            Order = order;
            ChildForums = childForums;
        }
    }
}
