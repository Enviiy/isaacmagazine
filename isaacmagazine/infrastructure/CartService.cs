using System.Text.Json;
using isaacmagazine.Models;

namespace isaacmagazine.Infrastructure
{
    public class CartService
    {
        private const string CartKey = "Cart";
        private readonly ISession _session;

        public CartService(ISession session)
        {
            _session = session;
        }

        // Получить корзину (или создать новую, если её нет)
        public Cart GetCart()
        {
            var cartJson = _session.GetString(CartKey);
            if (string.IsNullOrEmpty(cartJson))
            {
                return new Cart();
            }
            return JsonSerializer.Deserialize<Cart>(cartJson) ?? new Cart();
        }

        // Сохранить корзину в сессию
        public void SaveCart(Cart cart)
        {
            var cartJson = JsonSerializer.Serialize(cart);
            _session.SetString(CartKey, cartJson);
        }
    }
}