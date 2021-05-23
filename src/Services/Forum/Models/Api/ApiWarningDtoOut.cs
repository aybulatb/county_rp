using System;

namespace CountyRP.Services.Forum.Models.Api
{
    public class ApiWarningDtoOut
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int AdminId { get; set; }

        public DateTimeOffset DateTime { get; set; }

        public DateTimeOffset FinishDateTime { get; set; }

        public int Action { get; set; }

        public string Text { get; set; }
    }
}
