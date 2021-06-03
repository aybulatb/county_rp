using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Forum.Entities
{
    public class ForumDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(96)]
        public string Name { get; set; }

        public int ParentId { get; set; }

        public int Order { get; set; }

        /// <summary>
        /// Конструктор для EF
        /// </summary>
        public ForumDao()
        {
        }

        public ForumDao(
            int id,
            string name,
            int parentId,
            int order
        )
        {
            Id = id;
            Name = name;
            ParentId = parentId;
            Order = order;
        }
    }
}
