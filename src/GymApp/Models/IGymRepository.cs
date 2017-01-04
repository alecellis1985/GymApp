using System.Collections.Generic;

namespace GymApp.Models
{
    public interface IGymRepository
    {
        IEnumerable<Plan> GetAllPlans();
    }
}