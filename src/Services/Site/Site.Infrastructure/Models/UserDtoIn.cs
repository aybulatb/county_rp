namespace CountyRP.Services.Site.Infrastructure.Models
{
    public class UserDtoIn
    {
        public string Login { get; }

        public string Password { get; }

        public int PlayerId { get; }

        public int ForumUserId { get; }

        public string GroupId { get; }

        public UserDtoIn(
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
