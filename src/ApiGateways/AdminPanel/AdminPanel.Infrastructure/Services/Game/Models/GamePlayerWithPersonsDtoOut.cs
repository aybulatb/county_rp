using System;
using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models
{
    public record GamePlayerWithPersonsDtoOut(
        int Id,
        string Login,
        string Password,
        DateTimeOffset RegistrationDate,
        DateTimeOffset LastVisitDate,
        IEnumerable<GamePersonDtoOut> Persons
    );
}
