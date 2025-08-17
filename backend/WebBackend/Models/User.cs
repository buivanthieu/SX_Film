namespace WebBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string DisplayName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;

        public UserRole Role { get; set; } = UserRole.User;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public ICollection<Report> Reports { get; set; } = new List<Report>();
        public ICollection<Bookmark> Bookmarks { get; set; } = new List<Bookmark>();
        public ICollection<BookmarkActor> BookmarkActors { get; set; } = new List<BookmarkActor>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public ICollection<SearchLog> SearchLogs { get; set; } = new List<SearchLog>();
        public ICollection<WatchHistory> WatchHistories { get; set; } = new List<WatchHistory>();
    }

    public enum UserRole
    {
        User,
        Admin,
        Moderator
    }

}
