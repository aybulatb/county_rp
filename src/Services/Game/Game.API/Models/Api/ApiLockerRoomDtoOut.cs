namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiLockerRoomDtoOut
    {
        public int Id { get; }

        public float[] Position { get; }

        public uint Dimension { get; }

        public int TypeMarker { get; }

        public int[] ColorMarker { get; }

        public string FactionId { get; }

        public ApiLockerRoomDtoOut(
            int id,
            float[] position,
            uint dimension,
            int typeMarker,
            int[] colorMarker,
            string factionId
        )
        {
            Id = id;
            Position = position;
            Dimension = dimension;
            TypeMarker = typeMarker;
            ColorMarker = colorMarker;
            FactionId = factionId;
        }
    }
}
