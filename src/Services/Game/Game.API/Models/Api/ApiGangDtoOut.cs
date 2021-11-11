using System;

namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiGangDtoOut
    {
        public int Id { get; init; }

        public string Name { get; init; }

        /// <summary>
        /// Цвет формата RRGGBB.
        /// </summary>
        public string Color { get; init; }

        public string[] Ranks { get; init; }

        public ApiGangTypeDto Type { get; init; }

        public DateTimeOffset CreatedDate { get; init; }

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
