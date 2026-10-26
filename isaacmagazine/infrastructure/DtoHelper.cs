using isaacmagazine.Domain.Entities;
using isaacmagazine.Models;

namespace isaacmagazine.Infrastructure
{
    public static class DtoHelper
    {
        public static GameDto GameToDto(Game entity)
        {
            return new GameDto
            {
                Id = entity.Id,
                Title = entity.Title,
                ShortDescription = entity.ShortDescription,
                Description = entity.Description,
                Photo = entity.Photo,
                Price = entity.Price,
                GenreName = entity.Genre?.Title,
                PlatformName = entity.Platform.ToString()
            };
        }

        public static IEnumerable<GameDto> GamesToDto(IEnumerable<Game> entities)
        {
            var list = new List<GameDto>();
            foreach (var entity in entities)
            {
                list.Add(GameToDto(entity));
            }
            return list;
        }
    }
}