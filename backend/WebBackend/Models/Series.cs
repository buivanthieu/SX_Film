namespace WebBackend.Models
{
    public class Series : Film
    {
        public ICollection<Season> Seasons { get; set; } = new List<Season>();

    }
}
