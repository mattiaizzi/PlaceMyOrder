using Azure;
using Microsoft.EntityFrameworkCore;
using PlaceMyOrder.Core.Model;
using PlaceMyOrder.Domain.Entities;
using PlaceMyOrder.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PlaceMyOrder.Infrastructure.Data
{
    public class PlaceMyOrderDbContext : DbContext
    {
        public PlaceMyOrderDbContext(DbContextOptions<PlaceMyOrderDbContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<TokenEntity> Tokens { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<MealEntity> Meals { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }

        public DbSet<OrderMealEntity> OrderMeal { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("OrderNumberSequence", schema: "shared").StartsAt(1).IncrementsBy(1);

            modelBuilder
                .ApplyConfiguration<OrderEntity>(new OrderTableConfiguration())
                .ApplyConfiguration<MealEntity>(new MealTableConfiguration())
                .ApplyConfiguration<OrderMealEntity>(new OrderMealTableConfiguration());

            base.OnModelCreating(modelBuilder);

            // POPOLO TABELLA DEI RUOLI
            var roles = from Role role in Enum.GetValues(typeof(Role))
                        select new RoleEntity { Id = (int)role, Name = role.ToString(), Description = EnumUtils.GetEnumDescription(role) };

            modelBuilder.Entity<RoleEntity>().HasData(roles);

            // POPOLO TABELLA DELLE PORTATE
            var courses = from Course course in Enum.GetValues(typeof(Course))
                          select new RoleEntity { Id = (int)course, Name = course.ToString(), Description = EnumUtils.GetEnumDescription(course) };

            modelBuilder.Entity<CourseEntity>().HasData(courses);
        }
    }
}
