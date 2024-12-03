using FitnessWorkoutMgmnt.Models;
using System.Threading.Tasks;

namespace FitnessWorkoutMgmnt.Repository
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> UpdateUserAsync(int id, User user);
        Task DeleteUserAsync(int id);
    }
}
