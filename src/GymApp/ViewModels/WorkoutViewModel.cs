using System.ComponentModel.DataAnnotations;
using GymApp.Models.Enums;

namespace GymApp.ViewModels
{
    public class WorkoutViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        public int Reps { get; set; }
        public int Pause { get; set; }
        [Required]
        public WorkoutType Type { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public int Series { get; set; }
        [Required]
        public int Order { get; set; }
    }
}