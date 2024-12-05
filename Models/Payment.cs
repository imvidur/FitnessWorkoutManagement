using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FitnessWorkoutMgmnt.Models
{
    public class Payment
    {
        [Key]
         
        public int Id { get; set; } 
        public int UserId { get; set; } 
        public int SubscriptionId { get; set; } 
        public decimal Amount { get; set; } 
        public DateTime PaymentDate { get; set; } 
        public string? PaymentMethod { get; set; } // The method of payment (e.g., Credit Card, PayPal, etc.)
        public string? PaymentStatus { get; set; } // Status of the payment (e.g., Pending, Completed, Failed)

        [JsonIgnore]
        public User? User { get; set; }
        [JsonIgnore]
        public Subscription? Subscription { get; set; }
    }
}
