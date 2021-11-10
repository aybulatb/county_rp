namespace CountyRP.Services.Site.API.Models.Api
{
    public record ApiUpdateGroupDtoIn
    {
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

        public string[] BanGroupIds { get; init; }

        public bool SeeLogs { get; init; }

        public ApiUpdateGroupDtoIn(
            string name,
            string color,
            bool admin,
            bool adminPanel,
            bool createUsers,
            bool deleteUsers,
            bool changeGroup,
            bool editGroups,
            int maxBan,
            string[] banGroupIds,
            bool seeLogs
        )
        {
            Name = name;
            Color = color;
            Admin = admin;
            AdminPanel = adminPanel;
            CreateUsers = createUsers;
            DeleteUsers = deleteUsers;
            ChangeGroup = changeGroup;
            EditGroups = editGroups;
            MaxBan = maxBan;
            BanGroupIds = banGroupIds;
            SeeLogs = seeLogs;
        }
    }
}
