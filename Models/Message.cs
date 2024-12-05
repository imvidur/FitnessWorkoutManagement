using FitnessWorkoutMgmnt.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FitnessWorkoutMgmnt.Models
{
    public class Message
    {
        [Key]
       
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        [JsonIgnore]
        public User? Sender { get; set; }
        public int ReceiverId { get; set; }
        [JsonIgnore]
        public User? Receiver { get; set; }
        public DateTime DateSent { get; set; }
        public string MessageContent { get; set; }
        public string Status { get; set; }
    }

}
