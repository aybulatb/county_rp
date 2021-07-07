namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class FactionDtoIn
    {
        public string Id { get; }

        public string Name { get; }

        /// <summary>
        /// Цвет формата RRGGBB.
        /// </summary>
        public string Color { get; }

        public string[] Ranks { get; }

        public FactionTypeDto Type { get; }

        public FactionDtoIn(
            string id,
            string name,
            string color,
            string[] ranks,
            FactionTypeDto type
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
