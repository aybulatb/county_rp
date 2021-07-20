namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiFactionDtoIn
    {
        public string Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Цвет формата RRGGBB.
        /// </summary>
        public string Color { get; set; }

        public string[] Ranks { get; set; }

        public ApiFactionTypeDto Type { get; set; }
    }
}
