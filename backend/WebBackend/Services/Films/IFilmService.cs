using WebBackend.Dtos.Films;
using WebBackend.Dtos.Movies;

namespace WebBackend.Services.Films
{
    public interface IFilmService
    {
        Task<ICollection<GetFilmDto>> GetAllFilms();
        Task<GetFilmDto> GetFilmById(int id);
        Task<ICollection<GetFilmDto>> GetFilmsByGenreId(int genreId);
        Task<ICollection<GetFilmDto>> GetFilmsByTagId(int tagId);
        Task<ICollection<GetFilmDto>> SearchFilm(string searchTerm);
        
        
    }
}