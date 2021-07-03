using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Site.Infrastructure.Entities
{
    public class GroupDao
    {
        [Key]
        [MaxLength(16)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [MaxLength(32)]
        public string Name { get; set; }

        [MaxLength(6)]
        public string Color { get; set; }

        public bool Admin { get; set; }

        public bool AdminPanel { get; set; }

        public bool CreateUsers { get; set; }

        public bool DeleteUsers { get; set; }

        public bool ChangeLogin { get; set; }

        public bool ChangeGroup { get; set; }

        public bool EditGroups { get; set; }

        public int MaxBan { get; set; }

        [NotMapped]
        public string[] BanGroupIds
        {
            get => JsonConvert.DeserializeObject<string[]>(_BanGroupIds);
            set => _BanGroupIds = JsonConvert.SerializeObject(value);
        }

        public bool SeeLogs { get; set; }

        [Column("BanGroupIds")]
        public string _BanGroupIds { get; set; }

        public GroupDao()
        {
        }

        public GroupDao(
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
