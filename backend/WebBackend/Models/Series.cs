namespace WebBackend.Models
{
    public class Series : Film
    {
        public bool IsCompleted { get; set; } = false;
        public ICollection<Season> Seasons { get; set; } = new List<Season>();

    }
}
