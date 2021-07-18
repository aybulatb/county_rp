using CountyRP.ApiGateways.Forum.Infrastructure.Converters;
using CountyRP.ApiGateways.Forum.Infrastructure.Models;
using CountyRP.ApiGateways.Forum.Infrastructure.Services.Interfaces;
using CountyRP.Gateways.Forum.Infrastructure.RestClients.ServiceForum;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.Forum.Infrastructure.Services
{
    public class ForumService : IForumService
    {
        private readonly ForumClient _forumClient;

        public ForumService(ForumClient forumClient)
        {
            _forumClient = forumClient;
        }

        public async Task<ForumDtoOut> Create(ForumDtoIn forumDtoIn)
        {
            var apiForumDtoIn = ForumDtoInConverter.ToExternalService(forumDtoIn);

            var response = await _forumClient.CreateAsync(apiForumDtoIn);

            return new ForumDtoOut(
                response.Id, response.Name, response.ParentId, response.Order);
        }
    }
}
