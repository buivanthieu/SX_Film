namespace WebBackend.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ImageUrl { get; set; }
        public string? Country { get; set; }

        public ICollection<FilmActor> FilmActors { get; set; } = new List<FilmActor>();
        public ICollection<BookmarkActor> BookmarkActors { get; set; } = new List<BookmarkActor>();

    }
}
