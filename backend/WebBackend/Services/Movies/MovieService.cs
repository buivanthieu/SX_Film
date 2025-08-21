using AutoMapper;
using WebBackend.Dtos.Movies;
using WebBackend.Models;
using WebBackend.Repositories.Movies;

namespace WebBackend.Services.Movies
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public async Task AddMovie(CreateMovieDto movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            await _movieRepository.AddMovie(movie);

        }
        public async Task UpdateMovie(int movieId, UpdateMovieDto movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);

            await _movieRepository.UpdateMovie(movieId, movie);
        }
        public async Task DeleteMovie(int id)
        {
            await _movieRepository.DeleteMovie(id);

        }
        public async Task<ICollection<GetMovieDto>> GetAllMovies()
        {
            var movies = await _movieRepository.GetAllMovies();
            return _mapper.Map<ICollection<GetMovieDto>>(movies);
        }
        public async Task<GetMovieDto> GetMovieById(int id)
        {
            var movie = await _movieRepository.GetMovieById(id);
            return _mapper.Map<GetMovieDto>(movie);
        }
    }
}
