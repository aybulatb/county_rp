namespace CountyRP.Services.Site.Models.Api
{
    public class ApiUserDtoIn
    {
        public string Login { get; }

        public string Password { get; }

        public int PlayerId { get; }

        public int ForumUserId { get; }

        public string GroupId { get; }

        public ApiUserDtoIn(
            string login,
            string password,
            int playerId,
            int forumUserId,
            string groupId
        )
        {
            Login = login;
            Password = password;
            PlayerId = playerId;
            ForumUserId = forumUserId;
            GroupId = groupId;
        }
    }
}
