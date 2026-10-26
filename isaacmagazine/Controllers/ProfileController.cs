using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using isaacmagazine.Models;

namespace isaacmagazine.Controllers
{
    [Authorize] // Только для авторизованных пользователей!
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            // Берем купленные игры из куки
            var purchasedJson = Request.Cookies["PurchasedGames"];
            var purchasedItems = new List<CartItem>();

            if (!string.IsNullOrEmpty(purchasedJson))
            {
                purchasedItems = JsonSerializer.Deserialize<List<CartItem>>(purchasedJson) ?? new List<CartItem>();
            }

            return View(purchasedItems);
        }
    }
}