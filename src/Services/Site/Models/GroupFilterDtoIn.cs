namespace CountyRP.Services.Site.Models
{
    public class GroupFilterDtoIn : PagedFilter
    {
        public string Name { get; }

        public GroupFilterDtoIn(
            int count,
            int page,
            string name
        )
            : base(count, page)
        {
            Name = name;
        }
    }
}
