using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.ViewModels
{
    public class PlanViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }
        [Required]
        //[Range(Sy,"1", "28", "Max date is 28 days, min days is 1")]
        public int DaysDuration { get; set; }
    }
}
