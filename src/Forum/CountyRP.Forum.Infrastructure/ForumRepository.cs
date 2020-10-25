using System.Threading.Tasks;

using CountyRP.Forum.Domain;
using CountyRP.Forum.Domain.Interfaces;
using CountyRP.Forum.Domain.Exceptions;

namespace CountyRP.Forum.Infrastructure
{
    public class ForumRepository : IForumRepository
    {
        private ForumContext _forumContext;
        public ForumRepository(ForumContext forumContext)
        {
            _forumContext = forumContext;
        }

        public async Task CreateForum(ForumModel forum)
        {
            try
            {
                _forumContext.Forums.Add(forum);

                await _forumContext.SaveChangesAsync();
            }
            catch (Extra.ApiException ex)
            {
                throw new ForumException(ex.StatusCode, ex.Message);
            }
        }
    }
}
