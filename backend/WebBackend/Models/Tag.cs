namespace WebBackend.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public ICollection<Film> Films { get; set; } = new List<Film>();
    }
}
