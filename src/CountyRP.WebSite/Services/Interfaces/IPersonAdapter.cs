using System.Threading.Tasks;

using CountyRP.Models;
using CountyRP.WebSite.Models.ViewModels;

namespace CountyRP.WebSite.Services.Interfaces
{
    public interface IPersonAdapter
    {
        Task<Person> GetById(int id);
        Task<Person> GetByName(string name);
        Task<Person> Edit(int id, Person person);
        Task<FilteredModels<Person>> FilterBy(int page, int count, string name);
    }
}
