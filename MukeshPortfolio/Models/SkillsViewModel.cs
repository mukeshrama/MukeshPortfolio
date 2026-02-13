namespace MukeshPortfolio.Models
{
    public class SkillsViewModel
    {
        public string[] Skills { get; set; } = [];
        public Dictionary<string, string[]> SkillCategories { get; set; } = new();
    }
}
