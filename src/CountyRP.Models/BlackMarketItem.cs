namespace CountyRP.Models
{
    public class BlackMarketItem
    {
        public int Id { get; set; }
        public int Item { get; set; }
        public int Amount { get; set; }
        public int MaxAmount { get; set; }
        public int Price { get; set; }

        public BlackMarketItem()
        {
        }

        public BlackMarketItem(int id, int item, int amount, int maxAmount, int price)
        {
            Id = id;
            Item = item;
            Amount = amount;
            MaxAmount = maxAmount;
            Price = price;
        }
    }
}
