using Microsoft.EntityFrameworkCore;

using CountyRP.DAO;

namespace CountyRP.WebAPI.Models
{
    public class InventoryContext : DbContext
    {
        public DbSet<Inventory> Inventories { get; set; }

        public InventoryContext(DbContextOptions<InventoryContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
