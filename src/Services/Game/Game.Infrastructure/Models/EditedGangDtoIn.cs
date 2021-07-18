namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class EditedGangDtoIn
    {
        public int Id { get; }

        public string Name { get; }

        /// <summary>
        /// Цвет формата RRGGBB.
        /// </summary>
        public string Color { get; }

        public string[] Ranks { get; }

        public GangTypeDto Type { get; }

        public EditedGangDtoIn(
            int id,
            string name,
            string color,
            string[] ranks,
            GangTypeDto type
        )
        {
            Name = name;
            Color = color;
            Ranks = ranks;
            Type = type;
        }
    }
}
