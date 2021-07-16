using CountyRP.Services.Game.Infrastructure.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.Infrastructure.Repositories
{
    public partial interface IGameRepository
    {
        public Task<PersonDtoOut> AddPersonAsync(PersonDtoIn PersonDtoIn);

        public Task<PagedFilterResultDtoOut<PersonDtoOut>> GetPersonsByFilter(PersonFilterDtoIn filter);

        public Task<PersonDtoOut> UpdatePersonAsync(EditedPersonDtoIn editedPersonDtoIn);

        public Task DeletePersonByFilter(PersonFilterDtoIn filter);
    }
}
