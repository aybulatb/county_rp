﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Forum.Infrastructure.Entities
{
    public class ModeratorDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int EntityId { get; set; }

        public ModeratorEntityTypeDao EntityType { get; set; }

        public int ForumId { get; set; }

        public bool CreateTopics { get; set; }

        public bool CreatePosts { get; set; }

        public bool Read { get; set; }

        public bool EditPosts { get; set; }

        public bool DeleteTopics { get; set; }

        public bool DeletePosts { get; set; }

        /// <summary>
        /// Конструктор для EF
        /// </summary>
        public ModeratorDao()
        {
        }

        public ModeratorDao(
            int id,
            int entityId,
            ModeratorEntityTypeDao entityType,
            int forumId,
            bool createTopics,
            bool createPosts,
            bool read,
            bool editPosts,
            bool deleteTopics,
            bool deletePosts
        )
        {
            Id = id;
            EntityId = entityId;
            EntityType = entityType;
            ForumId = forumId;
            CreateTopics = createTopics;
            CreatePosts = createPosts;
            Read = read;
            EditPosts = editPosts;
            DeleteTopics = deleteTopics;
            DeletePosts = deletePosts;
        }
    }
}
