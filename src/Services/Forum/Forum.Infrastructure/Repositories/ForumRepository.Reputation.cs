﻿using CountyRP.Services.Forum.Infrastructure.Converters;
using CountyRP.Services.Forum.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Forum.Infrastructure.Repositories
{
    public partial class ForumRepository
    {
        public async Task<ReputationDtoOut> CreateReputationAsync(ReputationDtoIn reputationDtoIn)
        {
            var reputationDao = ReputationDtoInConverter.ToDb(reputationDtoIn);

            await _forumDbContext.Reputations.AddAsync(reputationDao);
            await _forumDbContext.SaveChangesAsync();

            return ReputationDaoConverter.ToRepository(reputationDao);
        }

        public async Task<PagedFilterResult<ReputationDtoOut>> GetReputationsByFilterAsync(ReputationFilterDtoIn reputationFilterDtoIn)
        {
            var reputationsQuery = _forumDbContext
                .Reputations
                .AsNoTracking()
                .Where(
                    reputation => reputation.UserId.Equals(reputationFilterDtoIn.UserId)
                )
                .AsQueryable();

            var allCount = await reputationsQuery.CountAsync();
            var maxPages = (allCount % reputationFilterDtoIn.Count == 0)
                ? allCount / reputationFilterDtoIn.Count
                : allCount / reputationFilterDtoIn.Count + 1;

            var filteredReputationsDao = await reputationsQuery
                .OrderByDescending(reputation => reputation.DateTime)
                .Skip(reputationFilterDtoIn.Count.Value * (reputationFilterDtoIn.Page.Value - 1))
                .Take(reputationFilterDtoIn.Count.Value)
                .ToListAsync();

            return new PagedFilterResult<ReputationDtoOut>(
                allCount: allCount,
                page: reputationFilterDtoIn.Page ?? 1,
                maxPages: maxPages.Value,
                items: filteredReputationsDao
                    .Select(ReputationDaoConverter.ToRepository)
            );
        }

        public async Task DeleteReputationAsync(int id)
        {
            var reputation = await _forumDbContext
                .Reputations
                .FirstAsync(r => r.Id.Equals(id));

            _forumDbContext.Reputations.Remove(reputation);
            await _forumDbContext.SaveChangesAsync();
        }

        public async Task DeleteReputationsOnUserByIdAsync(int userId)
        {
            var affectedReputations = _forumDbContext
                .Reputations
                .Select(reputation => reputation)
                .Where(r => r.UserId == userId)
                .ToArray();

            _forumDbContext.Reputations.RemoveRange(affectedReputations);
            await _forumDbContext.SaveChangesAsync();
        }
    }
}
