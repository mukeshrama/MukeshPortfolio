namespace MukeshPortfolio.Models
{
    public class WorkExperience
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Location { get; set; }
        public string[] Responsibilities { get; set; } = [];
        public string[] Technologies { get; set; } = [];
        
        public bool IsCurrentRole => EndDate == null;
        
        public string Duration 
        {
            get
            {
                var start = StartDate.ToString("MMM yyyy");
                var end = EndDate?.ToString("MMM yyyy") ?? "Present";
                return $"{start} - {end}";
            }
        }
    }
}
