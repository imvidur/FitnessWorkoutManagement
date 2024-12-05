using FitnessWorkoutMgmnt.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FitnessWorkoutMgmnt.Models
{
    public class Report
    {
        [Key]
         
        public int ReportId { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        public string? ReportType { get; set; }  // Workout, Nutrition
        public DateTime GeneratedDate { get; set; }
        public string? Data { get; set; }  // JSON or serialized data for report content
        public string? CreatedBy { get; set; }  // Admin, Trainer, etc.
    }
}
