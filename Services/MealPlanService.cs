using FitnessWorkoutMgmnt.Models;
using FitnessWorkoutMgmnt.Repository;

namespace FitnessWorkoutMgmnt.Services
{
    public class MealPlanService : IMealPlanService
    {
        private readonly IMealPlanRepository _mealPlanRepository;

        public MealPlanService(IMealPlanRepository mealPlanRepository)
        {
            _mealPlanRepository = mealPlanRepository;
        }

        public async Task<IEnumerable<MealPlan>> GetMealPlansByUserId(int userId)
        {
            return await _mealPlanRepository.GetMealPlansByUserId(userId);
        }

        public async Task<MealPlan> CreateMealPlan(MealPlan mealPlan)
        {
            return await _mealPlanRepository.AddMealPlan(mealPlan);
        }

        public async Task<MealPlan> ModifyMealPlan(MealPlan mealPlan)
        {
            return await _mealPlanRepository.UpdateMealPlan(mealPlan);
        }

        public async Task RemoveMealPlan(int mealPlanId)
        {
            await _mealPlanRepository.DeleteMealPlan(mealPlanId);
        }
    }
}
