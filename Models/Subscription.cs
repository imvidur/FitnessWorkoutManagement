using FitnessWorkoutMgmnt.Models;

namespace FitnessWorkoutMgmnt.Models
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string SubscriptionType { get; set; }  // e.g., Basic, Premium
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PaymentStatus { get; set; }
    }
}
