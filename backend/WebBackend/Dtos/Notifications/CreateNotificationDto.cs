namespace WebBackend.Dtos.Notifications
{
    public class CreateNotificationDto
    {
        public int UserId { get; set; }
        public string Message { get; set; } = null!;
        public string? Link { get; set; }
        public bool? IsRead { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
