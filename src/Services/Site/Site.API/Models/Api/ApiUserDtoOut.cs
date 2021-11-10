namespace CountyRP.Services.Site.API.Models.Api
{
    public record ApiUserDtoOut
    {
        public int Id { get; init; }

        public string Login { get; init; }

        public string Password { get; init; }

        public int PlayerId { get; init; }

        public int ForumUserId { get; init; }

        public string GroupId { get; init; }

        public ApiUserDtoOut(
            int id,
            string login,
            string password,
            int playerId,
            int forumUserId,
            string groupId
        )
        {
            Id = id;
            Login = login;
            Password = password;
            PlayerId = playerId;
            ForumUserId = forumUserId;
            GroupId = groupId;
        }
    }
}
