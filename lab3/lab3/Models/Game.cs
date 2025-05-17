namespace lab3.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? StudioId { get; set; }
        public Studio? Studio { get; set; }

    }
}
