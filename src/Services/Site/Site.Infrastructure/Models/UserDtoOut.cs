using System;

namespace CountyRP.Services.Site.Infrastructure.Models
{
    public record UserDtoOut(
        int Id,
        string Login,
        string Password,
        DateTimeOffset RegistrationDate,
        DateTimeOffset LastVisitDate,
        int PlayerId,
        int ForumUserId,
        string GroupId
    );
}
