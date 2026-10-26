using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using isaacmagazine.Domain.Entities;
using isaacmagazine.Domain.Enums;

namespace isaacmagazine.Controllers.Admin
{
    public partial class AdminController
    {
        // GET: Форма создания/редактирования
        public async Task<IActionResult> GamesEdit(int id = 0)
        {
            Game entity = id == default ? new Game() : await _dataManager.GamesRepository.GetGameByIdAsync(id);

            ViewBag.Genres = await _dataManager.GenresRepository.GetGenresAsync();

            return View(entity);
        }

        // POST: Сохранение игры
        [HttpPost]
        public async Task<IActionResult> GamesEdit(Game entity, IFormFile? titleImage)
        {
            ModelState.Remove("DateCreated");
            ModelState.Remove("Genre");

            if (entity.DateCreated == default)
            {
                entity.DateCreated = DateTime.UtcNow;
            }

            if (ModelState.IsValid)
            {
                if (titleImage != null)
                {
                    entity.Photo = await SaveImg(titleImage);
                }

                await _dataManager.GamesRepository.SaveGameAsync(entity);
                return RedirectToAction("Index");
            }

            // Если ошибка — снова передаем простой список
            ViewBag.Genres = await _dataManager.GenresRepository.GetGenresAsync();
            return View(entity);
        }

        // POST: Удаление игры
        [HttpPost]
        public async Task<IActionResult> GamesDelete(int id)
        {
            try
            {
                await _dataManager.GamesRepository.DeleteGameAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest("Ошибка при удалении: " + ex.Message);
            }
        }
    }
}