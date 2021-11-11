using System;

namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiGangDtoIn
    {
        public string Name { get; init; }

        /// <summary>
        /// Цвет формата RRGGBB.
        /// </summary>
        public string Color { get; init; }

        public string[] Ranks { get; init; }

        public ApiGangTypeDto Type { get; init; }

        public DateTimeOffset CreatedDate { get; init; }
    }
}
