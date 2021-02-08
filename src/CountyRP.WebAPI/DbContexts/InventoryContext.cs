using Microsoft.EntityFrameworkCore;

using CountyRP.DAO;

namespace CountyRP.WebAPI.DbContexts
{
    public class InventoryContext : DbContext
    {
        public DbSet<Inventory> Inventories { get; set; }

        public InventoryContext(DbContextOptions<InventoryContext> options)
            : base(options)
        {
            Database.Migrate();
        }
    }
}
