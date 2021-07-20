namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiLockerRoomDtoIn
    {
        public float[] Position { get; set; }

        public uint Dimension { get; set; }

        public int TypeMarker { get; set; }

        public int[] ColorMarker { get; set; }

        public string FactionId { get; set; }
    }
}
