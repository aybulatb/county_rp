using System.Threading.Tasks;

using CountyRP.Extra;
using CountyRP.WebSite.Services.Interfaces;
using CountyRP.WebSite.Exceptions;

namespace CountyRP.WebSite.Services
{
    public class AllPlayerAdapter : IAllPlayerAdapter
    {
        private AllPlayerClient _allPlayerClient;

        public AllPlayerAdapter(AllPlayerClient allPlayerClient)
        {
            _allPlayerClient = allPlayerClient;
        }

        public async Task<AllPlayer> GetByLogin(string login)
        {
            AllPlayer allPlayer;

            try
            {
                allPlayer = await _allPlayerClient.GetByLoginAsync(login);
            }
            catch (ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return allPlayer;
        }
    }
}
