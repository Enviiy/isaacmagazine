using System.ComponentModel.DataAnnotations;
using isaacmagazine.Domain.Entities;

namespace isaacmagazine.Domain.Entities 
{
    public class Genre : EntityBase
    {
        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}