using CountyRP.ApiGateways.Forum.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.Forum.Infrastructure.Services.Interfaces
{
    public interface IModeratorService
    {
        Task<ModeratorDtoOut> Create(ModeratorDtoIn moderatorDtoIn);
    }
}
