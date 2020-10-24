using System.Threading.Tasks;

using CountyRP.Models;
using CountyRP.WebSite.Models.ViewModels;

namespace CountyRP.WebSite.Services.Interfaces
{
    public interface ISiteBanAdapter
    {
        Task<SiteBan> GetById(int id);
        Task<FilteredModels<SiteBan>> FilterBy(int page, int count);
        Task<SiteBan> Create(SiteBan siteBan);
        Task<SiteBan> Edit(int id, SiteBan siteBan);
        Task Delete(int id);
    }
}
