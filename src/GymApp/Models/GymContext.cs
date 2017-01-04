using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GymApp.Models
{
    public class GymContext : DbContext
    {
        private readonly IConfigurationRoot _config;

        public GymContext(IConfigurationRoot config, DbContextOptions options) : base(options)
        {
            _config = config;
        }

        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Plan> Plans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:GymContextConnection"]);
        }

    }
}
