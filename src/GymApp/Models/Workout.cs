using System;
using GymApp.Models.Enums;

namespace GymApp.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Reps { get; set; }
        public int Pause { get; set; }
        public WorkoutType Type { get; set; }
        public int Duration { get; set; }
        public int Series { get; set; }
        public int Order { get; set; }
    }
}