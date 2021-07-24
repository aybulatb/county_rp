namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class AtmDtoOut
    {
        public int Id { get; }

        public float[] Position { get; }

        public uint Dimension { get; }

        public int? BusinessId { get; }

        public AtmDtoOut(
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
