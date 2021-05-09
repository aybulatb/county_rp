namespace CountyRP.Services.Forum.Models.Api
{
    public class ApiUserDtoIn
    {
        public string Login { get; }

        public string GroupId { get; }

        public int Reputation { get; }

        public int Posts { get; }

        public int Warnings { get; }

        public ApiUserDtoIn(
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
