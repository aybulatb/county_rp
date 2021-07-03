using CountyRP.Services.Site.Infrastructure.DbContexts;
using System;

namespace CountyRP.Services.Site.Infrastructure.Repositories
{
    public partial class SiteRepository : ISiteRepository
    {
        private SiteDbContext _siteDbContext;

        public SiteRepository(
            SiteDbContext siteDbContext
        )
        {
            _siteDbContext = siteDbContext ?? throw new ArgumentNullException(nameof(siteDbContext));
        }
    }
}
