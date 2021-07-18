using CountyRP.ApiGateways.Forum.Infrastructure.Models;
using CountyRP.ApiGateways.Forum.Infrastructure.Services.Interfaces;
using CountyRP.Gateways.Forum.Infrastructure.RestClients.ServiceForum;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.Forum.Infrastructure.Services
{
    public class ModeratorService : IModeratorService
    {
        private readonly ModeratorClient _moderatorClient;

        public ModeratorService(ModeratorClient moderatorClient)
        {
            _moderatorClient = moderatorClient;
        }

        public async Task<ModeratorDtoOut> Create(ModeratorDtoIn moderatorDtoIn)
        {
            var response = await _moderatorClient.CreateAsync(
                new ApiModeratorDtoIn
                {
                    CreatePosts = moderatorDtoIn.CreatePosts,
                    CreateTopics = moderatorDtoIn.CreateTopics,
                    DeletePosts = moderatorDtoIn.DeletePosts,
                    DeleteTopics = moderatorDtoIn.DeleteTopics,
                    EditPosts = moderatorDtoIn.EditPosts,
                    EntityId = moderatorDtoIn.EntityId,
                    EntityType = moderatorDtoIn.EntityType,
                    ForumId = moderatorDtoIn.ForumId,
                    Read = moderatorDtoIn.Read
                });

            return new ModeratorDtoOut(
                response.Id, response.EntityId, response.EntityType, response.ForumId, response.CreateTopics,
                response.CreatePosts, response.Read, response.EditPosts, response.DeleteTopics, response.DeletePosts);
        }
    }
}
