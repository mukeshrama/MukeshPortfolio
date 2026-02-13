namespace MukeshPortfolio.Models
{
    public class Project
    {
        public int Id { get; set; }          
        public string Title { get; set; }    
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? RepoUrl { get; set; }
        public string? LiveUrl { get; set; }
        public string[] Tags { get; set; } = [];
        public DateTime CreatedAt { get; set; }
    }
}