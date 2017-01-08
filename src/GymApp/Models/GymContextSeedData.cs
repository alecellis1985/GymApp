using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GymApp.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace GymApp.Models
{
    public class GymContextSeedData
    {
        private readonly GymContext _context;
        private readonly UserManager<GymUser> _userManager;
        private readonly ILogger<GymContextSeedData> _logger;

        public GymContextSeedData(GymContext context, UserManager<GymUser> userManager, ILogger<GymContextSeedData> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task EnsureSeedData()
        {
            if (await _userManager.FindByEmailAsync("alecellis1985@gmail.com") == null)
            {
                var user = new GymUser()
                {
                    UserName = "alec",
                    Email = "alecellis1985@gmail.com"
                };
                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
                if (!result.Succeeded)
                {
                    _logger.LogInformation("Could not insert ASPNET USER");
                }
            }


            if (!_context.Plans.Any())
            {
                var plan = new Plan()
                {
                    DaysDuration = 30,
                    Name = "Pecho",
                    UserName = "alecellis1985@gmail.com",
                    Private = false,
                    Workouts = new List<Workout>()
                    {
                        new Workout()
                        {
                            Duration = 5,Name = "Press Plano",Order = 0,Pause = 45,Reps = 8,Series = 4,Type = WorkoutType.Chest,Url = "www.ababa.com"
                        },
                        new Workout()
                        {
                            Duration = 5,Name = "Press Inclinado",Order = 1,Pause = 45,Reps = 8,Series = 4,Type = WorkoutType.Chest,Url = "www.ababa.com"
                        },
                        new Workout()
                        {
                            Duration = 5,Name = "Press Declinado",Order = 2,Pause = 45,Reps = 8,Series = 4,Type = WorkoutType.Chest,Url = "www.ababa.com"
                        },
                        new Workout()
                        {
                            Duration = 5,Name = "Apertura Plana",Order = 3,Pause = 45,Reps = 8,Series = 4,Type = WorkoutType.Chest,Url = "www.ababa.com"
                        },
                        new Workout()
                        {
                            Duration = 5,Name = "Apertura Inclinada",Order = 4,Pause = 45,Reps = 8,Series = 4,Type = WorkoutType.Chest,Url = "www.ababa.com"
                        }
                    }
                };

                _context.Plans.Add(plan);
                _context.Workouts.AddRange(plan.Workouts);


                var plan2 = new Plan()
                {
                    DaysDuration = 20,
                    Name = "Triceps",
                    UserName = "alecellis1985@gmail.com",
                    Private = false,
                    Workouts = new List<Workout>()
                    {
                        new Workout()
                        {
                            Duration = 5,Name = "Paralelas",Order = 0,Pause = 45,Reps = 8,Series = 4,Type = WorkoutType.Triceps,Url = "www.ababa.com"
                        },
                        new Workout()
                        {
                            Duration = 5,Name = "Press Frances",Order = 1,Pause = 45,Reps = 8,Series = 4,Type = WorkoutType.Triceps,Url = "www.ababa.com"
                        },
                        new Workout()
                        {
                            Duration = 5,Name = "Polea",Order = 2,Pause = 45,Reps = 8,Series = 4,Type = WorkoutType.Triceps,Url = "www.ababa.com"
                        },
                        new Workout()
                        {
                            Duration = 5,Name = "Patada de burro",Order = 3,Pause = 45,Reps = 8,Series = 4,Type = WorkoutType.Triceps,Url = "www.ababa.com"
                        }
                    }
                };

                _context.Plans.Add(plan2);
                _context.Workouts.AddRange(plan2.Workouts);

                await _context.SaveChangesAsync();
            }
        }
    }
}
