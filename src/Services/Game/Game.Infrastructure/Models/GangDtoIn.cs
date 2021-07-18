using System;

namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class GangDtoIn
    {
        public string Name { get; }

        /// <summary>
        /// Цвет формата RRGGBB.
        /// </summary>
        public string Color { get; }

        public string[] Ranks { get; }

        public GangTypeDto Type { get; }

        public DateTimeOffset CreatedDate { get; }

        public GangDtoIn(
            string name,
            string color,
            string[] ranks,
            GangTypeDto type,
            DateTimeOffset createdDate
        )
        {
            Name = name;
            Color = color;
            Ranks = ranks;
            Type = type;
            CreatedDate = createdDate;
        }
    }
}
