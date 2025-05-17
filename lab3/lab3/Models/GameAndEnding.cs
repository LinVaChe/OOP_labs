namespace lab3.Models
{
    public class GameAndEnding
    {
        public int Id { get; set; }
        public int? GameId { get; set; }
        public Game? Game { get; set; } 
        public int? EndingId { get; set; }
        public Ending? Ending { get; set; }
    }
}
