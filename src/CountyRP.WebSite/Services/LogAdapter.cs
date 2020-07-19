using System.Linq;
using System.Threading.Tasks;

using CountyRP.Models;
using CountyRP.WebSite.Exceptions;
using CountyRP.WebSite.Models.ViewModels;
using CountyRP.WebSite.Services.Interfaces;

namespace CountyRP.WebSite.Services
{
    public class LogAdapter : ILogAdapter
    {
        private Extra.LogClient _logClient;

        public LogAdapter(Extra.LogClient logClient)
        {
            _logClient = logClient;
        }

        public async Task<LogUnit> GetById(int id)
        {
            Extra.LogUnit logUnitExt;

            try
            {
                logUnitExt = await _logClient.GetByIdAsync(id);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return MapToModel(logUnitExt);
        }

        public async Task<FilteredModels<LogUnit>> FilterBy(int page, int count)
        {
            Extra.FilteredModelsOfLogUnit filteredLogUnitsExt;

            try
            {
                filteredLogUnitsExt = await _logClient.FilterByAsync(page, count);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return new FilteredModels<LogUnit>
            {
                Items = filteredLogUnitsExt.Items.Select(lu => MapToModel(lu)).ToList(),
                AllAmount = filteredLogUnitsExt.AllAmount,
                Page = filteredLogUnitsExt.Page,
                MaxPage = filteredLogUnitsExt.MaxPage
            };
        }

        public async Task<LogUnit> Create(LogUnit logUnit)
        {
            var logUnitExt = MapToExtra(logUnit);

            try
            {
                logUnitExt = await _logClient.CreateAsync(logUnitExt);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return MapToModel(logUnitExt);
        }

        public async Task<LogUnit> Edit(int id, LogUnit logUnit)
        {
            var logUnitExt = MapToExtra(logUnit);

            try
            {
                logUnitExt = await _logClient.EditAsync(id, logUnitExt);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return MapToModel(logUnitExt);
        }

        public async Task Delete(int id)
        {
            try
            {
                await _logClient.DeleteAsync(id);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }
        }

        private Extra.LogUnit MapToExtra(LogUnit lu)
        {
            return new Extra.LogUnit
            {
                Id = lu.Id,
                DateTime = lu.DateTime,
                Login = lu.Login,
                Ip = lu.IP,
                ActionId = (Extra.LogAction)lu.ActionId,
                Comment = lu.Comment
            };
        }

        private LogUnit MapToModel(Extra.LogUnit lu)
        {
            return new LogUnit
            {
                Id = lu.Id,
                DateTime = lu.DateTime,
                Login = lu.Login,
                IP = lu.Ip,
                ActionId = (LogAction)lu.ActionId,
                Comment = lu.Comment
            };
        }
    }
}
