using CountyRP.Services.Game.Infrastructure.Converters;
using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.Infrastructure.Repositories
{
    public partial class GameRepository
    {
        public async Task<BusinessDtoOut> AddBusinessAsync(BusinessDtoIn businessDtoIn)
        {
            var businessDao = BusinessDtoInConverter.ToDb(businessDtoIn);

            await _gameDbContext.Businesses.AddAsync(businessDao);

            await _gameDbContext.SaveChangesAsync();

            return BusinessDaoConverter.ToRepository(businessDao);
        }

        public async Task<PagedFilterResultDtoOut<BusinessDtoOut>> GetBusinesssByFilter(BusinessFilterDtoIn filter)
        {
            var query = GetBusinesssQuery(filter)
                .AsNoTracking();

            var allCount = await query.CountAsync();
            var maxPages = filter.Count.HasValue && filter.Count.Value != 0
                ?
                    (allCount % filter.Count.Value == 0)
                        ? allCount / filter.Count.Value
                        : allCount / filter.Count.Value + 1
                : 1;

            query = GetBusinesssQueryWithPaging(query, filter);

            var filteredBusinesss = await query
                .AsNoTracking()
                .ToListAsync();

            return new PagedFilterResultDtoOut<BusinessDtoOut>(
                allCount: allCount,
                page: filter.Page ?? 1,
                maxPages: maxPages,
                items: filteredBusinesss
                    .Select(BusinessDaoConverter.ToRepository)
                );
        }

        public async Task<BusinessDtoOut> UpdateBusinessAsync(BusinessDtoOut businessDtoOut)
        {
            var existedBusinessDao = await _gameDbContext
                .Businesses
                .AsNoTracking()
                .FirstAsync(business => business.Id == businessDtoOut.Id);

            var editedBusinessDao = BusinessDtoOutConverter.ToDb(
                source: businessDtoOut
            );

            var businessDao = _gameDbContext.Businesses.Update(editedBusinessDao)?.Entity;

            await _gameDbContext.SaveChangesAsync();

            return BusinessDaoConverter.ToRepository(businessDao);
        }

        public async Task DeleteBusinessByFilter(BusinessFilterDtoIn filter)
        {
            var query = GetBusinesssQuery(filter)
                .AsNoTracking();

            query = GetBusinesssQueryWithPaging(query, filter);

            _gameDbContext
                .Businesses
                .RemoveRange(query);

            await _gameDbContext.SaveChangesAsync();
        }

        private IQueryable<BusinessDao> GetBusinesssQuery(BusinessFilterDtoIn filter)
        {
            IEnumerable<BusinessTypeDao> types = null;
            if (filter.Types != null)
            {
                filter.Types
                    .Select(BusinessTypeDtoConverter.ToDb);
            }

            return _gameDbContext
               .Businesses
               .Where(
                   business =>
                       (filter.Ids == null || filter.Ids.Contains(business.Id)) &&
                       (filter.Name == null || filter.Name == business.Name) &&
                       (filter.NameLike == null || business.Name.Contains(filter.NameLike)) &&
                       (filter.OwnerIds == null || filter.OwnerIds.Contains(business.OwnerId)) &&
                       (types == null || types.Contains(business.Type))
               )
               .OrderBy(business => business.Id);
        }

        private IQueryable<BusinessDao> GetBusinesssQueryWithPaging(IQueryable<BusinessDao> query, BusinessFilterDtoIn filter)
        {
            if (filter.Page.HasValue && filter.Count.HasValue && filter.Count.Value > 0 && filter.Page.Value > 0)
            {
                query = query
                   .Skip((filter.Page.Value - 1) * filter.Count.Value)
                   .Take(filter.Count.Value);
            }

            return query;
        }
    }
}
