using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GymApp.Models;

namespace GymApp.Migrations
{
    [DbContext(typeof(GymContext))]
    partial class GymContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GymApp.Models.Plan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DaysDuration");

                    b.Property<string>("Name");

                    b.Property<bool>("Private");

                    b.HasKey("Id");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("GymApp.Models.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Duration");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<int>("Pause");

                    b.Property<int?>("PlanId");

                    b.Property<int>("Reps");

                    b.Property<int>("Series");

                    b.Property<int>("Type");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("GymApp.Models.Workout", b =>
                {
                    b.HasOne("GymApp.Models.Plan")
                        .WithMany("Workouts")
                        .HasForeignKey("PlanId");
                });
        }
    }
}
