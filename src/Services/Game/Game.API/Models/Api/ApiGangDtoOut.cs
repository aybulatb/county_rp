using System;

namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiGangDtoOut
    {
        public int Id { get; }

        public string Name { get; }

        /// <summary>
        /// Цвет формата RRGGBB.
        /// </summary>
        public string Color { get; }

        public string[] Ranks { get; }

        public ApiGangTypeDto Type { get; }

        public DateTimeOffset CreatedDate { get; }

        public ApiGangDtoOut(
            int id,
            string name,
            string color,
            string[] ranks,
            ApiGangTypeDto type,
            DateTimeOffset createdDate
        )
        {
            Id = id;
            Name = name;
            Color = color;
            Ranks = ranks;
            Type = type;
            CreatedDate = createdDate;
        }
    }
}
