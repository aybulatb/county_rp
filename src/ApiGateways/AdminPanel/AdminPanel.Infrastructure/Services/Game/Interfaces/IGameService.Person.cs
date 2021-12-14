using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models.Persons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Interfaces
{
    public partial interface IGameService
    {
        Task<GamePagedFilterResultDtoOut<GamePersonDtoOut>> GetPersonsByFilterAsync(GamePersonFilterDtoIn gamePersonFilterDtoIn);

        Task UpdatePersonsAsync(IEnumerable<GameEditedPersonDtoIn> editedPersonsDtoIn);

        Task DeletePersonsAsync(IEnumerable<int> ids);
    }
}
