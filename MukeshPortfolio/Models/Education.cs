namespace MukeshPortfolio.Models
{
    public class Education
    {
        public int Id { get; set; }
        public string Degree { get; set; }
        public string Institution { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Grade { get; set; }
        public string? Specialization { get; set; }
        
        public bool IsCurrentlyStudying => EndDate == null;
        
        public string Duration 
        {
            get
            {
                var start = StartDate.ToString("yyyy");
                var end = EndDate?.ToString("yyyy") ?? "Present";
                return $"{start} - {end}";
            }
        }
    }
}
