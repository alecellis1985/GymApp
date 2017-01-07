using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GymApp.Models;
using GymApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GymApp.Controllers.Api
{
    [Route("api/plans")]
    public class PlansController : Controller
    {
        private readonly IGymRepository _repository;
        private ILogger<PlansController> _logger;


        public PlansController(IGymRepository repository, ILogger<PlansController> logger)
        {
            _repository = repository;
            _logger = logger;
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
                _logger.LogError("Failed to get plans:{0}", ex);
            }
            return BadRequest("Error ocurred");
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]PlanViewModel plan)
        {
            try
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
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save plan:{0}", ex);
            }

            return BadRequest("Failed to save the plan");
        }
    }
}
