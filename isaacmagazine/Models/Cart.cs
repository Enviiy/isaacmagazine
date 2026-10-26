namespace isaacmagazine.Models
{
    public class Cart
    {
        // Список всех игр в корзине
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        // Добавить игру (если уже есть — увеличить количество)
        public void AddItem(CartItem item)
        {
            var existingItem = Items.FirstOrDefault(x => x.GameId == item.GameId);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                Items.Add(item);
            }
        }

        // Удалить игру
        public void RemoveItem(int gameId)
        {
            var item = Items.FirstOrDefault(x => x.GameId == gameId);
            if (item != null)
            {
                Items.Remove(item);
            }
        }

        // Очистить корзину (после покупки)
        public void Clear()
        {
            Items.Clear();
        }

        // Общая сумма
        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
    }
}