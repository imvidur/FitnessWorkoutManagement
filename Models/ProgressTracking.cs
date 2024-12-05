using FitnessWorkoutMgmnt.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FitnessWorkoutMgmnt.Models
{
    public class ProgressTracking
    {
        [Key]
         
        public int ProgressId { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User?User { get; set; }
        public DateTime Date { get; set; }
        public float Weight { get; set; }
        public float BodyFatPercentage { get; set; }
        public float MuscleMass { get; set; }
        public string? Notes { get; set; }
    }
}
