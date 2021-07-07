using CountyRP.Services.Game.Infrastructure.DbContexts;

namespace CountyRP.Services.Game.Infrastructure.Repositories
{
    public partial class GameRepository
    {
        private readonly GameDbContext _gameDbContext;

        public GameRepository(
            GameDbContext gameDbContext
        )
        {
            _gameDbContext = gameDbContext;
        }
    }
}
