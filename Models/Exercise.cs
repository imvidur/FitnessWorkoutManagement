using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessWorkoutMgmnt.Models
{
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }  // e.g., Cardio, Strength
        public string? Description { get; set; }
        public string? EquipmentRequired { get; set; }
        public string? VideoLink { get; set; }
    }
}
