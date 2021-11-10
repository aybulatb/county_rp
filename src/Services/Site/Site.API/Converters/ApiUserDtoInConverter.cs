using CountyRP.Services.Site.API.Models.Api;
using CountyRP.Services.Site.Infrastructure.Models;
using System;

namespace CountyRP.Services.Site.API.Converters
{
    internal static class ApiUserDtoInConverter
    {
        public static UserDtoIn ToRepository(
            ApiUserDtoIn source
        )
        {
            return new UserDtoIn(
                Login: source.Login,
                Password: source.Password,
                RegistrationDate: DateTimeOffset.Now,
                LastVisitDate: DateTimeOffset.Now,
                PlayerId: source.PlayerId,
                ForumUserId: source.ForumUserId,
                GroupId: source.GroupId
            );
        }

        public static UserDtoOut ToDtoOut(
           ApiUserDtoIn source,
           UserDtoOut existedUser
        )
        {
            return new UserDtoOut(
                Id: existedUser.Id,
                Login: source.Login,
                Password: source.Password,
                RegistrationDate: existedUser.RegistrationDate,
                LastVisitDate: existedUser.LastVisitDate,
                PlayerId: source.PlayerId,
                ForumUserId: source.ForumUserId,
                GroupId: source.GroupId
            );
        }
    }
}
