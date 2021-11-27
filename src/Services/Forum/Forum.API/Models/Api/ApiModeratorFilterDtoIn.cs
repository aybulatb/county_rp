namespace CountyRP.Services.Forum.API.Models.Api
{
    public class ApiModeratorFilterDtoIn : ApiPagedFilter
    {
        public int? EntityId { get; init; }

        public int? EntityType { get; init; }

        public int? ForumId { get; init; }
    }
}
