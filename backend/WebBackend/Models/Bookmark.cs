﻿namespace WebBackend.Models
{
    public class Bookmark
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int FilmId { get; set; }
        public Film Film { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
