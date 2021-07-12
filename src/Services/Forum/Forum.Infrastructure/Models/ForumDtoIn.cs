namespace CountyRP.Services.Forum.Infrastructure.Models
{
    public class ForumDtoIn
    {
        public string Name { get; }

        public int ParentId { get; }

        public int Order { get; }

        public ForumDtoIn(
            string name,
            int parentId,
            int order
        )
        {
            Name = name;
            ParentId = parentId;
            Order = order;
        }
    }
}
