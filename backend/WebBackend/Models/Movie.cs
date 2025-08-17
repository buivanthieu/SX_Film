namespace WebBackend.Models
{
    public class Movie : Film
    {
        public int Duration { get; set; }
        public string? Quality { get; set; }
        public string VideoUrl { get; set; } = null!;
    }
}
