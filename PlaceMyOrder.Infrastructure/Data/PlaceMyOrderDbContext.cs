using Microsoft.EntityFrameworkCore;
using PlaceMyOrder.Core.Model;
using PlaceMyOrder.Domain.Entities;
using PlaceMyOrder.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceMyOrder.Infrastructure.Data
{
    public class PlaceMyOrderDbContext : DbContext
    {
        public PlaceMyOrderDbContext(DbContextOptions<PlaceMyOrderDbContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var roles = from Role role in Enum.GetValues(typeof(Role))
                        select new RoleEntity { Id = (int)role, Name = role.ToString(), Description = EnumUtils.GetEnumDescription(role) }; ;

            modelBuilder.Entity<RoleEntity>().HasData(roles);
        }
    }
}
