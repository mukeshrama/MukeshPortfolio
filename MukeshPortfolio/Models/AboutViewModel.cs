namespace MukeshPortfolio.Models
{
    public class AboutViewModel
    {
        public Profile Profile { get; set; }
        public IEnumerable<WorkExperience> WorkExperience { get; set; } = Enumerable.Empty<WorkExperience>();
        public IEnumerable<Education> Education { get; set; } = Enumerable.Empty<Education>();
        public string[] Skills { get; set; } = [];
    }
}
