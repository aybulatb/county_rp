namespace CountyRP.Services.Site.API.Models.Api
{
    public record ApiGroupDtoOut
    {
        public int Id { get; init; }

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

        public int[] BanGroupIds { get; init; }

        public bool SeeLogs { get; init; }

        public ApiGroupDtoOut(
            int id,
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
            int[] banGroupIds,
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
