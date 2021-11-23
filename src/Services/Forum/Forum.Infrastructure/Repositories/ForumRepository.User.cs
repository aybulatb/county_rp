﻿using CountyRP.Services.Forum.Infrastructure.Converters;
using CountyRP.Services.Forum.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Infrastructure.Repositories
{
    public partial class ForumRepository
    {
        public async Task<UserDtoOut> AddUserAsync(UserDtoIn userDtoIn)
        {
            var userDao = UserDtoInConverter.ToDb(userDtoIn);

            await _forumDbContext.Users.AddAsync(userDao);
            await _forumDbContext.SaveChangesAsync();

            return UserDaoConverter.ToRepository(userDao);
        }

        public async Task<UserDtoOut> GetUserByIdAsync(int id)
        {
            var userDao = await _forumDbContext
                .Users
                .AsNoTracking()
                .AsNoTracking()
                .FirstOrDefaultAsync(users => users.Id.Equals(id));

            return (userDao != null)
                ? UserDaoConverter.ToRepository(userDao)
                : null;
        }

        public async Task<UserDtoOut> GetUserByLoginAsync(string login)
        {
            var userDao = await _forumDbContext
                .Users
                .AsNoTracking()
                .FirstOrDefaultAsync(users => users.Login == login);

            return (userDao != null)
                ? UserDaoConverter.ToRepository(userDao)
                : null;
        }

        public async Task UpdateUserAsync(int id, UserDtoOut userDtoOut)
        {
            var userDao = UserDtoOutConverter.ToDb(userDtoOut);

            _forumDbContext.Users.Update(userDao);
            await _forumDbContext.SaveChangesAsync();
        }

        public async Task<PagedFilterResult<UserDtoOut>> GetUsersByFilterAsync(UserFilterDtoIn filterDtoIn)
        {
            var usersQuery = _forumDbContext
                .Users
                .AsNoTracking()
                .Where(
                    user =>
                        (filterDtoIn.Login == null || user.Login.Contains(filterDtoIn.Login)) &&
                        (filterDtoIn.GroupIds == null || filterDtoIn.GroupIds.Contains(user.GroupId))
                )
                .AsQueryable();

            var allCount = await usersQuery.CountAsync();
            var maxPages = (allCount % filterDtoIn.Count == 0)
                ? allCount / filterDtoIn.Count
                : allCount / filterDtoIn.Count + 1;

            var filteredUsersDao = await usersQuery
                .OrderBy(user => user.Id)
                .Skip(filterDtoIn.Count * (filterDtoIn.Page - 1))
                .Take(filterDtoIn.Count)
                .ToListAsync();

            return new PagedFilterResult<UserDtoOut>(
                allCount: allCount,
                page: filterDtoIn.Page,
                maxPages: maxPages,
                items: filteredUsersDao
                    .Select(UserDaoConverter.ToRepository)
            );
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _forumDbContext
                .Users
                .FirstAsync(user => user.Id == id);

            _forumDbContext.Users.Remove(user);
            await _forumDbContext.SaveChangesAsync();
        }
    }
}
