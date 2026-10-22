
namespace JobTracker.MVC.Models
{
    public class JobApplication
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string JobRole { get; set; } = string.Empty;
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
