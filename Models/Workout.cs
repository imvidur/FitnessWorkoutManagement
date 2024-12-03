using FitnessWorkoutMgmnt.Models;

namespace FitnessWorkoutMgmnt.Models
{
    public class Workout
    {
        public int WorkoutId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PlanId { get; set; }
        public WorkoutPlan Plan { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string Status { get; set; }
        public TimeSpan ReminderTime { get; set; }
    }

}
