namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiFactionDtoIn
    {
        public string Id { get; init; }

        public string Name { get; init; }

        /// <summary>
        /// Цвет формата RRGGBB.
        /// </summary>
        public string Color { get; init; }

        public string[] Ranks { get; init; }

        public ApiFactionTypeDto Type { get; init; }
    }
}
