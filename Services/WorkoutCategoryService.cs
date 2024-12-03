using FitnessWorkoutMgmnt.Models;
using FitnessWorkoutMgmnt.Repository;

namespace FitnessWorkoutMgmnt.Services
{
    public class WorkoutCategoryService : IWorkoutCategoryService
    {
        private readonly IWorkoutCategoryRepository _repository;

        public WorkoutCategoryService(IWorkoutCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<WorkoutCategory>> GetAllCategoriesAsync()
        {
            return await _repository.GetAllCategoriesAsync();
        }

        public async Task<WorkoutCategory> GetCategoryByIdAsync(int id)
        {
            return await _repository.GetCategoryByIdAsync(id);
        }

        public async Task<WorkoutCategory> CreateCategoryAsync(WorkoutCategory category)
        {
            return await _repository.CreateCategoryAsync(category);
        }

        public async Task<WorkoutCategory> UpdateCategoryAsync(int id, WorkoutCategory category)
        {
            return await _repository.UpdateCategoryAsync(id, category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _repository.DeleteCategoryAsync(id);
        }
    }
}
