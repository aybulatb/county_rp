using Microsoft.EntityFrameworkCore;

using CountyRP.DAO;

namespace CountyRP.WebAPI.DbContexts
{
    public class FactionContext : DbContext
    {
        public DbSet<Faction> Factions { get; set; }
        public DbSet<LockerRoom> LockerRooms { get; set; }

        public FactionContext(DbContextOptions<FactionContext> options)
            : base(options)
        {
            Database.Migrate();
        }
    }
}
