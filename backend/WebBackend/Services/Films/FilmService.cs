using AutoMapper;
using WebBackend.Dtos.Films;
using WebBackend.Dtos.Movies;
using WebBackend.Dtos.Series;
using WebBackend.Models;
using WebBackend.Repositories.Films;

namespace WebBackend.Services.Films
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;
        public FilmService(IFilmRepository filmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _mapper = mapper;
        }
        public async Task<ICollection<GetFilmDto>> GetAllFilms()
        {
            var films = await _filmRepository.GetAllFilms();
            return _mapper.Map<ICollection<GetFilmDto>>(films);
        }

        public async Task<GetFilmDto> GetFilmById(int id)
        {
            var film = await _filmRepository.GetFilmById(id);

            if (film is Movie movie)
            {
                return _mapper.Map<GetMovieDto>(movie);
            }
            else if (film is Seri series)
            {
                return _mapper.Map<GetSeriWithSeasonsDto>(series);
            }

            throw new InvalidOperationException("Unknown film type");
        }

        public async Task<ICollection<GetFilmDto>> GetFilmsByGenreId(int genreId)
        {
            var films = await _filmRepository.GetFilmsByGenreId(genreId);
            var result = new List<GetFilmDto>();

            foreach (var film in films)
            {
                if (film.IsSeries)
                {
                    result.Add(_mapper.Map<GetSeriDto>(film));
                }
                else
                {
                    result.Add(_mapper.Map<GetMovieDto>(film));
                }
            }

            return result;
        }

        public async Task<ICollection<GetFilmDto>> GetFilmsByTagId(int tagId)
        {
            var films = await _filmRepository.GetFilmsByTagId(tagId);

            var result = new List<GetFilmDto>();

            foreach (var film in films)
            {
                if (film.IsSeries)
                {
                    result.Add(_mapper.Map<GetSeriDto>(film));
                }
                else
                {
                    result.Add(_mapper.Map<GetMovieDto>(film));
                }
            }

            return result;
        }

        public async Task<ICollection<GetFilmDto>> SearchFilm(string searchTerm)
        {
            var films = await _filmRepository.SearchFilm(searchTerm);

            var result = new List<GetFilmDto>();

            foreach (var film in films)
            {
                if (film.IsSeries)
                {
                    result.Add(_mapper.Map<GetSeriDto>(film));
                }
                else
                {
                    result.Add(_mapper.Map<GetMovieDto>(film));
                }
            }

            return result; 
        }
    }
}
