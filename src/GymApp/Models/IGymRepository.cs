using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymApp.Models
{
    public interface IGymRepository
    {
        IEnumerable<Plan> GetAllPlans();
        IEnumerable<Plan> GetPlansByUsername(string username);
        void AddPlan(Plan plan);

        Task<bool> SaveChangesAsync();

        Plan GetPlanWorkouts(int planId);
        //Workout GetWorkout(int id);
        void AddWorkout(string userName, int planId, Workout workout);
        void AddWorkouts(string userName, int planId, List<Workout> workouts);
    }
}