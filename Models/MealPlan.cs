using FitnessWorkoutMgmnt.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FitnessWorkoutMgmnt.Models
{
    public class MealPlan
    {
        [Key]
 
        public int MealPlanId { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        public string? Day { get; set; }  // e.g., Monday, Tuesday
        public string? MealType { get; set; }  // Breakfast, Lunch, Dinner
        public int RecipeId { get; set; }
        public int Calories { get; set; }
    }
}
