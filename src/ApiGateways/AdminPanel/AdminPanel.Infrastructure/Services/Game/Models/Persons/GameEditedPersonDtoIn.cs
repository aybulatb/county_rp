using System;

namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Game.Models.Persons
{
    public record GameEditedPersonDtoIn(
        int Id,
        string Name,
        int PlayerId,
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
