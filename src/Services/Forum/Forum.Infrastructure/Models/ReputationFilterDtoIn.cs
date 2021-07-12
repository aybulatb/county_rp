namespace CountyRP.Services.Forum.Infrastructure.Models
{
    public class ReputationFilterDtoIn : PagedFilter
    {
        public int UserId { get; }

        public ReputationFilterDtoIn(
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
