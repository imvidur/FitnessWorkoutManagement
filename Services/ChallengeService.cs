using FitnessWorkoutMgmnt.Models;
using FitnessWorkoutMgmnt.Repository;

namespace FitnessWorkoutMgmnt.Services
{
    public class ChallengeService : IChallengeService
    {
        private readonly IChallengeRepository _challengeRepository;

        public ChallengeService(IChallengeRepository challengeRepository)
        {
            _challengeRepository = challengeRepository;
        }

        public async Task<IEnumerable<Challenge>> GetAllChallenges()
        {
            return await _challengeRepository.GetAllChallenges();
        }

        public async Task<Challenge> AddChallenge(Challenge challenge)
        {
            return await _challengeRepository.CreateChallenge(challenge);
        }

        public async Task<IEnumerable<Challenge>> GetUserChallenges(int userId)
        {
            return await _challengeRepository.GetChallengesForUser(userId);
        }

        public async Task<Challenge> UpdateChallenge(Challenge challenge)
        {
            return await _challengeRepository.UpdateChallenge(challenge);
        }
    }
}
