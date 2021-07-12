namespace CountyRP.Services.Forum.API.Models.Api
{
    public class ApiTopicFilterDtoIn : ApiPagedFilter
    {
        public int ForumId { get; set; }
    }
}
