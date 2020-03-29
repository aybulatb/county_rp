using System.Threading.Tasks;
using CountyRP.Extra;

namespace CountyRP.WebSite.Services.Interfaces
{
    public interface IPersonAdapter
    {
        Task<Person> GetById(int id);
        Task<Person> GetByName(string name);
    }
}
