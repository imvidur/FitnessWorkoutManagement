using FitnessWorkoutMgmnt.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FitnessWorkoutMgmnt.Models
{
    public class WorkoutPlan
    {
        [Key]
         
        public int PlanId { get; set; }
        public string? Name { get; set; }
        public string? Goal { get; set; }  // e.g., Weight Loss, Muscle Gain
        public string? DifficultyLevel { get; set; }  // Beginner, Intermediate, Advanced
        public string? Description { get; set; }
        public int TrainerId { get; set; }
        [JsonIgnore]
        public User? Trainer { get; set; }
    }
}
