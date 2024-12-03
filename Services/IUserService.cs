using FitnessWorkoutMgmnt.Models;

namespace FitnessWorkoutMgmnt.Services
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> UpdateUserAsync(int id, User user);
        Task DeleteUserAsync(int id);
    }
}
