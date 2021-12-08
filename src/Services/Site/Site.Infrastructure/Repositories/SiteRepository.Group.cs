using CountyRP.Services.Site.Infrastructure.Converters;
using CountyRP.Services.Site.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Site.Infrastructure.Repositories
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

        public async Task<GroupDtoOut> GetGroupAsync(int id)
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
                        (filter.Ids == null || filter.Ids.Contains(group.Id)) &&
                        (filter.Name == null || group.Name == filter.Name)
                );

            var allCount = await groupsQuery.CountAsync();
            var maxPages = filter.Count.HasValue && filter.Count.Value != 0
                ?
                    (allCount % filter.Count.Value == 0)
                        ? allCount / filter.Count.Value
                        : allCount / filter.Count.Value + 1
                : 1;

            groupsQuery = groupsQuery
                .OrderBy(group => group.Id);

            if (filter.Count.HasValue && filter.Page.HasValue && filter.Count.Value > 0 && filter.Page.Value > 0)
            {
                groupsQuery = groupsQuery
                    .Skip(filter.Count.Value * (filter.Page.Value - 1))
                    .Take(filter.Count.Value);
            }

            var filteredGroupsDao = await groupsQuery
                .ToListAsync();

            return new PagedFilterResult<GroupDtoOut>(
                AllCount: allCount,
                Page: filter.Page.HasValue
                    ? filter.Page.Value
                    : 1,
                MaxPages: maxPages,
                Items: filteredGroupsDao
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

        public async Task DeleteGroupAsync(int id)
        {
            var groupDao = await _siteDbContext
                .Groups
                .FirstAsync(group => group.Id == id);

            _siteDbContext.Remove(groupDao);
            await _siteDbContext.SaveChangesAsync();
        }
    }
}
