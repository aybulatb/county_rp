namespace CountyRP.Services.Game.Infrastructure.Models
{
    public class ATMDtoIn
    {
        public float[] Position { get; }

        public uint Dimension { get; }

        public int BusinessId { get; }

        public ATMDtoIn(
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
