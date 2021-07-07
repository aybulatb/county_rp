namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class LockerRoomDtoIn
    {
        public float[] Position { get; }

        public uint Dimension { get; }

        public int TypeMarker { get; }

        public int[] ColorMarker { get; }

        public string FactionId { get; }

        public LockerRoomDtoIn(
            float[] position,
            uint dimension,
            int typeMarker,
            int[] colorMarker,
            string factionId
        )
        {
            Position = position;
            Dimension = dimension;
            TypeMarker = typeMarker;
            ColorMarker = colorMarker;
            FactionId = factionId;
        }
    }
}
