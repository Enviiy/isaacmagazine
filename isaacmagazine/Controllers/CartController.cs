using isaacmagazine.Domain;
using isaacmagazine.Infrastructure;
using isaacmagazine.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace isaacmagazine.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;
        private readonly DataManager _dataManager;

        public CartController(CartService cartService, DataManager dataManager)
        {
            _cartService = cartService;
            _dataManager = dataManager;
        }

        // Страница корзины
        public IActionResult Index()
        {
            var cart = _cartService.GetCart();
            return View(cart);
        }

        // Добавление игры в корзину
        [HttpPost]
        public async Task<IActionResult> Add(int id)
        {
            var game = await _dataManager.GamesRepository.GetGameByIdAsync(id);
            if (game == null) return NotFound();

            var cart = _cartService.GetCart();
            cart.AddItem(new CartItem
            {
                GameId = game.Id,
                GameName = game.Title,
                Price = game.Price,
                Photo = game.Photo,
                Quantity = 1
            });
            _cartService.SaveCart(cart);

            return RedirectToAction("Index"); // Кидаем сразу в корзину
        }

        // Удаление игры из корзины
        [HttpPost]
        public IActionResult Remove(int id)
        {
            var cart = _cartService.GetCart();
            cart.RemoveItem(id);
            _cartService.SaveCart(cart);
            return RedirectToAction("Index");
        }

        // Оформление заказа
        [HttpPost]
        public IActionResult Checkout()
        {
            var cart = _cartService.GetCart();

            if (cart.Items.Count == 0)
                return RedirectToAction("Index");

            // 1. Берем старые покупки из куки (если есть)
            var existingPurchasesJson = Request.Cookies["PurchasedGames"];
            var purchasedItems = new List<CartItem>();
            if (!string.IsNullOrEmpty(existingPurchasesJson))
            {
                purchasedItems = JsonSerializer.Deserialize<List<CartItem>>(existingPurchasesJson) ?? new List<CartItem>();
            }

            // 2. Добавляем новые игры к старым
            purchasedItems.AddRange(cart.Items);

            // 3. Сохраняем обратно в куки (на 30 дней)
            var options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30),
                HttpOnly = true
            };
            Response.Cookies.Append("PurchasedGames", JsonSerializer.Serialize(purchasedItems), options);

            // 4. Очищаем корзину
            cart.Clear();
            _cartService.SaveCart(cart);

            TempData["Message"] = "Спасибо за покупку! Игры добавлены в ваш профиль.";
            return RedirectToAction("Index", "Profile"); // Кидаем в профиль!
        }
    }
}