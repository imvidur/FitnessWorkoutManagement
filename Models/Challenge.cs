using FitnessWorkoutMgmnt.Models;

namespace FitnessWorkoutMgmnt.Models
{
    public class Challenge
    {
        public int ChallengeId { get; set; }
        public string? Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string? Goal { get; set; }
        public string? Status { get; set; }  // Active, Completed

        public ICollection<UserChallenge>? UserChallenges { get; set; }
    }
}
