namespace WebBackend.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ICollection<FilmActor> FilmActors { get; set; } = new List<FilmActor>();


    }
}
