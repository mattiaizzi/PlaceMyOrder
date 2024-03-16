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
using System.Reflection.Emit;

namespace PlaceMyOrder.Infrastructure.Data
{
    public class OrderTableConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder
            .ToTable("Orders");
            builder
            .HasMany(order => order.Meals)
                .WithMany(meal => meal.Orders)
                .UsingEntity<OrderMealEntity>();

            builder.Property(order => order.OrderNumber)
                .HasDefaultValueSql("NEXT VALUE FOR shared.OrderNumberSequence");
        }
    }
}