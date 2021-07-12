using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Forum.Infrastructure.Entities
{
    public class UserDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(32)]
        public string Login { get; set; }

        [MinLength(3)]
        [MaxLength(16)]
        public string GroupId { get; set; }

        public int Reputation { get; set; }

        public int Posts { get; set; }

        public int Warnings { get; set; }

        /// <summary>
        /// Конструктор для EF
        /// </summary>
        public UserDao()
        {
        }

        public UserDao(
            int id,
            string login,
            string groupId,
            int reputation,
            int posts,
            int warnings
        )
        {
            Id = id;
            Login = login;
            GroupId = groupId;
            Reputation = reputation;
            Posts = posts;
            Warnings = warnings;
        }
    }
}
