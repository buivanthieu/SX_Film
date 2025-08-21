using WebBackend.Dtos.Episode;

namespace WebBackend.Dtos.Seasons
{
    public class GetSeasonDto
    {
        public int Id { get; set; }
        public int SeriId { get; set; }
        public int SeasonNumber { get; set; }
        public string? Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public List<GetEpisodeDto> Episodes { get; set; } = new List<GetEpisodeDto>();
    }
}
