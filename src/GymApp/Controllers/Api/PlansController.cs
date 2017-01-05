using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GymApp.Models;
using GymApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Controllers.Api
{
    [Route("api/plans")]
    public class PlansController : Controller
    {
        private readonly IGymRepository _repository;

        public PlansController(IGymRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("")]
        public IActionResult Get()
        {
            try
            {
                var results = _repository.GetAllPlans();

                return Ok(Mapper.Map<IEnumerable<PlanViewModel>>(results));
            }
            catch (Exception ex)
            {
                //Todo log error
                return BadRequest("Error ocurred");
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]PlanViewModel plan)
        {
            if (ModelState.IsValid)
            {
                var newPlan = Mapper.Map<Plan>(plan);
                _repository.AddPlan(newPlan);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/plan/{plan.Name}", Mapper.Map<PlanViewModel>(newPlan));
                }
            }
            return BadRequest("Failed to save the plan");
        }
    }
}
