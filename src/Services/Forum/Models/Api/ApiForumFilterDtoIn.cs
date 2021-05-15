namespace CountyRP.Services.Forum.Models.Api
{
    public class ApiForumFilterDtoIn : ApiPagedFilter
    {
        public int ParentId { get; set; }
    }
}
