using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using isaacmagazine.Domain; // Твой namespace для DataManager
using isaacmagazine.Infrastructure;
using isaacmagazine.Models; // Для DTO

namespace isaacmagazine.Controllers.Admin
{
    [Authorize(Roles = "admin")] // Пускать только админа!
    public partial class AdminController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AdminController(DataManager dataManager, IWebHostEnvironment hostEnvironment)
        {
            _dataManager = dataManager;
            _hostEnvironment = hostEnvironment;
        }

        // Главная страница админки
        public async Task<IActionResult> Index()
        {
            // Забираем данные из БД и переводим в DTO
            ViewBag.Genres = await _dataManager.GenresRepository.GetGenresAsync();
            ViewBag.Games = DtoHelper.GamesToDto(await _dataManager.GamesRepository.GetGamesAsync());

            ViewBag.Title = "Панель администратора";
            return View();
        }

        // Вспомогательный метод для сохранения картинок
        private async Task<string> SaveImg(IFormFile file)
        {
            // Генерируем уникальное имя файла, чтобы не перезаписывать старые
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string path = Path.Combine(_hostEnvironment.WebRootPath, "img", fileName);

            // Если папки img нет - создаем
            if (!Directory.Exists(Path.Combine(_hostEnvironment.WebRootPath, "img")))
            {
                Directory.CreateDirectory(Path.Combine(_hostEnvironment.WebRootPath, "img"));
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return fileName; // Возвращаем имя, чтобы сохранить его в БД
        }
    }
}