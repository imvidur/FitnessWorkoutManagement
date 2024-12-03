using FitnessWorkoutMgmnt.Models;

namespace FitnessWorkoutMgmnt.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string ReportType { get; set; }  // Workout, Nutrition
        public DateTime GeneratedDate { get; set; }
        public string Data { get; set; }  // JSON or serialized data for report content
        public string CreatedBy { get; set; }  // Admin, Trainer, etc.
    }
}
