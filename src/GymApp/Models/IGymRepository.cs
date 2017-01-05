using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymApp.Models
{
    public interface IGymRepository
    {
        IEnumerable<Plan> GetAllPlans();
        void AddPlan(Plan plan);
        Task<bool> SaveChangesAsync();
    }
}