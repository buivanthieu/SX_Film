namespace WebBackend.Models
{
    public class Film
    {
        public int Id { get; set; }

        // Thông tin chính
        public string Title { get; set; } = null!;
        public string? OriginalTitle { get; set; }   
        public string Description { get; set; } = null!;  
        public string? Language { get; set; }       

        // Phân loại
        public int ReleaseYear { get; set; }
        public DateTime? ReleaseDate { get; set; }   
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public ICollection<FilmActor> FilmActors { get; set; } = new List<FilmActor>();
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
        public ICollection<ProductionCompany> ProductionCompanies { get; set; } = new List<ProductionCompany>();
        public string? Country { get; set; }

        // Media
        public string PosterUrl { get; set; } = null!;  
        public string? BannerUrl { get; set; }          
        public string? TrailerUrl { get; set; }         

        // Trạng thái
        public bool IsSeries { get; set; }               
        public bool IsCompleted { get; set; }          

        // Thống kê
        public int ViewCount { get; set; }               
        public double AverageRating { get; set; }       
        public int RatingCount { get; set; }          

        // Navigation
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public ICollection<Report> Reports { get; set; } = new List<Report>();
        public ICollection<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();
        public ICollection<WatchHistory> WatchHistories { get; set; } = new List<WatchHistory>();
    }

}
