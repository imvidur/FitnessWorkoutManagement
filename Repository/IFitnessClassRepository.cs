using FitnessWorkoutMgmnt.Models;

namespace FitnessWorkoutMgmnt.Repository
{
    public interface IFitnessClassRepository
    {
        Task<FitnessClass> CreateFitnessClassAsync(FitnessClass fitnessClass);
        Task<FitnessClass> GetFitnessClassByIdAsync(int id);
        Task<IEnumerable<FitnessClass>> GetAllFitnessClassesAsync();
        Task<FitnessClass> UpdateFitnessClassAsync(int id, FitnessClass fitnessClass);
        Task DeleteFitnessClassAsync(int id);
    }
}
