using CountyRP.Services.Forum.Infrastructure.DbContexts;

namespace CountyRP.Services.Forum.Infrastructure.Repositories
{
    public partial class ForumRepository : IForumRepository
    {
        private readonly ForumDbContext _forumDbContext;

        public ForumRepository(
            ForumDbContext forumDbContext
        )
        {
            _forumDbContext = forumDbContext;
        }
    }
}
