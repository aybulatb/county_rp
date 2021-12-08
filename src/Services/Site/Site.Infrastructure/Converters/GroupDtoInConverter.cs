﻿using CountyRP.Services.Site.Infrastructure.Entities;
using CountyRP.Services.Site.Infrastructure.Models;

namespace CountyRP.Services.Site.Infrastructure.Converters
{
    internal static class GroupDtoInConverter
    {
        public static GroupDao ToDb(
            GroupDtoIn source
        )
        {
            return new GroupDao(
                id: 0,
                name: source.Name,
                color: source.Color,
                admin: source.Admin,
                adminPanel: source.AdminPanel,
                createUsers: source.CreateUsers,
                deleteUsers: source.DeleteUsers,
                changeLogin: source.ChangeLogin,
                changeGroup: source.ChangeGroup,
                editGroups: source.EditGroups,
                maxBan: source.MaxBan,
                banGroupIds: source.BanGroupIds,
                seeLogs: source.SeeLogs
            );
        }
    }
}
