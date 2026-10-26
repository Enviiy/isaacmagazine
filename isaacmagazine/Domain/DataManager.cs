using isaacmagazine.Domain.Repositories.Abstract; 

namespace isaacmagazine.Domain
{
    public class DataManager
    {
        public IGamesRepository GamesRepository { get; set; }
        public IGenresRepository GenresRepository { get; set; }

        public DataManager(IGamesRepository gamesRepository, IGenresRepository genresRepository)
        {
            GamesRepository = gamesRepository;
            GenresRepository = genresRepository;
        }
    }
}