using Microsoft.EntityFrameworkCore;

using CountyRP.Entities;

namespace CountyRP.WebAPI.Models
{
    public class FactionContext : DbContext
    {
        public DbSet<Faction> Factions { get; set; }

        public FactionContext(DbContextOptions<FactionContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
