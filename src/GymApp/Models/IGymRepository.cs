using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymApp.Models
{
    public interface IGymRepository
    {
        IEnumerable<Plan> GetAllPlans();
        void AddPlan(Plan plan);

        Task<bool> SaveChangesAsync();

        Plan GetPlanWorkouts(int planId);
        //Workout GetWorkout(int id);
        void AddWorkout(int planId, Workout workout);
        void AddWorkouts(int planId, List<Workout> workouts);
    }
}