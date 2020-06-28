using System.Threading.Tasks;

using CountyRP.Models;
using CountyRP.WebSite.Models.ViewModels;

namespace CountyRP.WebSite.Services.Interfaces
{
    public interface IFactionAdapter
    {
        Task<Faction> Create(Faction faction);
        Task<Faction> GetById(string id);
        Task<Faction> Edit(string id, Faction faction);
        Task Delete(string id);
        Task<FilteredModels<Faction>> FilterBy(int page, int count, string id, string name);
    }
}
