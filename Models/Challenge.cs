using FitnessWorkoutMgmnt.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FitnessWorkoutMgmnt.Models
{
    public class Challenge
    {
        [Key]
        public int ChallengeId { get; set; }
        public string? Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        public string? Goal { get; set; }
        public string? Status { get; set; }  // Active, Completed

        public ICollection<UserChallenge>? UserChallenges { get; set; }
    }
}
