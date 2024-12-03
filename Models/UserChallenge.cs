namespace FitnessWorkoutMgmnt.Models
{
    public class UserChallenge
    {
        public int UserId { get; set; }
        public User? User { get; set; }

        public int ChallengeId { get; set; }
        public Challenge? Challenge { get; set; }
    }
}
