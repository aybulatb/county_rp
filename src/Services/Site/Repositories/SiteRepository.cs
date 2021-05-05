using CountyRP.Services.Site.DbContexts;

namespace CountyRP.Services.Site.Repositories
{
    public partial class SiteRepository : ISiteRepository
    {
        private SiteDbContext _siteDbContext;

        public SiteRepository(
            SiteDbContext siteDbContext
        )
        {
            _siteDbContext = siteDbContext;
        }
    }
}
