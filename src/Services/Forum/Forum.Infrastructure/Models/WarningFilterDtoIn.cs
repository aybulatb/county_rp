namespace CountyRP.Services.Forum.Infrastructure.Models
{
    public class WarningFilterDtoIn : PagedFilter
    {
        public int UserId { get; }

        public WarningFilterDtoIn(
            int count,
            int page,
            int userId
        )
            : base(count, page)
        {
            UserId = userId;
        }
    }
}
