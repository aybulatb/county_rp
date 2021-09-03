using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Interfaces
{
    public partial interface IGameService
    {
        Task<GamePagedFilterResultDtoOut<GamePersonDtoOut>> GetPersonsByFilter(GamePersonFilterDtoIn gamePersonFilterDtoIn);
    }
}
