namespace isaacmagazine.Models
{
    public class CartItem
    {
        public int GameId { get; set; }
        public string? GameName { get; set; }
        public decimal Price { get; set; }
        public string? Photo { get; set; }
        public int Quantity { get; set; }
    }
}