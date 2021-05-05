using System.ComponentModel.DataAnnotations;

namespace CountyRP.Services.Site.Entities
{
    public class UserDao
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(32)]
        public string Login { get; set; }

        [MaxLength(64)]
        public string Password { get; set; }

        public int PlayerId { get; set; }

        public int ForumUserId { get; set; }

        [MaxLength(16)]
        public string GroupId { get; set; }

        public UserDao(
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
