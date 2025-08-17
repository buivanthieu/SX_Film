using WebBackend.Models;

namespace WebBackend.Repositories.Films
{
    public interface IFilmRepository
    {
        Task<ICollection<Film>> GetAllFilms();
        Task<Film?> GetFilmById(int id);
        Task AddFilm(Film film);
        Task UpdateFilm(Film film);
        Task DeleteFilm(int id);

        // Lấy phim theo actor, genre, tag, production company
        Task<ICollection<Film>> GetFilmsByActorId(int actorId);
        Task<ICollection<Film>> GetFilmsByGenreId(int genreId);
        Task<ICollection<Film>> GetFilmsByTagId(int tagId);
        Task<ICollection<Film>> GetFilmsByProductionComanyId(int productionComanyId);

        // Tìm kiếm phim
        Task<ICollection<Film>> SearchFilm(string searchTerm);

        // Phim đã bookmark của user
        Task<ICollection<Film>> GetFilmsBookmarkByUserId(int userId);


        // Top phim
        Task<ICollection<Film>> GetTopViewed(int topCount);
        Task<ICollection<Film>> GetTopRated(int topCount);

        // Lọc theo năm hoặc ngôn ngữ
        Task<ICollection<Film>> GetFilmsByReleaseYear(int year);
        Task<ICollection<Film>> GetFilmsByLanguage(string language);

        // Phim mới thêm
        Task<ICollection<Film>> GetLatestFilms(int count);
    }
}
