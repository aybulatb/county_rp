using Microsoft.EntityFrameworkCore;

using CountyRP.Forum.Domain.Models;

namespace CountyRP.Forum.Infrastructure.DbContexts
{
    public class ForumContext : DbContext
    {
        public DbSet<ForumModel> Forums { get; set; }

        public ForumContext(DbContextOptions<ForumContext> options)
            : base(options)
        {
            Database.Migrate();
        }
    }
}
