namespace CountyRP.Services.Forum.Infrastructure.Models
{
    public class UserDtoIn
    {
        public string Login { get; }

        public string GroupId { get; }

        public int Reputation { get; }

        public int Posts { get; }

        public int Warnings { get; }

        public UserDtoIn(
            string login,
            string groupId,
            int reputation,
            int posts,
            int warnings
        )
        {
            Login = login;
            GroupId = groupId;
            Reputation = reputation;
            Posts = posts;
            Warnings = warnings;
        }
    }
}
