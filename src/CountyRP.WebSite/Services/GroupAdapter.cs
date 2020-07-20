using System.Linq;
using System.Threading.Tasks;

using CountyRP.Models;
using CountyRP.WebSite.Exceptions;
using CountyRP.WebSite.Models.ViewModels;
using CountyRP.WebSite.Services.Interfaces;

namespace CountyRP.WebSite.Services
{
    public class GroupAdapter : IGroupAdapter
    {
        private Extra.GroupClient _groupClient;

        public GroupAdapter(Extra.GroupClient groupClient)
        {
            _groupClient = groupClient;
        }

        public async Task<Group> Create(Group group)
        {
            var groupExt = MapToExtra(group);

            try
            {
                groupExt = await _groupClient.CreateAsync(groupExt);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return MapToModel(groupExt);
        }

        public async Task<Group> GetById(string id)
        {
            Extra.Group groupExt;

            try
            {
                groupExt = await _groupClient.GetByIdAsync(id);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return MapToModel(groupExt);
        }

        public async Task<FilteredModels<Group>> FilterBy(int page, int count, string id, string name)
        {
            Extra.FilteredModelsOfGroup filteredGroupsExt;

            try
            {
                filteredGroupsExt = await _groupClient.FilterByAsync(page, count, id, name);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return new FilteredModels<Group>
            {
                Items = filteredGroupsExt.Items.Select(g => MapToModel(g)).ToList(),
                AllAmount = filteredGroupsExt.AllAmount,
                Page = filteredGroupsExt.Page,
                MaxPage = filteredGroupsExt.MaxPage
            };
        }

        public async Task<Group> Edit(string id, Group group)
        {
            var groupExt = MapToExtra(group);

            try
            {
                groupExt = await _groupClient.EditAsync(id, groupExt);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return MapToModel(groupExt);
        }

        public async Task Delete(string id)
        {
            try
            {
                await _groupClient.DeleteAsync(id);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }
        }

        private Extra.Group MapToExtra(Group g)
        {
            return new Extra.Group
            {
                Id = g.Id,
                Name = g.Name,
                Color = g.Color,
                AdminPanel = g.AdminPanel
            };
        }

        private Group MapToModel(Extra.Group g)
        {
            return new Group
            {
                Id = g.Id,
                Name = g.Name,
                Color = g.Color,
                AdminPanel = g.AdminPanel
            };
        }
    }
}
