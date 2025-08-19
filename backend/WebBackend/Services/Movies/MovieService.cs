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

    }
}
