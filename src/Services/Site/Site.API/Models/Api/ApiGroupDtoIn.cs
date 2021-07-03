namespace CountyRP.Services.Site.API.Models.Api
{
    public class ApiGroupDtoIn
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public bool Admin { get; set; }

        public bool AdminPanel { get; set; }

        public bool CreateUsers { get; set; }

        public bool DeleteUsers { get; set; }

        public bool ChangeLogin { get; set; }

        public bool ChangeGroup { get; set; }

        public bool EditGroups { get; set; }

        public int MaxBan { get; set; }

        public string[] BanGroupIds { get; set; }

        public bool SeeLogs { get; set; }

        public ApiGroupDtoIn(
            string id,
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
            Id = id;
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
