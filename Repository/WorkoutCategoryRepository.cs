using FitnessWorkoutMgmnt.Data;
using FitnessWorkoutMgmnt.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkoutMgmnt.Repository
{
    public class WorkoutCategoryRepository : IWorkoutCategoryRepository
    {
        private readonly FitnessDbContext _context;

        public WorkoutCategoryRepository(FitnessDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WorkoutCategory>> GetAllCategoriesAsync()
        {
            return await _context.WorkoutCategories.ToListAsync();
        }

        public async Task<WorkoutCategory> GetCategoryByIdAsync(int id)
        {
            return await _context.WorkoutCategories
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<WorkoutCategory> CreateCategoryAsync(WorkoutCategory category)
        {
            _context.WorkoutCategories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<WorkoutCategory> UpdateCategoryAsync(int id, WorkoutCategory category)
        {
            var existingCategory = await _context.WorkoutCategories.FindAsync(id);
            if (existingCategory == null) return null;

            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;

            await _context.SaveChangesAsync();
            return existingCategory;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.WorkoutCategories.FindAsync(id);
            if (category == null) return;

            _context.WorkoutCategories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
