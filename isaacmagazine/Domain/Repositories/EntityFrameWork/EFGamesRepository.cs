using Microsoft.EntityFrameworkCore;
using isaacmagazine.Domain.Entities;
using isaacmagazine.Domain.Repositories.Abstract;

namespace isaacmagazine.Domain.Repositories.EntityFramework
{
    public class EFGamesRepository : IGamesRepository
    {
        private readonly AppDbContext context;
        public EFGamesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            // Include нужен, чтобы подтянуть жанр игры
            return await context.Games.Include(x => x.Genre).ToListAsync();
        }

        public async Task<Game?> GetGameByIdAsync(int id)
        {
            return await context.Games.Include(x => x.Genre).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveGameAsync(Game entity)
        {
            if (entity.Id == 0)
            {
                await context.Games.AddAsync(entity); // Явно добавляем новую
            }
            else
            {
                context.Games.Update(entity); // Обновляем старую
            }

            await context.SaveChangesAsync();
        }

        public async Task DeleteGameAsync(int id)
        {
            context.Entry(new Game() { Id = id }).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }
    }
}