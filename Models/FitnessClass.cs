using FitnessWorkoutMgmnt.Models;

namespace FitnessWorkoutMgmnt.Models
{
    public class FitnessClass
    {
        public int ClassId { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }  // Yoga, Pilates, etc.
        public int TrainerId { get; set; }
        public User? Trainer { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
        public DateTime ScheduledTime { get; set; }
        public string? Location { get; set; }
        public int MaximumCapacity { get; set; }
    }
}
