using System.Collections.Generic;

namespace CountyRP.Services.Forum.API.Models.Api
{
    public record ApiHierarchicalForumDtoOut
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public int ParentId { get; init; }

        public int Order { get; init; }

        public IList<ApiHierarchicalForumDtoOut> ChildForums { get; init; }

        public ApiHierarchicalForumDtoOut(
            int id,
            string name,
            int parentId,
            int order,
            IList<ApiHierarchicalForumDtoOut> childForums
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
