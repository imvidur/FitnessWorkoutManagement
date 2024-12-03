using FitnessWorkoutMgmnt.Models;

namespace FitnessWorkoutMgmnt.Services
{
    public interface IWorkoutCategoryService
    {
        Task<IEnumerable<WorkoutCategory>> GetAllCategoriesAsync();
        Task<WorkoutCategory> GetCategoryByIdAsync(int id);
        Task<WorkoutCategory> CreateCategoryAsync(WorkoutCategory category);
        Task<WorkoutCategory> UpdateCategoryAsync(int id, WorkoutCategory category);
        Task DeleteCategoryAsync(int id);
    }
}
