using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using CountyRP.Forum.Domain.Interfaces;
using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.Infrastructure.DbContexts;

namespace CountyRP.Forum.Infrastructure
{
    public class ModeratorRepository : IModeratorRepository
    {
        private ModeratorContext _moderatorContext;

        public ModeratorRepository(ModeratorContext moderatorContext)
        {
            _moderatorContext = moderatorContext;
        }

        public async Task<Moderator> Create(Moderator moderator)
        {
            _moderatorContext.Moderators.Add(moderator);

            await _moderatorContext.SaveChangesAsync();
            return moderator;
        }

        public async Task Delete(int id)
        {
            var moder = _moderatorContext.Moderators.FirstOrDefault(m => m.Id.Equals(id));

            _moderatorContext.Moderators.Remove(moder);
            await _moderatorContext.SaveChangesAsync();
        }

        public async Task<Moderator> Edit(int id, Moderator moderator)
        {
            var existingModerator = _moderatorContext.Moderators.FirstOrDefault(m => m.Id.Equals(id));

            existingModerator.Read = moderator.Read;
            existingModerator.EditPosts = moderator.EditPosts;
            existingModerator.DeleteTopics = moderator.DeleteTopics;
            existingModerator.DeletePosts = moderator.DeletePosts;
            existingModerator.CreateTopics = moderator.CreateTopics;
            existingModerator.CreatePosts = moderator.CreatePosts;

            await _moderatorContext.SaveChangesAsync();
            return existingModerator;
        }

        public async Task<IEnumerable<Moderator>> GetAll()
        {
            return await _moderatorContext.Moderators
                .ToArrayAsync();
        }

        public async Task<Moderator> GetById(int id)
        {
            return await _moderatorContext.Moderators
                .FirstOrDefaultAsync(m => m.Id == id);
        }


    }
}
