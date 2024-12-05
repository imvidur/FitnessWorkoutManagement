using FitnessWorkoutMgmnt.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FitnessWorkoutMgmnt.Models
{
    public class FitnessClass
    {
        [Key]
        public int ClassId { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }  // Yoga, Pilates, etc.
        public int TrainerId { get; set; }

        [JsonIgnore]
        public User? Trainer { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        public DateTime ScheduledTime { get; set; }
        public string? Location { get; set; }
        public int MaximumCapacity { get; set; }
    }
}
