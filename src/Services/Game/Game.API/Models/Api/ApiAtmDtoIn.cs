namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiAtmDtoIn
    {
        public float[] Position { get; init; }

        public uint Dimension { get; init; }

        public int? BusinessId { get; init; }
    }
}
