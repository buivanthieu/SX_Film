using WebBackend.Models;

namespace WebBackend.Dtos.Users
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string DisplayName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;

        public UserRole Role { get; set; }

        public DateTime CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
