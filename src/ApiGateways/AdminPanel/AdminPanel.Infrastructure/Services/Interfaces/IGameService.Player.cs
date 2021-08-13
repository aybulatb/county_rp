using CountyRP.ApiGateways.AdminPanel.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Interfaces
{
    public partial interface IGameService
    {
        Task<PlayerDtoOut> GetPlayerByIdAsync(int id);
    }
}
