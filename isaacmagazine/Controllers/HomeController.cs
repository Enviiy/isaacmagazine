using Microsoft.AspNetCore.Mvc;

namespace isaacmagazine.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
