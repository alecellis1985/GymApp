using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymApp.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using GymApp.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace GymApp.Controllers.Api
{
    [Route("api/plans/{planId}/workouts")]
    [Authorize]
    public class WorkoutController : Controller
    {
        private readonly ILogger<WorkoutController> _logger;
        private readonly IGymRepository _repository;

        public WorkoutController(IGymRepository repository, ILogger<WorkoutController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        //public WorkoutViewModel GetWorkout(int workoutId)
        //{

        //}

        [HttpGet("")]
        public IActionResult Get(int planId)
        {
            try
            {
                var plan = _repository.GetPlanWorkouts(planId);

                return Ok(Mapper.Map<IEnumerable<WorkoutViewModel>>(plan.Workouts.OrderByDescending(x => x.Order).ToList()));
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to retrieve plan workouts:{0}", e);
            }

            return BadRequest("Failed to retrieve plan workouts");
        }

        [HttpPost]
        public async Task<IActionResult> Post(int planId, [FromBody]WorkoutViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newWorkout = Mapper.Map<Workout>(model);

                    _repository.AddWorkout(this.User.Identity.Name, planId, newWorkout);

                    if (await _repository.SaveChangesAsync())
                    {
                        return Created("api/plans/{planId}/workouts/{newWorkout.Id}",
                            Mapper.Map<WorkoutViewModel>(newWorkout));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save the workout:{ex}", ex);
            }

            return BadRequest("Failed to save the workout");
        }
    }
}
