using System.Threading.Tasks;

using CountyRP.Models;
using CountyRP.WebSite.Models.ViewModels;

namespace CountyRP.WebSite.Services.Interfaces
{
    public interface IAdminLevelAdapter
    {
        Task<AdminLevel> Create(AdminLevel adminLevel);
        Task<AdminLevel> GetById(string id);
        Task<FilteredModels<AdminLevel>> FilterBy(int page, int count, string id, string name);
        Task<AdminLevel> Edit(string id, AdminLevel adminLevel);
        Task Delete(string id);
    }
}
