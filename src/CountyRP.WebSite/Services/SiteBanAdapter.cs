using System.Linq;
using System.Threading.Tasks;

using CountyRP.Models;
using CountyRP.WebSite.Exceptions;
using CountyRP.WebSite.Models.ViewModels;
using CountyRP.WebSite.Services.Interfaces;

namespace CountyRP.WebSite.Services
{
    public class SiteBanAdapter : ISiteBanAdapter
    {
        private Extra.SiteBanClient _siteBanClient;

        public SiteBanAdapter(Extra.SiteBanClient siteBanClient)
        {
            _siteBanClient = siteBanClient;
        }

        public async Task<SiteBan> GetById(int id)
        {
            Extra.SiteBan siteBanExt;

            try
            {
                siteBanExt = await _siteBanClient.GetByIdAsync(id);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return MapToModel(siteBanExt);
        }

        public async Task<FilteredModels<SiteBan>> FilterBy(int page, int count)
        {
            Extra.FilteredModelsOfSiteBan filteredSiteBansExt;

            try
            {
                filteredSiteBansExt = await _siteBanClient.FilterByAsync(page, count);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return new FilteredModels<SiteBan>
            {
                Items = filteredSiteBansExt.Items.Select(lu => MapToModel(lu)).ToList(),
                AllAmount = filteredSiteBansExt.AllAmount,
                Page = filteredSiteBansExt.Page,
                MaxPage = filteredSiteBansExt.MaxPage
            };
        }

        public async Task<SiteBan> Create(SiteBan siteBan)
        {
            var siteBanExt = MapToExtra(siteBan);

            try
            {
                siteBanExt = await _siteBanClient.CreateAsync(siteBanExt);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return MapToModel(siteBanExt);
        }

        public async Task<SiteBan> Edit(int id, SiteBan siteBan)
        {
            var siteBanExt = MapToExtra(siteBan);

            try
            {
                siteBanExt = await _siteBanClient.EditAsync(id, siteBanExt);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return MapToModel(siteBanExt);
        }

        public async Task Delete(int id)
        {
            try
            {
                await _siteBanClient.DeleteAsync(id);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }
        }

        private Extra.SiteBan MapToExtra(SiteBan sb)
        {
            return new Extra.SiteBan
            {
                Id = sb.Id,
                PlayerId = sb.PlayerId,
                AdminId = sb.AdminId,
                StartDateTime = sb.StartDateTime,
                FinishDateTime = sb.FinishDateTime,
                Ip = sb.IP,
                Reason = sb.Reason
            };
        }

        private SiteBan MapToModel(Extra.SiteBan sb)
        {
            return new SiteBan
            {
                Id = sb.Id,
                PlayerId = sb.PlayerId,
                AdminId = sb.AdminId,
                StartDateTime = sb.StartDateTime,
                FinishDateTime = sb.FinishDateTime,
                IP = sb.Ip,
                Reason = sb.Reason
            };
        }
    }
}
