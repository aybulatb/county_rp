using CountyRP.Services.Site.Converters;
using CountyRP.Services.Site.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Site.Repositories
{
    public partial class SiteRepository
    {
        public async Task<GroupDtoOut> AddGroupAsync(GroupDtoIn groupDtoIn)
        {
            var groupDao = GroupDtoInConverter.ToDb(groupDtoIn);

            await _siteDbContext.Groups.AddAsync(groupDao);
            await _siteDbContext.SaveChangesAsync();

            return GroupDaoConverter.ToRepository(groupDao);
        }

        public async Task<GroupDtoOut> GetGroupAsync(string id)
        {
            var groupDao = await _siteDbContext
                .Groups
                .AsNoTracking()
                .FirstOrDefaultAsync(group => group.Id == id);

            return (groupDao != null)
                ? GroupDaoConverter.ToRepository(groupDao)
                : null;
        }

        public async Task<PagedFilterResult<GroupDtoOut>> GetGroupsByFilterAsync(GroupFilterDtoIn filter)
        {
            var groupsQuery = _siteDbContext
                .Groups
                .AsNoTracking()
                .Where(
                    group =>
                        filter.Name == null || group.Name == filter.Name
                )
                .AsQueryable();

            var allCount = await groupsQuery.CountAsync();
            var maxPages = allCount / filter.Count;

            var filteredGroupsDao = await groupsQuery
                .Skip(filter.Count * (filter.Page - 1))
                .Take(filter.Count)
                .ToListAsync();

            return new PagedFilterResult<GroupDtoOut>(
                allCount: allCount,
                page: filter.Page,
                maxPages: maxPages,
                items: filteredGroupsDao
                    .Select(GroupDaoConverter.ToRepository)
            );
        }

        public async Task<GroupDtoOut> UpdateGroupAsync(GroupDtoOut groupDtoOut)
        {
            var groupDao = GroupDtoOutConverter.ToDb(groupDtoOut);

            groupDao = _siteDbContext.Groups.Update(groupDao)?.Entity;
            await _siteDbContext.SaveChangesAsync();

            return GroupDaoConverter.ToRepository(groupDao);
        }

        public async Task DeleteGroupAsync(string id)
        {
            var groupDao = await _siteDbContext
                .Groups
                .FirstAsync(group => group.Id == id);

            _siteDbContext.Remove(groupDao);
            await _siteDbContext.SaveChangesAsync();
        }
    }
}
