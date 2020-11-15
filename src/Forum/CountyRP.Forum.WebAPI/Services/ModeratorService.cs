using System.Collections.Generic;
using System.Threading.Tasks;

using CountyRP.Forum.Domain.Interfaces;
using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.WebAPI.Services.Interfaces;

namespace CountyRP.Forum.WebAPI.Services
{
    public class ModeratorService : IModeratorService
    {
        private readonly IModeratorRepository _moderatorRepository;

        public ModeratorService(IModeratorRepository moderatorRepository)
        {
            _moderatorRepository = moderatorRepository;
        }

        public async Task<IEnumerable<Moderator>> GetAll()
        {
            return await _moderatorRepository.GetAll();
        }

        public async Task<Moderator> GetById(int id)
        {
            return await _moderatorRepository.GetById(id);
        }
    }
}
