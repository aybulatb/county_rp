using Microsoft.EntityFrameworkCore;

using CountyRP.Entities;

namespace CountyRP.WebAPI.Models
{
    public class PropertyContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
