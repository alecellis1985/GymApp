using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Semantics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GymApp.Models
{
    public class GymRepository : IGymRepository
    {
        private readonly GymContext _context;
        private readonly ILogger<GymRepository> _logger;

        public GymRepository(GymContext context, ILogger<GymRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Plan> GetAllPlans()
        {
            _logger.LogInformation("Get All Plans and Workouts");
            return _context.Plans.Include(x => x.Workouts).ToList();
        }

        public void AddPlan(Plan plan)
        {
            _context.Plans.Add(plan);
            _logger.LogInformation("Plan was added");
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public Plan GetPlanWorkouts(int planId)
        {
            return _context.Plans.Where(x => x.Id == planId)
                .Include(x => x.Workouts).FirstOrDefault();
        }

        public void AddWorkout(int planId, Workout workout)
        {
            var plan = GetPlanWorkouts(planId);
            if (plan != null)
            {
                plan.Workouts.Add(workout);//foreign key is being set
                _context.Workouts.Add(workout);//here it's being added as a new obj
            }
        }

        public void AddWorkouts(int planId, List<Workout> workouts)
        {
            throw new NotImplementedException();
        }
    }
}
