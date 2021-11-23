namespace CountyRP.Services.Forum.API.Models.Api
{
    public class ApiModeratorFilterDtoIn : ApiPagedFilter
    {
        public int? EntityId { get; set; }

        public int? EntityType { get; set; }

        public int? ForumId { get; set; }
    }
}
