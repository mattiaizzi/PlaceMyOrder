using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlaceMyOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Infrastructure.Data
{
    public class MealTableConfiguration : IEntityTypeConfiguration<MealEntity>
    {
        public void Configure(EntityTypeBuilder<MealEntity> builder)
        {
            builder
            .ToTable("Meals");
            builder
            .HasMany(meal => meal.Orders)
                .WithMany(order => order.Meals)
                .UsingEntity<OrderMealEntity>();
        }
    }
}
