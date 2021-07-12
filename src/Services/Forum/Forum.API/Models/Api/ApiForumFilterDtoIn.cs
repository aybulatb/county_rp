namespace CountyRP.Services.Forum.API.Models.Api
{
    public class ApiForumFilterDtoIn : ApiPagedFilter
    {
        public int ParentId { get; set; }
    }
}
