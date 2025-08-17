﻿namespace WebBackend.Models
{
    public class FilmActor
    {
        public int FilmId { get; set; }
        public Film Film { get; set; } = null!;

        public int ActorId { get; set; }
        public Actor Actor { get; set; } = null!;

        public string RoleName { get; set; } = null!; 
    }

}
