using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CountyRP.Forum.Domain.Interfaces;
using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.Infrastructure.Models;

namespace CountyRP.Forum.Infrastructure
{
    public class ModeratorRepository : IModeratorRepository
    {
        private ModeratorContext _moderatorContext;

        public ModeratorRepository(ModeratorContext moderatorContext)
        {
            _moderatorContext = moderatorContext;
        }

        public async Task<IEnumerable<Moderator>> GetAll()
        {
            return _moderatorContext.Moderators.ToArray();
        }

        public async Task<Moderator> GetById(int id)
        {
            return _moderatorContext.Moderators.FirstOrDefault(m => m.Id == id);
        }
    }
}
