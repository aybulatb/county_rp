namespace CountyRP.Services.Site.API.Models.Api
{
    public class ApiUserDtoIn
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public int PlayerId { get; set; }

        public int ForumUserId { get; set; }

        public string GroupId { get; set; }
    }
}
