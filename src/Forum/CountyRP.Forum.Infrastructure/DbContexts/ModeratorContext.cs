using Microsoft.EntityFrameworkCore;

using CountyRP.Forum.Domain.Models;

namespace CountyRP.Forum.Infrastructure.DbContexts
{
    public class ModeratorContext : DbContext
    {
        public DbSet<Moderator> Moderators { get; set; }

        public ModeratorContext(DbContextOptions<ModeratorContext> options)
            : base(options)
        {
            Database.Migrate();
        }
    }
}
