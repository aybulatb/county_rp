using CountyRP.ApiGateways.Forum.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.Forum.Infrastructure.Services.Interfaces
{
    public interface IForumService
    {
        Task<ForumDtoOut> Create(ForumDtoIn forumDtoIn);
    }
}
