using isaacmagazine.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace isaacmagazine.Domain.Entities
{
    public class Game : EntityBase
    {
        [Display(Name = "Выберите жанр игры")]
        public int? GenreId { get; set; } 
        public Genre? Genre { get; set; }

        [Display(Name = "Краткое описание")]
        [MaxLength(300)]
        public string? ShortDescription { get; set; }

        [Display(Name = "Полное описание")]
        [MaxLength(100000)]
        public string? Description { get; set; }

        [Display(Name = "Обложка игры")]
        public string? Photo { get; set; }

        [Display(Name = "Цена (в рублях)")]
        [Column(TypeName = "decimal(18,2)")] 
        public decimal Price { get; set; }

        [Display(Name = "Платформа")]
        public PlatformType Platform { get; set; } 
    }
}