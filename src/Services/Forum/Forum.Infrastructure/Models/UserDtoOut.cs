namespace CountyRP.Services.Forum.Infrastructure.Models
{
    public class UserDtoOut
    {
        public int Id { get; }

        public string Login { get; }

        public int GroupId { get; }

        public int Reputation { get; }

        public int Posts { get; }

        public int Warnings { get; }

        public UserDtoOut(
            int id,
            string login,
            int groupId,
            int reputation,
            int posts,
            int warnings
        )
        {
            Id = id;
            Login = login;
            GroupId = groupId;
            Reputation = reputation;
            Posts = posts;
            Warnings = warnings;
        }
    }
}
