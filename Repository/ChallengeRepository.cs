using FitnessWorkoutMgmnt.Data;
using FitnessWorkoutMgmnt.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkoutMgmnt.Repository
{
    public class ChallengeRepository : IChallengeRepository
    {
        private readonly FitnessDbContext _context;

        public ChallengeRepository(FitnessDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Challenge>> GetAllChallenges()
        {
            return await _context.Challenges.ToListAsync();
        }

        public async Task<Challenge> CreateChallenge(Challenge challenge)
        {
            _context.Challenges.Add(challenge);
            await _context.SaveChangesAsync();
            return challenge;
        }

        public async Task<IEnumerable<Challenge?>> GetChallengesForUser(int userId)
        {
            return await _context.UserChallenges
                                 .Where(uc => uc.UserId == userId)
                                 .Select(uc => uc.Challenge)
                                 .ToListAsync();
        }


        public async Task<Challenge> UpdateChallenge(Challenge challenge)
        {
            _context.Challenges.Update(challenge);
            await _context.SaveChangesAsync();
            return challenge;
        }
    }
}
