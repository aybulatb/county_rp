using Microsoft.EntityFrameworkCore;

using CountyRP.Entities;

namespace CountyRP.WebAPI.Models
{
    public class GroupContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<AdminLevel> AdminLevels { get; set; }

        public GroupContext(DbContextOptions<GroupContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
