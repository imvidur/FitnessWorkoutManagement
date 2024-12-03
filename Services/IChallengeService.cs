using FitnessWorkoutMgmnt.Models;

namespace FitnessWorkoutMgmnt.Services
{
    public interface IChallengeService
    {
        Task<IEnumerable<Challenge>> GetAllChallenges();
        Task<Challenge> AddChallenge(Challenge challenge);
        Task<IEnumerable<Challenge>> GetUserChallenges(int userId);
        Task<Challenge> UpdateChallenge(Challenge challenge);
    }
}
