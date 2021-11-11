namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiFactionDtoOut
    {
        public string Id { get; init; }

        public string Name { get; init; }

        /// <summary>
        /// Цвет формата RRGGBB.
        /// </summary>
        public string Color { get; init; }

        public string[] Ranks { get; init; }

        public ApiFactionTypeDto Type { get; init; }

        public ApiFactionDtoOut(
            string id,
            string name,
            string color,
            string[] ranks,
            ApiFactionTypeDto type
        )
        {
            Id = id;
            Name = name;
            Color = color;
            Ranks = ranks;
            Type = type;
        }
    }
}
