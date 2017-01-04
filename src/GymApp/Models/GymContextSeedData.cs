using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GymApp.Models.Enums;

namespace GymApp.Models
{
    public class GymContextSeedData
    {
        private GymContext _context;

        public GymContextSeedData(GymContext context)
        {
            _context = context;
        }

        public async Task EnsureSeedData()
        {
            if (!_context.Plans.Any())
            {
                var plan = new Plan()
                {
                    DaysDuration = 30,
                    Name = "Pecho",
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
