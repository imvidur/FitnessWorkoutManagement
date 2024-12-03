using FitnessWorkoutMgmnt.Models;

namespace FitnessWorkoutMgmnt.Repository
{
    public interface IWorkoutCategoryRepository
    {
        Task<IEnumerable<WorkoutCategory>> GetAllCategoriesAsync();
        Task<WorkoutCategory> GetCategoryByIdAsync(int id);
        Task<WorkoutCategory> CreateCategoryAsync(WorkoutCategory category);
        Task<WorkoutCategory> UpdateCategoryAsync(int id, WorkoutCategory category);
        Task DeleteCategoryAsync(int id);
    }
}
