using System.Collections.Generic;

namespace CountyRP.Services.Forum.Infrastructure.Models
{
    public record HierarchicalForumDtoOut
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public int ParentId { get; init; }

        public int Order { get; init; }

        public IList<HierarchicalForumDtoOut> ChildForums { get; init; }

        public HierarchicalForumDtoOut()
        {
        }

        public HierarchicalForumDtoOut(
            int id,
            string name,
            int parentId,
            int order,
            IList<HierarchicalForumDtoOut> childForums
        )
        {
            Id = id;
            Name = name;
            ParentId = parentId;
            Order = order;
            ChildForums = childForums;
        }
    };
}
