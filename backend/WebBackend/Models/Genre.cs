namespace WebBackend.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Film> Films { get; set; } = new List<Film>();

    }
}
