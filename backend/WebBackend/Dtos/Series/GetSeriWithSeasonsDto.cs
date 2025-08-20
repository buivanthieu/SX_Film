using WebBackend.Dtos.Films;
using WebBackend.Dtos.Seasons;

namespace WebBackend.Dtos.Series
{
    public class GetSeriWithSeasonsDto : GetFilmDto
    {
        public ICollection<GetSeasonDto> Seasons { get; set; } = new List<GetSeasonDto>();

    }
}
