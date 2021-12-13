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
        public async Task<PersonDtoOut> AddPersonAsync(PersonDtoIn personDtoIn)
        {
            var personDao = PersonDtoInConverter.ToDb(personDtoIn);

            await _gameDbContext.Persons.AddAsync(personDao);

            await _gameDbContext.SaveChangesAsync();

            return PersonDaoConverter.ToRepository(personDao);
        }

        public async Task<PagedFilterResultDtoOut<PersonDtoOut>> GetPersonsByFilter(PersonFilterDtoIn filter)
        {
            var query = GetPersonsQuery(filter)
                .AsNoTracking();

            var allCount = await query.CountAsync();
            var maxPages = filter.Count.HasValue && filter.Count != 0
                ?
                    (allCount % filter.Count.Value == 0)
                        ? allCount / filter.Count.Value
                        : allCount / filter.Count.Value + 1
                : 1;

            query = GetPersonsQueryWithPaging(query, filter);

            var filteredPersons = await query
                .ToListAsync();

            return new PagedFilterResultDtoOut<PersonDtoOut>(
                allCount: allCount,
                page: filter.Page ?? 1,
                maxPages: maxPages,
                items: filteredPersons
                    .Select(PersonDaoConverter.ToRepository)
            );
        }

        public async Task<PersonDtoOut> UpdatePersonAsync(EditedPersonDtoIn editedPersonDtoIn)
        {
            var existedPersonDao = await _gameDbContext
                .Persons
                .AsNoTracking()
                .FirstAsync(person => person.Id == editedPersonDtoIn.Id);

            var editedPersonDao = EditedPersonDtoInConverter.ToDb(
                source: editedPersonDtoIn,
                personDtoOut: PersonDaoConverter.ToRepository(existedPersonDao)
            );

            var personDao = _gameDbContext.Persons.Update(editedPersonDao)?.Entity;

            await _gameDbContext.SaveChangesAsync();

            return PersonDaoConverter.ToRepository(personDao);
        }

        public async Task UpdatePersonsAsync(IEnumerable<EditedPersonDtoIn> editedPersonsDtoIn)
        {
            var editedPersonsIds = editedPersonsDtoIn.Select(person => person.Id);

            var existedPersonsDao = await _gameDbContext
                .Persons
                .AsNoTracking()
                .Where(person => editedPersonsIds.Contains(person.Id))
                .ToArrayAsync();

            var editedPersonsDao = existedPersonsDao
                .Join(
                    editedPersonsDtoIn,
                    person => person.Id,
                    editedPerson => editedPerson.Id,
                    (person, editedPerson) =>
                        EditedPersonDtoInConverter.ToDb(
                            source: editedPerson,
                            personDtoOut: PersonDaoConverter.ToRepository(person)
                        )
            );

            _gameDbContext.Persons.UpdateRange(editedPersonsDao);

            await _gameDbContext.SaveChangesAsync();
        }

        public async Task DeletePersonByFilter(PersonFilterDtoIn filter)
        {
            var query = GetPersonsQuery(filter)
                .AsNoTracking();

            query = GetPersonsQueryWithPaging(query, filter);

            _gameDbContext
                .Persons
                .RemoveRange(query);

            await _gameDbContext.SaveChangesAsync();
        }

        private IQueryable<PersonDao> GetPersonsQuery(PersonFilterDtoIn filter)
        {
            return _gameDbContext
               .Persons
               .Where(
                   person =>
                       (filter.Ids == null || filter.Ids.Contains(person.Id)) &&
                       (filter.Names == null || filter.Names.Contains(person.Name)) &&
                       (filter.NameLike == null || person.Name.Contains(filter.NameLike)) &&
                       (filter.PlayerIds == null || filter.PlayerIds.Contains(person.PlayerId)) &&
                       (filter.StartRegistrationDate == null || person.RegistrationDate > filter.StartRegistrationDate) &&
                       (filter.FinishRegistrationDate == null || person.RegistrationDate < filter.FinishRegistrationDate) &&
                       (filter.StartLastVisitDate == null || person.LastVisitDate > filter.StartLastVisitDate) &&
                       (filter.FinishLastVisitDate == null || person.LastVisitDate < filter.FinishLastVisitDate) &&
                       (filter.AdminLevelIds == null || filter.AdminLevelIds.Contains(person.AdminLevelId)) &&
                       (filter.FactionIds == null || filter.FactionIds.Contains(person.FactionId)) &&
                       (filter.GangIds == null || filter.GangIds.Contains(person.GangId.Value)) &&
                       (filter.Leader == null || person.Leader == filter.Leader) &&
                       (filter.Rank == null || person.Rank == filter.Rank)
               )
               .OrderBy(person => person.Id);
        }

        private IQueryable<PersonDao> GetPersonsQueryWithPaging(IQueryable<PersonDao> query, PersonFilterDtoIn filter)
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
