namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class AtmDtoIn
    {
        public float[] Position { get; }

        public uint Dimension { get; }

        public int BusinessId { get; }

        public AtmDtoIn(
            float[] position,
            uint dimension,
            int businessId
        )
        {
            Position = position;
            Dimension = dimension;
            BusinessId = businessId;
        }
    }
}
