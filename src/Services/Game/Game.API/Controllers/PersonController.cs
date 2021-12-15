﻿using CountyRP.Services.Game.API.Converters;
using CountyRP.Services.Game.API.Models.Api;
using CountyRP.Services.Game.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CountyRP.Services.Game.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IGameRepository _gameRepository;

        public PersonController(
            ILogger<PersonController> logger,
            IGameRepository gameRepository
        )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiPersonDtoOut), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromBody] ApiPersonDtoIn apiPersonDtoIn
        )
        {
            if (apiPersonDtoIn.Name == null || apiPersonDtoIn.Name.Length < 3 || apiPersonDtoIn.Name.Length > 32)
            {
                return BadRequest(
                    ConstantMessages.PersonInvalidNameLength
                );
            }
            if (!Regex.IsMatch(apiPersonDtoIn.Name, @"^([0-9a-zA-Z]{3,32}|[0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31}|[0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31})$"))
            {
                return BadRequest(
                    ConstantMessages.PersonInvalidName
                );
            }

            var existedPersons = await _gameRepository.GetPersonsByFilter(
                PersonNameConverter.ToPersonFilterDtoIn(apiPersonDtoIn.Name)
            );

            if (existedPersons.AllCount != 0)
            {
                return BadRequest(
                    string.Format(
                        ConstantMessages.PersonAlreadyExistedWithName,
                        apiPersonDtoIn.Name
                    )
                );
            }

            var personDtoIn = ApiPersonDtoInConverter.ToRepository(apiPersonDtoIn);

            var personDtoOut = await _gameRepository.AddPersonAsync(personDtoIn);

            return Created(
                string.Empty,
                PersonDtoOutConverter.ToApi(personDtoOut)
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiPersonDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var filteredPersons = await _gameRepository.GetPersonsByFilter(
                PersonIdConverter.ToPersonFilterDtoIn(id)
            );

            if (!filteredPersons.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.PersonNotFoundById,
                        id
                    )
                );
            }

            var person = filteredPersons.Items.First();

            return Ok(
                PersonDtoOutConverter.ToApi(person)
            );
        }

        [HttpGet("FilterBy")]
        [ProducesResponseType(typeof(ApiPagedFilterResultDtoOut<ApiPersonDtoOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FilterBy(
            [FromQuery] ApiPersonFilterDtoIn apiPersonFilterDtoIn
        )
        {
            if (apiPersonFilterDtoIn.Count.HasValue && apiPersonFilterDtoIn.Count < 1)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidCountItemPerPage,
                        message: ConstantMessages.InvalidCountItemPerPage
                    )
                );
            }
            if (apiPersonFilterDtoIn.Page.HasValue && apiPersonFilterDtoIn.Page < 1)
            {
                return BadRequest(
                    new ApiErrorResponseDtoOut(
                        code: ApiErrorCodeDto.InvalidPageNumber,
                        message: ConstantMessages.InvalidPageNumber
                    )
                );
            }

            var filter = ApiPersonFilterDtoInConverter.ToRepository(apiPersonFilterDtoIn);

            var persons = await _gameRepository.GetPersonsByFilter(filter);

            return Ok(
                PagedFilterResultDtoOutConverter.ToApi(persons)
            );
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiPersonDtoOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(
            int id,
            ApiEditedPersonDtoIn apiEditedPersonDtoIn
        )
        {
            var filteredPersons = await _gameRepository.GetPersonsByFilter(
                PersonIdConverter.ToPersonFilterDtoIn(id)
            );

            if (filteredPersons.AllCount == 0)
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.PersonNotFoundById,
                        id
                    )
                );
            }

            var currentPerson = filteredPersons.Items.First();

            if (currentPerson.Name != apiEditedPersonDtoIn.Name)
            {
                if (apiEditedPersonDtoIn.Name == null || apiEditedPersonDtoIn.Name.Length < 3 || apiEditedPersonDtoIn.Name.Length > 32)
                {
                    return BadRequest(
                        ConstantMessages.PersonInvalidNameLength
                    );
                }
                if (!Regex.IsMatch(apiEditedPersonDtoIn.Name, @"^([0-9a-zA-Z]{3,32}|[0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31}|[0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31})$"))
                {
                    return BadRequest(
                        ConstantMessages.PersonInvalidName
                    );
                }

                var existedPersonsWithNewName = await _gameRepository.GetPersonsByFilter(
                    PersonNameConverter.ToPersonFilterDtoIn(apiEditedPersonDtoIn.Name)
                );

                if (existedPersonsWithNewName.AllCount != 0)
                {
                    return BadRequest(
                        string.Format(
                            ConstantMessages.PersonAlreadyExistedWithName,
                            apiEditedPersonDtoIn.Name
                        )
                    );
                }
            }

            var editedPersonDtoIn = ApiEditedPersonDtoInConverter.ToRepository(
                source: apiEditedPersonDtoIn,
                id: id
            );

            var personDtoOut = await _gameRepository.UpdatePersonAsync(editedPersonDtoIn);

            return Ok(
                PersonDtoOutConverter.ToApi(personDtoOut)
            );
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> MassivelyEdit(IEnumerable<ApiEditedPersonDtoIn> apiEditedPersonsDtoIn)
        {
            var idsForEdition = apiEditedPersonsDtoIn.Select(person => person.Id);

            var filteredPersons = await _gameRepository.GetPersonsByFilter(
                PersonIdConverter.ToPersonFilterDtoIn(idsForEdition)
            );

            var filteredIds = filteredPersons.Items.Select(person => person.Id);

            var differenceIds = idsForEdition.Except(filteredIds);

            if (differenceIds.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.PersonNotFoundById,
                        differenceIds
                    )
                );
            }

            foreach (var apiEditedPersonDtoIn in apiEditedPersonsDtoIn)
            {
                var currentPerson = filteredPersons.Items.First(person => person.Id == apiEditedPersonDtoIn.Id);

                if (currentPerson.Name != apiEditedPersonDtoIn.Name)
                {
                    if (apiEditedPersonDtoIn.Name == null || apiEditedPersonDtoIn.Name.Length < 3 || apiEditedPersonDtoIn.Name.Length > 32)
                    {
                        return BadRequest(
                            ConstantMessages.PersonInvalidNameLength
                        );
                    }
                    if (!Regex.IsMatch(apiEditedPersonDtoIn.Name, @"^([0-9a-zA-Z]{3,32}|[0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31}|[0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31} [0-9a-zA-Z]{1,31})$"))
                    {
                        return BadRequest(
                            ConstantMessages.PersonInvalidName
                        );
                    }

                    var existedPersonsWithNewName = await _gameRepository.GetPersonsByFilter(
                        PersonNameConverter.ToPersonFilterDtoIn(apiEditedPersonDtoIn.Name)
                    );

                    if (existedPersonsWithNewName.AllCount != 0)
                    {
                        return BadRequest(
                            string.Format(
                                ConstantMessages.PersonAlreadyExistedWithName,
                                apiEditedPersonDtoIn.Name
                            )
                        );
                    }
                }
            }

            var editedPersonsDtoIn = apiEditedPersonsDtoIn
                .Select(apiEditedPersonDtoIn =>
                    ApiEditedPersonDtoInConverter.ToRepository(
                        source: apiEditedPersonDtoIn
                    )
                );

            await _gameRepository.UpdatePersonsAsync(editedPersonsDtoIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponseDtoOut), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var filter = PersonIdConverter.ToPersonFilterDtoIn(id);

            var filteredPersons = await _gameRepository.GetPersonsByFilter(filter);

            if (!filteredPersons.Items.Any())
            {
                return NotFound(
                    string.Format(
                        ConstantMessages.PersonNotFoundById,
                        id
                    )
                );
            }

            await _gameRepository.DeletePersonByFilter(filter);

            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> MassivelyDelete([FromQuery] IEnumerable<int> ids)
        {
            var filter = PersonIdConverter.ToPersonFilterDtoIn(ids);

            await _gameRepository.DeletePersonByFilter(filter);

            return Ok();
        }
    }
}
