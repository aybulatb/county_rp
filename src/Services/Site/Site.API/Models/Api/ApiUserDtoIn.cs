namespace CountyRP.Services.Site.API.Models.Api
{
    public record ApiUserDtoIn
    {
        public string Login { get; init; }

        public string Password { get; init; }

        public int PlayerId { get; init; }

        public int ForumUserId { get; init; }

        public string GroupId { get; init; }
    }
}
