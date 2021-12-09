using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.API.Models.Api
{
    public record ApiUpdatedForumWithModeratorsDtoIn
    {
        public string Name { get; init; }

        public IEnumerable<ApiUpdatedModeratorDtoIn> UpdatedModerators { get; init; }

        public IEnumerable<ApiModeratorDtoIn> NewModerators { get; init; }

        public IEnumerable<int> DeletedModeratorsIds { get; init; }

        public ApiUpdatedForumWithModeratorsDtoIn(
            string name,
            IEnumerable<ApiUpdatedModeratorDtoIn> updatedModerators,
            IEnumerable<ApiModeratorDtoIn> newModerators,
            IEnumerable<int> deletedModeratorsIds
        )
        {
            Name = name;
            UpdatedModerators = updatedModerators;
            NewModerators = newModerators;
            DeletedModeratorsIds = deletedModeratorsIds;
        }
    }
}
