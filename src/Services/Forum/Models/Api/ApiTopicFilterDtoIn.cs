namespace CountyRP.Services.Forum.Models.Api
{
    public class ApiTopicFilterDtoIn : ApiPagedFilter
    {
        public int ForumId { get; set; }
    }
}
