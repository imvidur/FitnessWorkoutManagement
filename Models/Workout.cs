using FitnessWorkoutMgmnt.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FitnessWorkoutMgmnt.Models
{
    public class Workout
    {
        [Key]
         
        public int WorkoutId { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        public int PlanId { get; set; }
        [JsonIgnore]
        public WorkoutPlan? Plan { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string? Status { get; set; }
        public TimeSpan ReminderTime { get; set; }
    }

}
