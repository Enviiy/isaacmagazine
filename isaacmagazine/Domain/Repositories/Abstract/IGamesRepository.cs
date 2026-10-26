using isaacmagazine.Domain.Entities;

namespace isaacmagazine.Domain.Repositories.Abstract
{
    public interface IGamesRepository
    {
        Task<IEnumerable<Game>> GetGamesAsync();
        Task<Game?> GetGameByIdAsync(int id);
        Task SaveGameAsync(Game entity);
        Task DeleteGameAsync(int id);
    }
}