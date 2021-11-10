using CountyRP.Services.Site.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace CountyRP.Services.Site.Infrastructure.Infrastructure.DbContexts
{
    public class SiteDbContextFactory : IDesignTimeDbContextFactory<SiteDbContext>
    {
        public SiteDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SiteDbContext>()
                .UseSqlServer("Server=192.168.1.68,1433;Database=CountyRP.Services.Site;User Id=sa;Password=Test1234", opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));

            return new SiteDbContext(optionsBuilder.Options);
        }
    }
}
