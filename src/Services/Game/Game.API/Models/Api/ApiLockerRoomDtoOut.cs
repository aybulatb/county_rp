namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiLockerRoomDtoOut
    {
        public int Id { get; init; }

        public float[] Position { get; init; }

        public uint Dimension { get; init; }

        public int TypeMarker { get; init; }

        public int[] ColorMarker { get; init; }

        public string FactionId { get; init; }

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
