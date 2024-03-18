using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlaceMyOrder.Domain.Entities;

namespace PlaceMyOrder.Infrastructure.Data
{
    public class MealTableConfiguration : IEntityTypeConfiguration<MealEntity>
    {
        public void Configure(EntityTypeBuilder<MealEntity> builder)
        {
            builder
            .ToTable("Meals");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Price).IsRequired();
            builder.Property(t => t.CourseId).IsRequired();


            builder
            .HasMany(meal => meal.Orders)
                .WithMany(order => order.Meals)
                .UsingEntity<OrderMealEntity>();
        }
    }
}
