using FitnessWorkoutMgmnt.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FitnessWorkoutMgmnt.Models
{
    public class Subscription
    {
        [Key]
         
        public int SubscriptionId { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
        public string? SubscriptionType { get; set; }  // e.g., Basic, Premium
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? PaymentStatus { get; set; }
    }
}
