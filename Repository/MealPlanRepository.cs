using FitnessWorkoutMgmnt.Data;
using FitnessWorkoutMgmnt.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkoutMgmnt.Repository
{
    public class MealPlanRepository : IMealPlanRepository
    {
        private readonly FitnessDbContext _context;

        public MealPlanRepository(FitnessDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MealPlan>> GetMealPlansByUserId(int userId)
        {
            return await _context.MealPlans.Where(mp => mp.UserId == userId).ToListAsync();
        }

        public async Task<MealPlan> AddMealPlan(MealPlan mealPlan)
        {
            _context.MealPlans.Add(mealPlan);
            await _context.SaveChangesAsync();
            return mealPlan;
        }

        public async Task<MealPlan> UpdateMealPlan(MealPlan mealPlan)
        {
            _context.MealPlans.Update(mealPlan);
            await _context.SaveChangesAsync();
            return mealPlan;
        }

        public async Task DeleteMealPlan(int mealPlanId)
        {
            var mealPlan = await _context.MealPlans.FindAsync(mealPlanId);
            if (mealPlan != null)
            {
                _context.MealPlans.Remove(mealPlan);
                await _context.SaveChangesAsync();
            }
        }
    }
}
