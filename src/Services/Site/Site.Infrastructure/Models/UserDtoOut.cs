namespace CountyRP.Services.Site.Infrastructure.Models
{
    public class UserDtoOut
    {
        public int Id { get; }

        public string Login { get; }

        public string Password { get; }

        public int PlayerId { get; }

        public int ForumUserId { get; }

        public string GroupId { get; }

        public UserDtoOut(
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
