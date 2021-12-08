namespace CountyRP.Services.Forum.API.Models.Api
{
    public class ApiUserDtoOut
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public int GroupId { get; set; }

        public int Reputation { get; set; }

        public int Posts { get; set; }

        public int Warnings { get; set; }
    }
}
