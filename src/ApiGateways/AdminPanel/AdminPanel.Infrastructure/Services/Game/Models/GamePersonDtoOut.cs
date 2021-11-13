using System;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models
{
    public record GamePersonDtoOut(
        int Id,
        string Name,
        int PlayerId,
        DateTimeOffset RegistrationDate,
        DateTimeOffset LastVisitDate,
        string AdminLevelId,
        string FactionId,
        int? GangId,
        bool Leader,
        int Rank,
        float[] Position,
        int CommonInventoryId,
        int PocketsInventoryId
    );
}
