using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessWorkoutMgmnt.Models
{
    public class WorkoutCategory
    {
        [Key]
         
        public int Id { get; set; } 
        public string? Name { get; set; } 
        public string? Description { get; set; } 
        public ICollection<WorkoutPlan>? WorkoutPlans { get; set; }
    }
}
