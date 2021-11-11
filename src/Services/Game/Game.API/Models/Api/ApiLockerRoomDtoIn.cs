namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiLockerRoomDtoIn
    {
        public float[] Position { get; init; }

        public uint Dimension { get; init; }

        public int TypeMarker { get; init; }

        public int[] ColorMarker { get; init; }

        public string FactionId { get; init; }
    }
}
