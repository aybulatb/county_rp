using Microsoft.EntityFrameworkCore;

using CountyRP.DAO;

namespace CountyRP.WebAPI.Models
{
    public class PlayerContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Person> Persons { get; set; }

        public PlayerContext(DbContextOptions<PlayerContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
