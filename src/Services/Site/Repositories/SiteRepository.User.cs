using CountyRP.Services.Site.Converters;
using CountyRP.Services.Site.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Site.Repositories
{
    public partial class SiteRepository
    {
        public async Task<UserDtoOut> AddUserAsync(UserDtoIn userDtoIn)
        {
            var userDao = UserDtoInConverter.ToDb(userDtoIn);

            await _siteDbContext.Users.AddAsync(userDao);
            await _siteDbContext.SaveChangesAsync();

            return UserDaoConverter.ToRepository(userDao);
        }

        public async Task<UserDtoOut> GetUserByIdAsync(int id)
        {
            var userDao = await _siteDbContext
                .Users
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Id == id);

            return (userDao != null) 
                ? UserDaoConverter.ToRepository(userDao)
                : null;
        }

        public async Task<UserDtoOut> GetUserByLoginAsync(string login)
        {
            var userDao = await _siteDbContext
                .Users
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Login == login);

            return (userDao != null)
                ? UserDaoConverter.ToRepository(userDao)
                : null;
        }

        public async Task<UserDtoOut> UpdateUserAsync(UserDtoOut userDtoOut)
        {
            var userDao = UserDtoOutConverter.ToDb(userDtoOut);

            var updatedUserDao = _siteDbContext.Users.Update(userDao)?.Entity;
            await _siteDbContext.SaveChangesAsync();

            return (updatedUserDao != null)
                ? UserDaoConverter.ToRepository(updatedUserDao)
                : null;
        }

        public async Task<PagedFilterResult<UserDtoOut>> GetUsersByFilterAsync(UserFilterDtoIn filter)
        {
            var usersQuery = _siteDbContext
                .Users
                .AsNoTracking()
                .Where(
                    user =>
                        (filter.Login == null || user.Login.Contains(filter.Login)) &&
                        (filter.GroupIds == null || filter.GroupIds.Contains(user.GroupId))
                )
                .AsQueryable();

            var allCount = await usersQuery.CountAsync();
            var maxPages = (allCount %  filter.Count == 0)
                ? allCount / filter.Count
                : allCount / filter.Count + 1;

            var filteredUsersDao = await usersQuery
                .Skip(filter.Count * (filter.Page - 1))
                .Take(filter.Count)
                .OrderBy(user => user.Id)
                .ToListAsync();

            return new PagedFilterResult<UserDtoOut>(
                allCount: allCount,
                page: filter.Page,
                maxPages: maxPages,
                items: filteredUsersDao
                    .Select(UserDaoConverter.ToRepository)
            );
        }

        public async Task<UserDtoOut> AuthenticateAsync(string login, string password)
        {
            var userDao = await _siteDbContext
                .Users
                .AsNoTracking()
                .FirstOrDefaultAsync(
                    user => user.Login == login && user.Password == password
                );

            return (userDao != null)
                ? UserDaoConverter.ToRepository(userDao)
                : null;
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _siteDbContext
                .Users
                .FirstAsync(user => user.Id == id);

            _siteDbContext.Users.Remove(user);
            await _siteDbContext.SaveChangesAsync();
        }
    }
}
