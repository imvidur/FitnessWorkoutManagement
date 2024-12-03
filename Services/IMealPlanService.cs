using FitnessWorkoutMgmnt.Models;

namespace FitnessWorkoutMgmnt.Services
{
    public interface IMealPlanService
    {
        Task<IEnumerable<MealPlan>> GetMealPlansByUserId(int userId);
        Task<MealPlan> CreateMealPlan(MealPlan mealPlan);
        Task<MealPlan> ModifyMealPlan(MealPlan mealPlan);
        Task RemoveMealPlan(int mealPlanId);
    }
}
