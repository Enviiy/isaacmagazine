using Microsoft.AspNetCore.Mvc;
using isaacmagazine.Domain;
using isaacmagazine.Infrastructure;
using isaacmagazine.Models;

namespace isaacmagazine.Controllers
{
    public class GamesController : Controller
    {
        private readonly DataManager _dataManager;

        public GamesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<IActionResult> Index()
        {
            var games = await _dataManager.GamesRepository.GetGamesAsync();
            var gamesDto = DtoHelper.GamesToDto(games);
            return View(gamesDto);
        }

        public async Task<IActionResult> Show(int id)
        {
            var game = await _dataManager.GamesRepository.GetGameByIdAsync(id);
            if (game == null) return NotFound();
            var gameDto = DtoHelper.GameToDto(game);
            return View(gameDto);
        }
    }
}