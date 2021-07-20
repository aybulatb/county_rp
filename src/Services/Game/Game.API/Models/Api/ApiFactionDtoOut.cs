namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiFactionDtoOut
    {
        public string Id { get; }

        public string Name { get; }

        /// <summary>
        /// Цвет формата RRGGBB.
        /// </summary>
        public string Color { get; }

        public string[] Ranks { get; }

        public ApiFactionTypeDto Type { get; }

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
