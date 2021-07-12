namespace CountyRP.Services.Forum.API.Models.Api
{
    public class ApiUserDtoIn
    {
        public string Login { get; set; }

        public string GroupId { get; set; }

        public int Reputation { get; set; }

        public int Posts { get; set; }

        public int Warnings { get; set; }
    }
}
