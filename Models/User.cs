using FitnessWorkoutMgmnt.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FitnessWorkoutMgmnt.Models
{
    public class User
    {
        [Key]
         
        public int UserId { get; set; }
        [Required]
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? Role { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; }

        // Navigation properties

        [JsonIgnore]
        public ICollection<Workout>? Workouts { get; set; }
        public ICollection<Message>? SentMessages { get; set; }
        public ICollection<Message>? ReceivedMessages { get; set; }
        public ICollection<Report>? Reports { get; set; }
        public ICollection<ProgressTracking>? ProgressTrackings { get; set; }
        public ICollection<MealPlan>? MealPlans { get; set; }
        public ICollection<FitnessClass>? ClassesAsTrainer { get; set; } = new List<FitnessClass>();
        public ICollection<FitnessClass>? ClassesAsUser { get; set; } = new List<FitnessClass>();

        public ICollection<UserChallenge>? UserChallenges { get; set; }
        public ICollection<Challenge>? Challenges { get; set; }
    }
}
