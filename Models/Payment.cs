namespace FitnessWorkoutMgmnt.Models
{
    public class Payment
    {
        public int Id { get; set; } // Unique identifier for the payment
        public int UserId { get; set; } // The user who made the payment
        public int SubscriptionId { get; set; } // The subscription the payment is associated with
        public decimal Amount { get; set; } // The amount of the payment
        public DateTime PaymentDate { get; set; } // The date when the payment was made
        public string? PaymentMethod { get; set; } // The method of payment (e.g., Credit Card, PayPal, etc.)
        public string? PaymentStatus { get; set; } // Status of the payment (e.g., Pending, Completed, Failed)

        // Optionally, you can add navigation properties for User and Subscription entities if required.
        public User? User { get; set; }
        public Subscription? Subscription { get; set; }
    }
}
