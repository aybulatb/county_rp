using CountyRP.Services.Game.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.Infrastructure.Repositories
{
    public partial interface IGameRepository
    {
        public Task<PersonDtoOut> AddPersonAsync(PersonDtoIn personDtoIn);

        public Task<PagedFilterResultDtoOut<PersonDtoOut>> GetPersonsByFilter(PersonFilterDtoIn filter);

        public Task<PersonDtoOut> UpdatePersonAsync(EditedPersonDtoIn editedPersonDtoIn);

        public Task UpdatePersonsAsync(IEnumerable<EditedPersonDtoIn> editedPersonsDtoIn);

        public Task DeletePersonByFilter(PersonFilterDtoIn filter);
    }
}
