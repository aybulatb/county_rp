namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiAtmDtoOut
    {
        public int Id { get; }

        public float[] Position { get; }

        public uint Dimension { get; }

        public int BusinessId { get; }

        public ApiAtmDtoOut(
            int id,
            float[] position,
            uint dimension,
            int businessId
        )
        {
            Id = id;
            Position = position;
            Dimension = dimension;
            BusinessId = businessId;
        }
    }
}
