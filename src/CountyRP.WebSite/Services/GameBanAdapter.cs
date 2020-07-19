using System.Linq;
using System.Threading.Tasks;

using CountyRP.Models;
using CountyRP.WebSite.Exceptions;
using CountyRP.WebSite.Models.ViewModels;
using CountyRP.WebSite.Services.Interfaces;

namespace CountyRP.WebSite.Services
{
    public class GameBanAdapter : IGameBanAdapter
    {
        private Extra.GameBanClient _gameBanClient;

        public GameBanAdapter(Extra.GameBanClient gameBanClient)
        {
            _gameBanClient = gameBanClient;
        }

        public async Task<GameBan> GetById(int id)
        {
            Extra.GameBan gameBanExt;

            try
            {
                gameBanExt = await _gameBanClient.GetByIdAsync(id);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return MapToModel(gameBanExt);
        }

        public async Task<FilteredModels<GameBan>> FilterBy(int page, int count)
        {
            Extra.FilteredModelsOfGameBan filteredGameBansExt;

            try
            {
                filteredGameBansExt = await _gameBanClient.FilterByAsync(page, count);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return new FilteredModels<GameBan>
            {
                Items = filteredGameBansExt.Items.Select(lu => MapToModel(lu)).ToList(),
                AllAmount = filteredGameBansExt.AllAmount,
                Page = filteredGameBansExt.Page,
                MaxPage = filteredGameBansExt.MaxPage
            };
        }

        public async Task<GameBan> Create(GameBan gameBan)
        {
            var gameBanExt = MapToExtra(gameBan);

            try
            {
                gameBanExt = await _gameBanClient.CreateAsync(gameBanExt);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return MapToModel(gameBanExt);
        }

        public async Task<GameBan> Edit(int id, GameBan gameBan)
        {
            var gameBanExt = MapToExtra(gameBan);

            try
            {
                gameBanExt = await _gameBanClient.EditAsync(id, gameBanExt);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return MapToModel(gameBanExt);
        }

        public async Task Delete(int id)
        {
            try
            {
                await _gameBanClient.DeleteAsync(id);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }
        }

        private Extra.GameBan MapToExtra(GameBan gb)
        {
            return new Extra.GameBan
            {
                Id = gb.Id,
                PlayerId = gb.PlayerId,
                PersonId = gb.PersonId,
                AdminId = gb.AdminId,
                StartDateTime = gb.StartDateTime,
                FinishDateTime = gb.FinishDateTime,
                Ip = gb.IP,
                Reason = gb.Reason
            };
        }

        private GameBan MapToModel(Extra.GameBan gb)
        {
            return new GameBan
            {
                Id = gb.Id,
                PlayerId = gb.PlayerId,
                PersonId = gb.PersonId,
                AdminId = gb.AdminId,
                StartDateTime = gb.StartDateTime,
                FinishDateTime = gb.FinishDateTime,
                IP = gb.Ip,
                Reason = gb.Reason
            };
        }
    }
}
