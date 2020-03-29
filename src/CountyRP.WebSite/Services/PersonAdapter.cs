using System.Threading.Tasks;
using CountyRP.Extra;
using CountyRP.WebSite.Exceptions;
using CountyRP.WebSite.Services.Interfaces;

namespace CountyRP.WebSite.Services
{
    public class PersonAdapter : IPersonAdapter
    {
        private PersonClient _personClient;

        public PersonAdapter(PersonClient personClient)
        {
            _personClient = personClient;
        }

        public async Task<Person> GetById(int id)
        {
            Person person;

            try
            {
                person = await _personClient.GetByIdAsync(id);
            }
            catch (ApiException ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Message);
            }

            return person;
        }

        public async Task<Person> GetByName(string name)
        {
            Person person;

            try
            {
                person = await _personClient.GetByNameAsync(name);
            }
            catch (ApiException ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Message);
            }

            return person;
        }
    }
}
