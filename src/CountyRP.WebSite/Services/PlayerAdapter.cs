using System.Threading.Tasks;

using CountyRP.Models;
using CountyRP.WebSite.Exceptions;
using CountyRP.WebSite.Services.Interfaces;

namespace CountyRP.WebSite.Services
{
    public class PlayerAdapter : IPlayerAdapter
    {
        private Extra.PlayerClient _playerClient;

        public PlayerAdapter(Extra.PlayerClient playerClient)
        {
            _playerClient = playerClient;
        }

        public async Task<Player> Register(Player player)
        {
            Extra.Player playerExt = new Extra.Player
            {
                Login = player.Login,
                Password = player.Password,
                GroupId = player.GroupId
            };

            try
            {
                playerExt = await _playerClient.RegisterAsync(playerExt);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            player.Id = playerExt.Id;
            player.Login = playerExt.Login;
            player.Password = playerExt.Password;
            player.GroupId = playerExt.GroupId;

            return player;
        }

        public async Task<Player> TryAuthorize(string login, string password)
        {
            Extra.Player playerExt;

            try
            {
                playerExt = await _playerClient.TryAuthorizeAsync(login, password);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return new Player
            {
                Id = playerExt.Id,
                Login = playerExt.Login,
                Password = playerExt.Password,
                GroupId = playerExt.GroupId
            };
        }

        public async Task<Player> GetById(int id)
        {
            Extra.Player playerExt;

            try
            {
                playerExt = await _playerClient.GetByIdAsync(id);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return new Player
            {
                Id = playerExt.Id,
                Login = playerExt.Login,
                Password = playerExt.Password,
                GroupId = playerExt.GroupId
            };
        }

        public async Task<Player> GetByLogin(string login)
        {
            Extra.Player playerExt;

            try
            {
                playerExt = await _playerClient.GetByLoginAsync(login);
            }
            catch (Extra.ApiException<string> ex)
            {
                throw new AdapterException(ex.StatusCode, ex.Result);
            }

            return new Player
            {
                Id = playerExt.Id,
                Login = playerExt.Login,
                Password = playerExt.Password,
                GroupId = playerExt.GroupId
            };
        }
    }
}
