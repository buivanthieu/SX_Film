namespace WebBackend.Dtos.Actors
{
    public class UpdateActorDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ImageUrl { get; set; }
        public string? Country { get; set; }
    }
}
