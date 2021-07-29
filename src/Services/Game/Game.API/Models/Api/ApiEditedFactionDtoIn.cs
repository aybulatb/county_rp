namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiEditedFactionDtoIn
    {
        public string Name { get; set; }

        /// <summary>
        /// Цвет формата RRGGBB.
        /// </summary>
        public string Color { get; set; }

        public string[] Ranks { get; set; }

        public ApiFactionTypeDto Type { get; set; }
    }
}
