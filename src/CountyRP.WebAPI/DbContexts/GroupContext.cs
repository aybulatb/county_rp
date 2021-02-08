using Microsoft.EntityFrameworkCore;

using CountyRP.DAO;

namespace CountyRP.WebAPI.DbContexts
{
    public class GroupContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }

        public GroupContext(DbContextOptions<GroupContext> options)
            : base(options)
        {
            Database.Migrate();
        }
    }
}
