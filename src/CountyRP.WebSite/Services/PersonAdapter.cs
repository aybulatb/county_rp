using System.Linq;
using System.Threading.Tasks;

using CountyRP.Models;
using CountyRP.WebSite.Exceptions;
using CountyRP.WebSite.Models.ViewModels;
using CountyRP.WebSite.Services.Interfaces;

namespace CountyRP.WebSite.Services
{
    public class PersonAdapter : IPersonAdapter
    {
        private Extra.PersonClient _personClient;

        public PersonAdapter(Extra.PersonClient personClient)
        {
            _personClient = personClient;
        }

        public async Task<Person> GetById(int id)
        {
            Extra.Person personExt;

            try
            {
                personExt = await _personClient.GetByIdAsync(id);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return new Person
            {
                Id = personExt.Id,
                Name = personExt.Name,
                PlayerId = personExt.PlayerId,
                RegDate = personExt.RegDate,
                LastDate = personExt.LastDate,
                AdminLevelId = personExt.AdminLevelId,
                FactionId = personExt.FactionId,
                GroupId = personExt.GroupId,
                Leader = personExt.Leader,
                Rank = personExt.Rank,
                Position = personExt.Position.ToArray()
            };
        }

        public async Task<Person> GetByName(string name)
        {
            Extra.Person personExt;

            try
            {
                personExt = await _personClient.GetByNameAsync(name);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return new Person
            {
                Id = personExt.Id,
                Name = personExt.Name,
                PlayerId = personExt.PlayerId,
                RegDate = personExt.RegDate,
                LastDate = personExt.LastDate,
                AdminLevelId = personExt.AdminLevelId,
                FactionId = personExt.FactionId,
                GroupId = personExt.GroupId,
                Leader = personExt.Leader,
                Rank = personExt.Rank,
                Position = personExt.Position.ToArray()
            };
        }

        public async Task<Person> Edit(int id, Person person)
        {
            var personExt = new Extra.Person
            {
                Id = person.Id,
                Name = person.Name,
                PlayerId = person.PlayerId,
                RegDate = person.RegDate,
                LastDate = person.LastDate,
                AdminLevelId = person.AdminLevelId,
                FactionId = person.FactionId,
                GroupId = person.GroupId,
                Leader = person.Leader,
                Rank = person.Rank,
                Position = person.Position.ToArray()
            };

            try
            {
                personExt = await _personClient.UpdateAsync(id, personExt);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return new Person
            {
                Id = personExt.Id,
                Name = personExt.Name,
                PlayerId = personExt.PlayerId,
                RegDate = personExt.RegDate,
                LastDate = personExt.LastDate,
                AdminLevelId = personExt.AdminLevelId,
                FactionId = personExt.FactionId,
                GroupId = personExt.GroupId,
                Leader = personExt.Leader,
                Rank = personExt.Rank,
                Position = personExt.Position.ToArray()
            };
        }

        public async Task<FilteredModels<Person>> FilterBy(int page, int count, string name)
        {
            Extra.FilteredModelsOfPerson filteredPersonsExt;

            try
            {
                filteredPersonsExt = await _personClient.FilterByAsync(page, count, name);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return new FilteredModels<Person>
            {
                Items = filteredPersonsExt.Items.Select(p => new Person
                {
                    Id = p.Id,
                    Name = p.Name,
                    PlayerId = p.PlayerId,
                    RegDate = p.RegDate,
                    LastDate = p.LastDate,
                    AdminLevelId = p.AdminLevelId,
                    FactionId = p.FactionId,
                    GroupId = p.GroupId,
                    Leader = p.Leader,
                    Rank = p.Rank,
                    Position = p.Position.ToArray()
                }).ToList(),
                AllAmount = filteredPersonsExt.AllAmount,
                Page = filteredPersonsExt.Page,
                MaxPage = filteredPersonsExt.MaxPage
            };
        }
    }
}
