namespace CountyRP.Services.Forum.Models.Api
{
    public class ApiForumDtoOut
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ParentId { get; set; }

        public int Order { get; set; }
    }
}
