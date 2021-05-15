namespace CountyRP.Services.Forum.Models.Api
{
    public class ApiUserDtoOut
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string GroupId { get; set; }

        public int Reputation { get; set; }

        public int Posts { get; set; }

        public int Warnings { get; set; }
    }
}
