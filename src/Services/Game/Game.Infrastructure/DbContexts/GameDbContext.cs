using CountyRP.Services.Game.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CountyRP.Services.Game.Infrastructure.DbContexts
{
    public class GameDbContext : DbContext
    {
        public DbSet<PlayerDao> Players { get; set; }

        public DbSet<PersonDao> Persons { get; set; }

        public DbSet<AdminLevelDao> AdminLevels { get; set; }

        public DbSet<AppearanceDao> Appearances { get; set; }

        public DbSet<ATMDao> ATMs { get; set; }

        public DbSet<BusinessDao> Businesses { get; set; }

        public DbSet<FactionDao> Factions { get; set; }

        public DbSet<GangDao> Gangs { get; set; }

        public DbSet<GarageDao> Garages { get; set; }

        public DbSet<HouseDao> Houses { get; set; }

        public DbSet<LockerRoomDao> LockerRooms { get; set; }

        public DbSet<RoomDao> Rooms { get; set; }

        public DbSet<TeleportDao> Teleports { get; set; }

        public DbSet<VehicleDao> Vehicles { get; set; }

        public GameDbContext(
            DbContextOptions<GameDbContext> options
        )
            : base(options)
        {
        }
    }
}
