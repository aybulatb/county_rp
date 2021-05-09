using CountyRP.Services.Forum.DbContexts;

namespace CountyRP.Services.Forum.Repositories
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
