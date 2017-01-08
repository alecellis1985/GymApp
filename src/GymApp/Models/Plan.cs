using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymApp.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Private { get; set; }
        public int DaysDuration { get; set; }
        public string UserName { get; set; }
        public ICollection<Workout> Workouts { get; set; }
    }
}
