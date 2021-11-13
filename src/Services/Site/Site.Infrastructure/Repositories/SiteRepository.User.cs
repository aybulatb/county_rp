using CountyRP.Services.Site.Infrastructure.Converters;
using CountyRP.Services.Site.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Site.Infrastructure.Repositories
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
                        (filter.Ids == null || filter.Ids.Contains(user.Id)) &&
                        (filter.Login == null || user.Login == filter.Login) &&
                        (filter.LoginLike == null || user.Login.Contains(filter.LoginLike)) &&
                        (filter.GroupIds == null || filter.GroupIds.Contains(user.GroupId)) &&
                        (filter.PlayerIds == null || filter.PlayerIds.Contains(user.PlayerId)) &&
                        (filter.StartRegistrationDate == null || user.RegistrationDate > filter.StartRegistrationDate) &&
                        (filter.FinishRegistrationDate == null || user.RegistrationDate < filter.FinishRegistrationDate) &&
                        (filter.StartLastVisitDate == null || user.LastVisitDate > filter.StartLastVisitDate) &&
                        (filter.FinishLastVisitDate == null || user.LastVisitDate < filter.FinishLastVisitDate)
                )
                .AsQueryable();

            var allCount = await usersQuery.CountAsync();
            var maxPages = filter.Count.HasValue && filter.Count.Value != 0
                ?
                    (allCount % filter.Count.Value == 0)
                        ? allCount / filter.Count.Value
                        : allCount / filter.Count.Value + 1
                : 1;

            usersQuery = usersQuery
                .OrderBy(user => user.Id);

            if (filter.Count.HasValue && filter.Page.HasValue && filter.Count.Value > 0 && filter.Page.Value > 0)
            {
                usersQuery = usersQuery
                    .Skip(filter.Count.Value * (filter.Page.Value - 1))
                    .Take(filter.Count.Value);
            }

            var filteredUsersDao = await usersQuery
                .ToListAsync();

            return new PagedFilterResult<UserDtoOut>(
                AllCount: allCount,
                Page: filter.Page.HasValue
                    ? filter.Page.Value
                    : 1,
                MaxPages: maxPages,
                Items: filteredUsersDao
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
