namespace CountyRP.Services.Site.Models
{
    public class GroupDtoOut
    {
        public string Id { get; }

        public string Name { get; }

        public string Color { get; }

        public bool Admin { get; }

        public bool AdminPanel { get; }

        public bool CreateUsers { get; }

        public bool DeleteUsers { get; }

        public bool ChangeLogin { get; }

        public bool ChangeGroup { get; }

        public bool EditGroups { get; }

        public int MaxBan { get; }

        public string[] BanGroupIds { get; }

        public bool SeeLogs { get; }

        public GroupDtoOut(
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
            string[] banGroupIds,
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
