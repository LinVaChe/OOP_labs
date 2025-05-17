namespace lab3.Models
{
    public class Studio
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Studio>? Studios { get; set; } = new List<Studio>();
    }
}
