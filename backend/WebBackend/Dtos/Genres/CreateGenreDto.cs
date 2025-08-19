namespace WebBackend.Dtos.Genres
{
    public class CreateGenreDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
