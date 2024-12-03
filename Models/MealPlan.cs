using FitnessWorkoutMgmnt.Models;

namespace FitnessWorkoutMgmnt.Models
{
    public class MealPlan
    {
        public int MealPlanId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string? Day { get; set; }  // e.g., Monday, Tuesday
        public string? MealType { get; set; }  // Breakfast, Lunch, Dinner
        public int RecipeId { get; set; }
        public int Calories { get; set; }
    }
}
