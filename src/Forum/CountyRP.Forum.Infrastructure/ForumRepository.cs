using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

using CountyRP.Forum.Domain.Interfaces;
using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.Infrastructure.Models;

namespace CountyRP.Forum.Infrastructure
{
    public class ForumRepository : IForumRepository
    {
        private ForumContext _forumContext;

        public ForumRepository(ForumContext forumContext)
        {
            _forumContext = forumContext;
        }

        public async Task<IEnumerable<ForumModel>> GetAll()
        {
            var forums = _forumContext.Forums.Select(f => f).ToList();

            return forums;
        }

        public async Task<ForumModel> CreateForum(ForumModel forum)
        {
            _forumContext.Forums.Add(forum);

            await _forumContext.SaveChangesAsync();

            return forum;

        }

        public async Task<ForumModel> GetForum(int id)
        {
            var forum = _forumContext.Forums.FirstOrDefault(f => f.Id == id);

            return forum;
        }

        public async Task<ForumModel> Edit(int id, ForumModel forum)
        {
            var existingForum = _forumContext.Forums.FirstOrDefault(f => f.Id == id);
            existingForum.Name = forum.Name;
            existingForum.ParentId = forum.ParentId;

            await _forumContext.SaveChangesAsync();

            return existingForum;
        }

        public async Task Delete(int id)
        {
            var forum = _forumContext.Forums.FirstOrDefault(f => f.Id == id);
            _forumContext.Forums.Remove(forum);

            await _forumContext.SaveChangesAsync();
        }
    }
}
