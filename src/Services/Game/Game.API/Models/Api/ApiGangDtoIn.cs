using System;

namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiGangDtoIn
    {
        public string Name { get; set; }

        /// <summary>
        /// Цвет формата RRGGBB.
        /// </summary>
        public string Color { get; set; }

        public string[] Ranks { get; set; }

        public ApiGangTypeDto Type { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
    }
}
