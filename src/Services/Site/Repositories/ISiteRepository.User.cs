using CountyRP.Services.Site.Models;
using System.Threading.Tasks;

namespace CountyRP.Services.Site.Repositories
{
    public partial interface ISiteRepository
    {
        public Task<UserDtoOut> AddUserAsync(UserDtoIn userDtoIn);

        public Task<UserDtoOut> UpdateUserAsync(UserDtoOut userDtoOut);

        public Task<UserDtoOut> GetUserByIdAsync(int id);

        public Task<UserDtoOut> GetUserByLoginAsync(string login);

        public Task<PagedFilterResult<UserDtoOut>> GetUsersByFilterAsync(UserFilterDtoIn filter);

        public Task<UserDtoOut> AuthenticateAsync(string login, string password);

        public Task DeleteUserAsync(int id);
    }
}
