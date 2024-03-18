using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlaceMyOrder.Domain.Entities;

namespace PlaceMyOrder.Infrastructure.Data
{
    public class UserTableConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder
            .ToTable("Users");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Email).IsRequired();
            builder.HasIndex(t => t.Email).IsUnique();
            builder.Property(t => t.LastName).IsRequired();
            builder.Property(t => t.RoleId).IsRequired();
        }
    }
}
