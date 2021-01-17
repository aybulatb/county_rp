using System.Collections.Generic;
using System.Threading.Tasks;

using CountyRP.Forum.Domain.Interfaces;
using CountyRP.Forum.Domain.Models;
using CountyRP.Forum.WebAPI.Services.Interfaces;
using CountyRP.Forum.WebAPI.ViewModels;

namespace CountyRP.Forum.WebAPI.Services
{
    public class ModeratorService : IModeratorService
    {
        private readonly IModeratorRepository _moderatorRepository;

        public ModeratorService(IModeratorRepository moderatorRepository)
        {
            _moderatorRepository = moderatorRepository;
        }

        public async Task<Moderator> Create(ModeratorViewModel moderatorModel)
        {
            var moderator = new Moderator
            {
                ForumId = moderatorModel.ForumId,
                EntityId = moderatorModel.EntityId,
                EntityType = moderatorModel.EntityType,
                EditPosts = moderatorModel.EditPosts,
                DeletePosts = moderatorModel.DeletePosts,
                DeleteTopics = moderatorModel.DeleteTopics,
                CreatePosts = moderatorModel.CreatePosts,
                CreateTopics = moderatorModel.CreateTopics,
                Read = moderatorModel.Read
            };

            return await _moderatorRepository.Create(moderator);
        }

        public async Task Delete(int id)
        {
            await _moderatorRepository.Delete(id);
        }

        public async Task<Moderator> Edit(int id, ModeratorEditViewModel moderatorEditModel)
        {
            var moderator = new Moderator
            {
                Read = moderatorEditModel.Read,
                CreatePosts = moderatorEditModel.CreatePosts,
                CreateTopics = moderatorEditModel.CreateTopics,
                DeletePosts = moderatorEditModel.DeletePosts,
                DeleteTopics = moderatorEditModel.DeleteTopics,
                EditPosts = moderatorEditModel.EditPosts
            };

            return await _moderatorRepository.Edit(id, moderator);
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
