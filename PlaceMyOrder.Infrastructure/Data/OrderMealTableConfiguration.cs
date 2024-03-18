using Azure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using PlaceMyOrder.Domain.Entities;

namespace PlaceMyOrder.Infrastructure.Data
{
    public class OrderMealTableConfiguration : IEntityTypeConfiguration<OrderMealEntity>
    {
        public void Configure(EntityTypeBuilder<OrderMealEntity> builder)
        {
            builder
                .ToTable("OrderMeal");

            builder
                .HasKey(o => o.Id);

            builder.Property(o => o.OrderId).IsRequired().HasColumnName("OrderId");
            builder.Property(o => o.MealId).IsRequired().HasColumnName("MealId");

            builder
                .HasOne(o => o.Meal)
                .WithMany()
                .HasForeignKey(o => o.MealId);

            builder
                .HasOne(o => o.Order)
                .WithMany()
                .HasForeignKey(o => o.OrderId);
        }
    }
}
