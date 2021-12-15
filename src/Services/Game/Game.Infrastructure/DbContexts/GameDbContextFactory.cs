using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace CountyRP.Services.Game.Infrastructure.DbContexts
{
    public class GameDbContextFactory : IDesignTimeDbContextFactory<GameDbContext>
    {
        public GameDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GameDbContext>()
                .UseSqlServer("Server=192.168.1.68,1433;Database=CountyRP.Services.Game;User Id=sa;Password=Test1234", opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));

            return new GameDbContext(optionsBuilder.Options);
        }
    }
}
