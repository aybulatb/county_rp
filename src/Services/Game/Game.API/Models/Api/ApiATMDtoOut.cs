namespace CountyRP.Services.Game.API.Models.Api
{
    public class ApiATMDtoOut
    {
        public int Id { get; }

        public float[] Position { get; }

        public uint Dimension { get; }

        public int BusinessId { get; }

        public ApiATMDtoOut(
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
