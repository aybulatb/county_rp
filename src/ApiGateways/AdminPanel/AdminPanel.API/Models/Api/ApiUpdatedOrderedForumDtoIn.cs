namespace CountyRP.ApiGateways.AdminPanel.API.Models.Api
{
    public record ApiUpdatedOrderedForumDtoIn
    {
        public int Id { get; init; }

        public int ParentId { get; init; }

        public int Order { get; init; }
    }
}
