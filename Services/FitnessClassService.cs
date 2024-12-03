using FitnessWorkoutMgmnt.Models;
using FitnessWorkoutMgmnt.Repository;

namespace FitnessWorkoutMgmnt.Services
{
    public class FitnessClassService : IFitnessClassService
    {
        private readonly IFitnessClassRepository _fitnessClassRepository;

        public FitnessClassService(IFitnessClassRepository fitnessClassRepository)
        {
            _fitnessClassRepository = fitnessClassRepository;
        }

        public async Task<FitnessClass> CreateFitnessClassAsync(FitnessClass fitnessClass)
        {
            return await _fitnessClassRepository.CreateFitnessClassAsync(fitnessClass);
        }

        public async Task<FitnessClass> GetFitnessClassByIdAsync(int id)
        {
            return await _fitnessClassRepository.GetFitnessClassByIdAsync(id);
        }

        public async Task<IEnumerable<FitnessClass>> GetAllFitnessClassesAsync()
        {
            return await _fitnessClassRepository.GetAllFitnessClassesAsync();
        }

        public async Task<FitnessClass> UpdateFitnessClassAsync(int id, FitnessClass fitnessClass)
        {
            return await _fitnessClassRepository.UpdateFitnessClassAsync(id, fitnessClass);
        }

        public async Task DeleteFitnessClassAsync(int id)
        {
            await _fitnessClassRepository.DeleteFitnessClassAsync(id);
        }
    }
}
