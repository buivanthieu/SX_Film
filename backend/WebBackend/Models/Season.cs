namespace WebBackend.Models
{
    public class Season
    {
        public int Id { get; set; }

        public int SeriId { get; set; }
        public Seri Series { get; set; } = null!;

        public int SeasonNumber { get; set; }
        public string? Title { get; set; }
        public DateTime? ReleaseDate { get; set; }


        public ICollection<Episode> Episodes { get; set; } = new List<Episode>();
    }
}
