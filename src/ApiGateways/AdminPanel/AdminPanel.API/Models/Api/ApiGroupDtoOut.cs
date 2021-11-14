using System.Collections.Generic;

namespace CountyRP.ApiGateways.AdminPanel.API.Models.Api
{
    public record ApiGroupDtoOut
    {
        public string Id { get; init; }

        public string Name { get; init; }

        public string Color { get; init; }

        public bool Admin { get; init; }

        public bool AdminPanel { get; init; }

        public bool CreateUsers { get; init; }

        public bool DeleteUsers { get; init; }

        public bool ChangeLogin { get; init; }

        public bool ChangeGroup { get; init; }

        public bool EditGroups { get; init; }

        public int MaxBan { get; init; }

        public IEnumerable<string> BanGroupIds { get; init; }

        public bool SeeLogs { get; init; }

        public ApiGroupDtoOut(
            string id,
            string name,
            string color,
            bool admin,
            bool adminPanel,
            bool createUsers,
            bool deleteUsers,
            bool changeLogin,
            bool changeGroup,
            bool editGroups,
            int maxBan,
            IEnumerable<string> banGroupIds,
            bool seeLogs
        )
        {
            Id = id;
            Name = name;
            Color = color;
            Admin = admin;
            AdminPanel = adminPanel;
            CreateUsers = createUsers;
            DeleteUsers = deleteUsers;
            ChangeLogin = changeLogin;
            ChangeGroup = changeGroup;
            EditGroups = editGroups;
            MaxBan = maxBan;
            BanGroupIds = banGroupIds;
            SeeLogs = seeLogs;
        }
    }
}
