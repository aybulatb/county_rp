namespace CountyRP.Services.Game.API.Models.Api
{
    public record ApiAtmDtoOut
    {
        public int Id { get; init; }

        public float[] Position { get; init; }

        public uint Dimension { get; init; }

        public int? BusinessId { get; init; }

        public ApiAtmDtoOut(
            int id,
            float[] position,
            uint dimension,
            int? businessId
        )
        {
            Id = id;
            Position = position;
            Dimension = dimension;
            BusinessId = businessId;
        }
    }
}
