using System.Threading.Tasks;

using CountyRP.Models;
using CountyRP.WebSite.Models.ViewModels;

namespace CountyRP.WebSite.Services.Interfaces
{
    public interface ILogAdapter
    {
        Task<LogUnit> GetById(int id);
        Task<FilteredModels<LogUnit>> FilterBy(int page, int count, string login, string ip, int actionId, string commentPart);
        Task<LogUnit> Create(LogUnit logUnit);
        Task<LogUnit> Edit(int id, LogUnit logUnit);
        Task Delete(int id);
    }
}
