namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiEditedGangDtoIn
    {
        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Цвет формата RRGGBB.
        /// </summary>
        public string Color { get; set; }

        public string[] Ranks { get; set; }

        public ApiGangTypeDto Type { get; set; }
    }
}
