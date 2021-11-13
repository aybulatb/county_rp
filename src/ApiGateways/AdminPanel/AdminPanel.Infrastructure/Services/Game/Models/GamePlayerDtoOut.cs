using System;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models
{
    public record GamePlayerDtoOut(
        int Id,
        string Login,
        string Password,
        DateTimeOffset RegistrationDate,
        DateTimeOffset LastVisitDate
    );
}
