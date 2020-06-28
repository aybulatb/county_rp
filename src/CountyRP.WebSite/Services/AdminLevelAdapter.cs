using System.Linq;
using System.Threading.Tasks;

using CountyRP.Models;
using CountyRP.WebSite.Exceptions;
using CountyRP.WebSite.Models.ViewModels;
using CountyRP.WebSite.Services.Interfaces;

namespace CountyRP.WebSite.Services
{
    public class AdminLevelAdapter : IAdminLevelAdapter
    {
        private Extra.AdminLevelClient _adminLevelClient;

        public AdminLevelAdapter(Extra.AdminLevelClient adminLevelClient)
        {
            _adminLevelClient = adminLevelClient;
        }

        public async Task<AdminLevel> Create(AdminLevel adminLevel)
        {
            var adminLevelExt = new Extra.AdminLevel
            {
                Id = adminLevel.Id,
                Name = adminLevel.Name,
                Ban = adminLevel.Ban
            };

            try
            {
                adminLevelExt = await _adminLevelClient.CreateAsync(adminLevelExt);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return new AdminLevel
            {
                Id = adminLevelExt.Id,
                Name = adminLevelExt.Name,
                Ban = adminLevelExt.Ban
            };
        }

        public async Task<AdminLevel> GetById(string id)
        {
            Extra.AdminLevel adminLevelExt;

            try
            {
                adminLevelExt = await _adminLevelClient.GetAsync(id);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return new AdminLevel
            {
                Id = adminLevelExt.Id,
                Name = adminLevelExt.Name,
                Ban = adminLevelExt.Ban
            };
        }

        public async Task<FilteredModels<AdminLevel>> FilterBy(int page, int count, string id, string name)
        {
            Extra.FilteredModelsOfAdminLevel filteredAdminLevelsExt;

            try
            {
                filteredAdminLevelsExt = await _adminLevelClient.FilterByAsync(page, count, id, name);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return new FilteredModels<AdminLevel>
            {
                Items = filteredAdminLevelsExt.Items.Select(al => new AdminLevel
                {
                    Id = al.Id,
                    Name = al.Name,
                    Ban = al.Ban
                }).ToList(),
                AllAmount = filteredAdminLevelsExt.AllAmount,
                Page = filteredAdminLevelsExt.Page,
                MaxPage = filteredAdminLevelsExt.MaxPage
            };
        }

        public async Task<AdminLevel> Edit(string id, AdminLevel adminLevel)
        {
            var adminLevelExt = new Extra.AdminLevel
            {
                Id = adminLevel.Id,
                Name = adminLevel.Name,
                Ban = adminLevel.Ban
            };

            try
            {
                adminLevelExt = await _adminLevelClient.EditAsync(id, adminLevelExt);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return new AdminLevel
            {
                Id = adminLevelExt.Id,
                Name = adminLevelExt.Name,
                Ban = adminLevelExt.Ban
            };
        }

        public async Task Delete(string id)
        {
            try
            {
                await _adminLevelClient.DeleteAsync(id);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }
        }
    }
}
