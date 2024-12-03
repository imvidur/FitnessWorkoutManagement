using FitnessWorkoutMgmnt.Data;
using FitnessWorkoutMgmnt.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkoutMgmnt.Repository
{
    public class FitnessClassRepository : IFitnessClassRepository
    {
        private readonly FitnessDbContext _context;

        public FitnessClassRepository(FitnessDbContext context)
        {
            _context = context;
        }

        public async Task<FitnessClass> CreateFitnessClassAsync(FitnessClass fitnessClass)
        {
            _context.FitnessClass.Add(fitnessClass);
            await _context.SaveChangesAsync();
            return fitnessClass;
        }

        public async Task<FitnessClass> GetFitnessClassByIdAsync(int id)
        {
            return await _context.FitnessClass.FirstOrDefaultAsync(f => f.ClassId == id);
        }

        public async Task<IEnumerable<FitnessClass>> GetAllFitnessClassesAsync()
        {
            return await _context.FitnessClass.ToListAsync();
        }

        public async Task<FitnessClass> UpdateFitnessClassAsync(int id, FitnessClass fitnessClass)
        {
            var existingClass = await GetFitnessClassByIdAsync(id);
            if (existingClass == null)
                return null;

            existingClass.Name = fitnessClass.Name;
            existingClass.Category = fitnessClass.Category;
            existingClass.Location = fitnessClass.Location;
            existingClass.MaximumCapacity = fitnessClass.MaximumCapacity;
            // Update other fields

            await _context.SaveChangesAsync();
            return existingClass;
        }

        public async Task DeleteFitnessClassAsync(int id)
        {
            var fitnessClass = await GetFitnessClassByIdAsync(id);
            if (fitnessClass != null)
            {
                _context.FitnessClass.Remove(fitnessClass);
                await _context.SaveChangesAsync();
            }
        }
    }
}
