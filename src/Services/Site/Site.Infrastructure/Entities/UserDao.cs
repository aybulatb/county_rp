﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountyRP.Services.Site.Infrastructure.Entities
{
    public class UserDao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(32)]
        public string Login { get; set; }

        [MaxLength(64)]
        public string Password { get; set; }

        public DateTimeOffset RegistrationDate { get; set; }

        public DateTimeOffset LastVisitDate { get; set; }

        public int PlayerId { get; set; }

        public int ForumUserId { get; set; }

        [MaxLength(16)]
        public string GroupId { get; set; }

        public UserDao(
            int id,
            string login,
            string password,
            DateTimeOffset registrationDate,
            DateTimeOffset lastVisitDate,
            int playerId,
            int forumUserId,
            string groupId
        )
        {
            Id = id;
            Login = login;
            RegistrationDate = registrationDate;
            LastVisitDate = lastVisitDate;
            Password = password;
            PlayerId = playerId;
            ForumUserId = forumUserId;
            GroupId = groupId;
        }
    }
}
