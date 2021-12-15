using CountyRP.Services.Game.Infrastructure.DbContexts;
using CountyRP.Services.Game.Infrastructure.Repositories.Interfaces;

namespace CountyRP.Services.Game.Infrastructure.Repositories.Implementations
{
    public partial class GameRepository : IGameRepository
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
