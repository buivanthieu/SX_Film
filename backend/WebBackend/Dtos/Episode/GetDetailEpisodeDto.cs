namespace WebBackend.Dtos.Episode
{
    public class GetDetailEpisodeDto : GetEpisodeDto
    {
        public string Quality { get; set; } = "HD";
        public string VideoUrl { get; set; } = null!;
    }
}
