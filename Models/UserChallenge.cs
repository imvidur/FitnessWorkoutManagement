using System.Text.Json.Serialization;

namespace FitnessWorkoutMgmnt.Models
{
    public class UserChallenge
    {
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }

        public int ChallengeId { get; set; }
        [JsonIgnore]
        public Challenge? Challenge { get; set; }
    }
}
