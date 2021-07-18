using CountyRP.Services.Game.Infrastructure.Converters;
using CountyRP.Services.Game.Infrastructure.Entities;
using CountyRP.Services.Game.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.Infrastructure.Repositories
{
    public partial class GameRepository
    {
        public async Task<VehicleDtoOut> AddVehicleAsync(VehicleDtoIn vehicleDtoIn)
        {
            var vehicleDao = VehicleDtoInConverter.ToDb(vehicleDtoIn);

            await _gameDbContext.Vehicles.AddAsync(vehicleDao);

            await _gameDbContext.SaveChangesAsync();

            return VehicleDaoConverter.ToRepository(vehicleDao);
        }

        public async Task<PagedFilterResultDtoOut<VehicleDtoOut>> GetVehiclesByFilter(VehicleFilterDtoIn filter)
        {
            var query = GetVehiclesQuery(filter)
                .AsNoTracking();

            var allCount = await query.CountAsync();
            var maxPages = filter.Count.HasValue && filter.Count.Value != 0
                ?
                    (allCount % filter.Count.Value == 0)
                        ? allCount / filter.Count.Value
                        : allCount / filter.Count.Value + 1
                : 1;

            query = GetVehiclesQueryWithPaging(query, filter);

            var filteredVehicles = await query
                .AsNoTracking()
                .ToListAsync();

            return new PagedFilterResultDtoOut<VehicleDtoOut>(
                allCount: allCount,
                page: filter.Page ?? 1,
                maxPages: maxPages,
                items: filteredVehicles
                    .Select(VehicleDaoConverter.ToRepository)
                );
        }

        public async Task<VehicleDtoOut> UpdateVehicleAsync(VehicleDtoOut vehicleDtoOut)
        {
            var existedVehicleDao = await _gameDbContext
                .Vehicles
                .AsNoTracking()
                .FirstAsync(vehicle => vehicle.Id == vehicleDtoOut.Id);

            var editedVehicleDao = VehicleDtoOutConverter.ToDb(
                source: vehicleDtoOut
            );

            var vehicleDao = _gameDbContext.Vehicles.Update(editedVehicleDao)?.Entity;

            await _gameDbContext.SaveChangesAsync();

            return VehicleDaoConverter.ToRepository(vehicleDao);
        }

        public async Task DeleteVehicleByFilter(VehicleFilterDtoIn filter)
        {
            var query = GetVehiclesQuery(filter)
                .AsNoTracking();

            query = GetVehiclesQueryWithPaging(query, filter);

            _gameDbContext
                .Vehicles
                .RemoveRange(query);

            await _gameDbContext.SaveChangesAsync();
        }

        private IQueryable<VehicleDao> GetVehiclesQuery(VehicleFilterDtoIn filter)
        {
            return _gameDbContext
               .Vehicles
               .Where(
                   vehicle =>
                       (filter.Ids == null || filter.Ids.Contains(vehicle.Id)) &&
                       (filter.Models == null || filter.Models.Contains(vehicle.Model)) &&
                       (filter.OwnerIds == null || filter.OwnerIds.Contains(vehicle.OwnerId)) &&
                       (filter.FactionIds == null || filter.FactionIds.Contains(vehicle.FactionId)) &&
                       (filter.LicensePlate == null || filter.LicensePlate == vehicle.LicensePlate) &&
                       (filter.LicensePlateLike == null || vehicle.LicensePlate.Contains(filter.LicensePlateLike))
               )
               .OrderBy(vehicle => vehicle.Id);
        }

        private IQueryable<VehicleDao> GetVehiclesQueryWithPaging(IQueryable<VehicleDao> query, VehicleFilterDtoIn filter)
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
