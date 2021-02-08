using Microsoft.EntityFrameworkCore;

using CountyRP.DAO;

namespace CountyRP.WebAPI.DbContexts
{
    public class PlayerContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Person> Persons { get; set; }

        public PlayerContext(DbContextOptions<PlayerContext> options)
            : base(options)
        {
            Database.Migrate();
        }
    }
}
