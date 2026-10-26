using Microsoft.AspNetCore.Mvc;
using isaacmagazine.Domain.Entities;

namespace isaacmagazine.Controllers.Admin
{
    public partial class AdminController
    {
        // GET: Открывает форму создания или редактирования
        public async Task<IActionResult> GenresEdit(int id = 0)
        {
            Genre entity = id == default ? new Genre() : await _dataManager.GenresRepository.GetGenreByIdAsync(id);
            return View(entity);
        }

        // POST: Сохраняет изменения
        [HttpPost]
        public async Task<IActionResult> GenresEdit(Genre entity)
        {
            // Убираем дату из проверки, чтобы она не блокировала сохранение
            ModelState.Remove("DateCreated");
            ModelState.Remove("Games");

            if (string.IsNullOrWhiteSpace(entity.Title))
            {
                ModelState.AddModelError("Title", "Название не может быть пустым!");
                return View(entity);
            }

            if (ModelState.IsValid)
            {
                if (entity.DateCreated == default)
                {
                    entity.DateCreated = DateTime.UtcNow;
                }

                await _dataManager.GenresRepository.SaveGenreAsync(entity);
                return RedirectToAction("Index");
            }

            return View(entity);
        }

        // POST: Удаление жанра
        [HttpPost]
        public async Task<IActionResult> GenresDelete(int id)
        {
            try
            {
                await _dataManager.GenresRepository.DeleteGenreAsync(id);
            }
            catch (Exception)
            {

                return BadRequest("Нельзя удалить жанр, пока к нему привязаны игры.");
            }
            return RedirectToAction("Index");
        }
    }
}