namespace FitnessWorkoutMgmnt.Models
{
    public class WorkoutCategory
    {
        public int Id { get; set; } // Unique identifier for the category
        public string? Name { get; set; } // Name of the workout category (e.g., "Strength Training")
        public string? Description { get; set; } // Description of the workout category

        // Optionally, you could add a navigation property for WorkoutPlans if you want to link them
        public ICollection<WorkoutPlan>? WorkoutPlans { get; set; }
    }
}
