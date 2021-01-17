using Microsoft.EntityFrameworkCore;

using CountyRP.Forum.Domain.Models;

namespace CountyRP.Forum.Infrastructure.Models
{
    public class ModeratorContext : DbContext
    {
        public DbSet<Moderator> Moderators { get; set; }

        public ModeratorContext(DbContextOptions<ModeratorContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
