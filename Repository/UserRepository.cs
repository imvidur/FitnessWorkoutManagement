using FitnessWorkoutMgmnt.Data;
using FitnessWorkoutMgmnt.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkoutMgmnt.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly FitnessDbContext _context;

        public UserRepository(FitnessDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> UpdateUserAsync(int id, User user)
        {
            var existingUser = await GetUserByIdAsync(id);
            if (existingUser == null)
                return null;

            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            existingUser.PasswordHash = user.PasswordHash;
            existingUser.Role = user.Role;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.IsActive = user.IsActive;

            // Update other fields

            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await GetUserByIdAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
