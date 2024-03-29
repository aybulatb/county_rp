﻿using CountyRP.ApiGateways.AdminPanel.API.Models.Api;
using CountyRP.ApiGateways.AdminPanel.Infrastructure.Services.Forum.Models;
using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.API.Converters
{
    internal static class ForumForumDtoOutConverter
    {
        public static ApiForumWithModeratorsDtoOut ToApiForumWithModeratorsDtoOut(
            ForumForumDtoOut source,
            IEnumerable<ApiModeratorDtoOut> moderators
        )
        {
            return new ApiForumWithModeratorsDtoOut(
                id: source.Id,
                name: source.Name,
                parentId: source.ParentId,
                order: source.Order,
                moderators: moderators
            );
        }
    }
}
