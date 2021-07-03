using CountyRP.Services.Site.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CountyRP.Services.Site.Infrastructure.DbContexts
{
    public class SiteDbContext : DbContext
    {
        public DbSet<UserDao> Users { get; set; }

        public DbSet<GroupDao> Groups { get; set; }

        public DbSet<BanDao> Bans { get; set; }

        public DbSet<SupportRequestTopicDao> SupportRequestTopics { get; set; }

        public DbSet<SupportRequestMessageDao> SupportRequestMessages { get; set; }

        public SiteDbContext(
            DbContextOptions<SiteDbContext> options
        )
            : base(options)
        {
        }
    }
}
