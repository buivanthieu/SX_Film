namespace WebBackend.Dtos.Seasons
{
    public class CreateSeasonDto
    {
        public int SeriId { get; set; }
        public int SeasonNumber { get; set; }
        public string? Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
