using System.Threading.Tasks;

using CountyRP.Models;
using CountyRP.WebSite.Models.ViewModels;

namespace CountyRP.WebSite.Services.Interfaces
{
    public interface IGroupAdapter
    {
        Task Create(Group group);
        Task<Group> GetById(string id);
        Task<FilteredGroups> FilterBy(int page, int count, string id, string name);
        Task<Group> Edit(string id, Group group);
        Task Delete(string id);
    }
}
