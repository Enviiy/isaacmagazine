using Microsoft.EntityFrameworkCore;
using isaacmagazine.Domain.Entities;
using isaacmagazine.Domain.Repositories.Abstract;

namespace isaacmagazine.Domain.Repositories.EntityFramework
{
    public class EFGenresRepository : IGenresRepository
    {
        private readonly AppDbContext context;
        public EFGenresRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await context.Genres.Include(x => x.Games).ToListAsync();
        }

        public async Task<Genre?> GetGenreByIdAsync(int id)
        {
            return await context.Genres.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveGenreAsync(Genre entity)
        {
            context.Entry(entity).State = entity.Id == default ? EntityState.Added : EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteGenreAsync(int id)
        {
            context.Entry(new Genre() { Id = id }).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }
    }
}