using System;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models.Player
{
    public record GameEditedPlayerDtoIn(
        string Login,
        string Password,
        DateTimeOffset LastVisitDate
    );
}
