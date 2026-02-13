namespace MukeshPortfolio.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Summary { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Location { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? GithubUrl { get; set; }
    }
}