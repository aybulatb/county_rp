namespace CountyRP.Services.Site.Models.Api
{
    public class ApiSupportRequestMessageFilterDtoIn : ApiPagedFilter
    {
        public int? TopicId { get; set; }

        public int? UserId { get; set; }
    }
}
