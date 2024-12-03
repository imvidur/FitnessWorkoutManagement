using FitnessWorkoutMgmnt.Models;

namespace FitnessWorkoutMgmnt.Models
{
    public class ProgressTracking
    {
        public int ProgressId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public float Weight { get; set; }
        public float BodyFatPercentage { get; set; }
        public float MuscleMass { get; set; }
        public string Notes { get; set; }
    }
}
