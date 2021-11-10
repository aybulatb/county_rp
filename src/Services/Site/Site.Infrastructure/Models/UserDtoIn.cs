using System;

namespace CountyRP.Services.Site.Infrastructure.Models
{
    public record UserDtoIn(
        string Login,
        string Password,
        DateTimeOffset RegistrationDate,
        DateTimeOffset LastVisitDate,
        int PlayerId,
        int ForumUserId,
        string GroupId
    );
}
