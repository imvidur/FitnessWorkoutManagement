using FitnessWorkoutMgmnt.Models;

namespace FitnessWorkoutMgmnt.Repository
{
    public interface IChallengeRepository
    {
        Task<IEnumerable<Challenge>> GetAllChallenges();
        Task<Challenge> CreateChallenge(Challenge challenge);
        Task<IEnumerable<Challenge>> GetChallengesForUser(int userId);
        Task<Challenge> UpdateChallenge(Challenge challenge);
    }
}
