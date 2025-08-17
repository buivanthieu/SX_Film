namespace WebBackend.Models
{
    public class ProductionCompany
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Country { get; set; }
        public string? LogoUrl { get; set; }

        public ICollection<Film> Films { get; set; } = new List<Film>();
    }
}
