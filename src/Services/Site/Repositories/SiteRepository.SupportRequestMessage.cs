using CountyRP.Services.Site.Converters;
using CountyRP.Services.Site.Entities;
using CountyRP.Services.Site.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Site.Repositories
{
    public partial class SiteRepository
    {
        public async Task<SupportRequestMessageDtoOut> AddSupportRequestMessageAsync(SupportRequestMessageDtoIn supportRequestMessageDtoIn)
        {
            var supportRequestMessageDao = SupportRequestMessageDtoInConverter.ToDb(
                source: supportRequestMessageDtoIn
            );

            supportRequestMessageDao = (await _siteDbContext
                    .SupportRequestMessages
                    .AddAsync(supportRequestMessageDao)
                )
                .Entity;

            await _siteDbContext.SaveChangesAsync();

            return SupportRequestMessageDaoConverter.ToRepository(
                source: supportRequestMessageDao
            );
        }

        public async Task<PagedFilterResult<SupportRequestMessageDtoOut>> GetSupportRequestMessagesByFilterAsync(SupportRequestMessageFilterDtoIn filter)
        {
            var query = GetSupportRequestMessageQuery(filter);

            var allCount = await query.CountAsync();
            var maxPages = (allCount % filter.Count == 0)
                ? allCount / filter.Count
                : allCount / filter.Count + 1;

            query = GetSupportRequestMessageQueryWithPaging(filter, query);

            var filteredSupportRequestMessages = await query
                .AsNoTracking()
                .ToListAsync();

            return new PagedFilterResult<SupportRequestMessageDtoOut>(
                allCount: allCount,
                page: filter.Page,
                maxPages: maxPages,
                items: filteredSupportRequestMessages
                    .Select(SupportRequestMessageDaoConverter.ToRepository)
                );
        }

        public async Task<SupportRequestMessageDtoOut> UpdateSupportRequestMessageAsync(SupportRequestMessageDtoOut supportRequestMessageDtoOut)
        {
            var supportRequestMessageDao = SupportRequestMessageDtoOutConverter.ToDb(supportRequestMessageDtoOut);

            supportRequestMessageDao = _siteDbContext
                .SupportRequestMessages
                .Update(supportRequestMessageDao)
                ?.Entity;

            await _siteDbContext.SaveChangesAsync();

            return SupportRequestMessageDaoConverter.ToRepository(supportRequestMessageDao);
        }

        public async Task DeleteSupportRequestMessagesAsync(SupportRequestMessageFilterDtoIn filter)
        {
            var query = GetSupportRequestMessageQuery(filter);

            query = GetSupportRequestMessageQueryWithPaging(filter, query);

            _siteDbContext
                .SupportRequestMessages
                .RemoveRange(query);

            await _siteDbContext.SaveChangesAsync();
        }

        private IQueryable<SupportRequestMessageDao> GetSupportRequestMessageQuery(
            SupportRequestMessageFilterDtoIn filter
        )
        {
            var query = _siteDbContext
                .SupportRequestMessages
                .Where(
                    supportRequestMessage =>
                        (filter.Ids == null || filter.Ids.Contains(supportRequestMessage.Id)) &&
                        (!filter.TopicId.HasValue || supportRequestMessage.TopicId == filter.TopicId.Value) &&
                        (!filter.UserId.HasValue || supportRequestMessage.UserId == filter.UserId.Value)
                    )
                .OrderBy(supportRequestMessage => supportRequestMessage.CreationDate);

            return query;
        }

        private IQueryable<SupportRequestMessageDao> GetSupportRequestMessageQueryWithPaging(
            SupportRequestMessageFilterDtoIn filter,
            IQueryable<SupportRequestMessageDao> query
        )
        {
            var queryWithPaging = query
                .Skip((filter.Page - 1) * filter.Count)
                .Take(filter.Count);

            return queryWithPaging;
        }
    }
}
