namespace isaacmagazine.Models 
{
    public class GameDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public decimal Price { get; set; }

        // Названия в виде строк, а не объектов
        public string? GenreName { get; set; }
        public string? PlatformName { get; set; }
    }
}