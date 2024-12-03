using FitnessWorkoutMgmnt.Models;

namespace FitnessWorkoutMgmnt.Services
{
    public interface IFitnessClassService
    {
        Task<FitnessClass> CreateFitnessClassAsync(FitnessClass fitnessClass);
        Task<FitnessClass> GetFitnessClassByIdAsync(int id);
        Task<IEnumerable<FitnessClass>> GetAllFitnessClassesAsync();
        Task<FitnessClass> UpdateFitnessClassAsync(int id, FitnessClass fitnessClass);
        Task DeleteFitnessClassAsync(int id);
    }
}
