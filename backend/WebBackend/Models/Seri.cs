namespace WebBackend.Models
{
    public class Seri : Film
    {
        public ICollection<Season> Seasons { get; set; } = new List<Season>();

    }
}
