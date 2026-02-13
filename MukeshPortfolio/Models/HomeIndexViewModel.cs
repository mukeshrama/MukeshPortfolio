namespace MukeshPortfolio.Models
{
    public class HomeIndexViewModel
    {
        public Profile Profile { get; set; }
        public IEnumerable<Project> Projects { get; set; } = Enumerable.Empty<Project>();
    }
}