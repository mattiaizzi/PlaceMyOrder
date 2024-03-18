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
                .ApplyConfiguration<UserEntity>(new UserTableConfiguration())
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

            // POPOLO TABELLA UTENTI
            var users = new List<UserEntity>
            {
                new UserEntity { Id=new Guid("C66A3950-F0A3-4015-673A-08DC4758C63E"), Email = "customer1@placemyorder.com", Name="Customer1", LastName="LastCustomer1", Password="$2a$11$/JlN5wxyJTFnYzsp1B62pOzToGGDkcbYLlklBivaR1GpqwtIi1NB6", RoleId=(int)Role.Customer},
                new UserEntity { Id = new Guid("49E6787D-0515-4062-8C6E-F51ACF91A45C"), Email = "customer2@placemyorder.com", Name="Customer2", LastName="LastCustomer2", Password= "$2a$11$/JlN5wxyJTFnYzsp1B62pOzToGGDkcbYLlklBivaR1GpqwtIi1NB6", RoleId=(int)Role.Customer},
                new UserEntity { Id=new Guid("5C6AEA35-3EAE-480D-673B-08DC4758C63E"), Email="admin@placemyorder.com", Name="Admin", LastName="LastAdmin", Password="$2a$11$/HJfRrqKz7ildPBxu2yt2OdNuhsoEugNkd6cyafDJtEKz7lKDrq.S", RoleId=(int)Role.Admin},
            };

            modelBuilder.Entity<UserEntity>().HasData(users);

            // POPOLO TABELLA PASTI
            var meals = new List<MealEntity>
            {
                new MealEntity { Id=new Guid("E9C0E768-032D-4C32-873F-02D4D7FFCBA9"), CourseId=(int)Course.First, Price=8, Name="Mezze Maniche alla Carbonara"},
                new MealEntity { Id=new Guid("166758F6-5182-4682-B3D6-8AD730188401"), CourseId=(int)Course.First, Price=8, Name="Bucatini all'Amatriciana"},
                new MealEntity { Id=new Guid("A82F285E-5DAB-47CE-9525-717C5E7E2DBA"), CourseId=(int)Course.First, Price=7.5, Name="Spaghetti alla Gricia"},
                new MealEntity { Id=new Guid("178526AA-8E82-40B2-BCAB-C0539D959300"), CourseId=(int)Course.First, Price=10, Name="Tortellini alla Boscaiola"},
                new MealEntity { Id=new Guid("D8B76814-48F0-4ECB-B832-2D62A8F17FAB"), CourseId=(int)Course.First, Price=9, Name="Lasagna"},

                new MealEntity { Id=new Guid("ECA33AE7-2513-4163-8740-C6C49AEB7F09"), CourseId=(int)Course.Main, Price=6.5, Name="Polpette della Nonna"},
                new MealEntity { Id=new Guid("DD92EDDF-1A4D-4366-81E8-B901539C77B7"), CourseId=(int)Course.Main, Price=12.5, Name="Tagliata di vitello con rucola, grana e pomodorini"},
                new MealEntity { Id=new Guid("86192E09-62CA-4F95-BEF7-12CFD08EB24B"), CourseId=(int)Course.Main, Price=14, Name="Arrosto misto"},
                new MealEntity { Id=new Guid("FB772FCD-07A5-4FD7-80E7-EA09D6C64F3D"), CourseId=(int)Course.Main, Price=12, Name="Pollo alla Cacciatora"},
                new MealEntity { Id=new Guid("E2062100-EB3C-4D0C-B1E5-0963DAE4563F"), CourseId=(int)Course.Main, Price=8, Name="Cotiche e fagioli"},

                new MealEntity { Id=new Guid("89C2AFD1-F00D-4E88-89DA-C481C19A82FC"), CourseId=(int)Course.Side, Price=3, Name="Insalata mista"},
                new MealEntity { Id=new Guid("D6877B30-38C6-43D0-AD32-F2A1696C4F3A"), CourseId=(int)Course.Side, Price=5, Name="Verdure grigliate"},
                new MealEntity { Id=new Guid("D2983CA1-201E-44CE-A1E4-3CE71E5F23EE"), CourseId=(int)Course.Side, Price=5, Name="Patate al forno"},
                new MealEntity { Id=new Guid("8F9923E0-528F-4C62-96C8-F8383BF1168F"), CourseId=(int)Course.Side, Price=4, Name="Chips di patate"},
                new MealEntity { Id=new Guid("8E3009C8-67B8-4008-9E8F-E8D5026600FE"), CourseId=(int)Course.Side, Price=6, Name="Verdure gratinate"},

                new MealEntity { Id=new Guid("656EF65A-6A48-4EA7-B078-6B5238B95E93"), CourseId=(int)Course.Dessert, Price=5, Name="Tiramisù"},
                new MealEntity { Id=new Guid("C052B5B7-F6B1-4E72-A344-6AF6F737C3A2"), CourseId=(int)Course.Dessert, Price=3, Name="Sorbetto al limone"},
                new MealEntity { Id=new Guid("0DEB52DC-2966-4BBC-84EF-ECED23D66EFE"), CourseId=(int)Course.Dessert, Price=4, Name="Crema Catalana"},
                new MealEntity { Id=new Guid("6D69E048-0627-4D3D-A780-AAF7099A575D"), CourseId=(int)Course.Dessert, Price=6, Name="Dolce della nonna"},
                new MealEntity { Id=new Guid("CC5EC2A9-0EDF-4CFE-B952-0BA8B18052B1"), CourseId=(int)Course.Dessert, Price=4, Name="Zuppa inglese"},
            };

            modelBuilder.Entity<MealEntity>().HasData(meals);


            // POPOLO TABELLA ORDINI
            var orders = new List<OrderEntity>
            {
                new OrderEntity { Id = new Guid("68EE84F6-6D10-454F-866D-15AE5544304A"), CreationDate=DateTime.Parse("12/12/2023 6:32:05 PM"), PostalCode="62100", City="Macerata", StreetNumber="20", Street="Via qualunque", CustomerId=new Guid("C66A3950-F0A3-4015-673A-08DC4758C63E")},
                new OrderEntity { Id = new Guid("3519D9CA-D66C-464F-B4C7-770C7096ED9D"), CreationDate=DateTime.Parse("10/11/2023 6:32:05 PM"), PostalCode="62100", City="Macerata", StreetNumber="20", Street="Via qualunque", CustomerId=new Guid("C66A3950-F0A3-4015-673A-08DC4758C63E")},
                new OrderEntity { Id = new Guid("A39B757C-CD87-4D54-A904-8F10B7BAC0B8"), CreationDate=DateTime.Parse("10/03/2024 6:32:05 PM"), PostalCode="62100", City="Macerata", StreetNumber="20", Street="Via qualunque", CustomerId=new Guid("C66A3950-F0A3-4015-673A-08DC4758C63E")},
                new OrderEntity { Id = new Guid("D22634CF-C1DE-455A-B649-80F53056B318"), CreationDate=DateTime.Parse("5/3/2024 6:32:05 PM"), PostalCode="62100", City="Macerata", StreetNumber="20", Street="Via qualunque", CustomerId=new Guid("C66A3950-F0A3-4015-673A-08DC4758C63E")},
                new OrderEntity { Id = new Guid("153B7EC2-AC8E-4E5E-B6B3-48961ADB5089"), CreationDate=DateTime.Parse("16/3/2024 6:32:05 PM"), PostalCode="62100", City="Macerata", StreetNumber="20", Street="Via qualunque", CustomerId=new Guid("C66A3950-F0A3-4015-673A-08DC4758C63E")},
                new OrderEntity { Id = new Guid("A4EE7914-492B-49E1-8691-C364D1C604EA"), CreationDate=DateTime.Parse("21/2/2024 6:32:05 PM"), PostalCode="62100", City="Macerata", StreetNumber="20", Street="Via qualunque", CustomerId=new Guid("C66A3950-F0A3-4015-673A-08DC4758C63E")},
                new OrderEntity { Id = new Guid("54CEA234-2158-4843-9763-12880A2E9297"), CreationDate=DateTime.Parse("10/1/2024 6:32:05 PM"), PostalCode="62100", City="Macerata", StreetNumber="20", Street="Via qualunque", CustomerId=new Guid("C66A3950-F0A3-4015-673A-08DC4758C63E")},
                new OrderEntity { Id = new Guid("39C6C265-B927-4BA4-BCD9-3BE2CA01D9FB"), CreationDate=DateTime.Parse("3/1/2024 6:32:05 PM"), PostalCode="62100", City="Macerata", StreetNumber="20", Street="Via qualunque", CustomerId=new Guid("C66A3950-F0A3-4015-673A-08DC4758C63E")},
                new OrderEntity { Id = new Guid("49C4C24F-C63C-46F2-9906-EC8DCAB7BE2F"), CreationDate=DateTime.Parse("28/1/2023 6:32:05 PM"), PostalCode="62100", City="Macerata", StreetNumber="12", Street="Via qualunque", CustomerId=new Guid("49E6787D-0515-4062-8C6E-F51ACF91A45C")},
                new OrderEntity { Id = new Guid("FE192EB3-E95C-4481-B1D5-979ED5B9D57B"), CreationDate=DateTime.Parse("1/11/2023 6:32:05 PM"), PostalCode="62100", City="Macerata", StreetNumber="12", Street="Via qualunque", CustomerId=new Guid("49E6787D-0515-4062-8C6E-F51ACF91A45C")},
                new OrderEntity { Id = new Guid("47EA9E21-266B-418C-A127-5E4EA11CC85E"), CreationDate=DateTime.Parse("29/1/2024 6:32:05 PM"), PostalCode="62100", City="Macerata", StreetNumber="12", Street="Via qualunque", CustomerId=new Guid("49E6787D-0515-4062-8C6E-F51ACF91A45C")},
                new OrderEntity { Id = new Guid("0902143A-6FEC-4A01-9894-51708DACD4B2"), CreationDate=DateTime.Parse("7/1/2024 6:32:05 PM"), PostalCode="62100", City="Macerata", StreetNumber="12", Street="Via qualunque", CustomerId=new Guid("49E6787D-0515-4062-8C6E-F51ACF91A45C")},
                new OrderEntity { Id = new Guid("3AA347D2-8D17-4696-A6A5-DD577D96C6DD"), CreationDate=DateTime.Parse("14/2/2024 6:32:05 PM"), PostalCode="62100", City="Macerata", StreetNumber="12", Street="Via qualunque", CustomerId=new Guid("49E6787D-0515-4062-8C6E-F51ACF91A45C")},
                new OrderEntity { Id = new Guid("758E147C-990A-4796-B8B1-56F97A6A13EB"), CreationDate=DateTime.Parse("10/2/2024 6:32:05 PM"), PostalCode="62100", City="Macerata", StreetNumber="12", Street="Via qualunque", CustomerId=new Guid("49E6787D-0515-4062-8C6E-F51ACF91A45C")},
                new OrderEntity { Id = new Guid("55A67337-B6DD-4193-BF4A-5C8D3AD37EC4"), CreationDate=DateTime.Parse("3/2/2024 6:32:05 PM"), PostalCode="62100", City="Macerata", StreetNumber="12", Street="Via qualunque", CustomerId=new Guid("49E6787D-0515-4062-8C6E-F51ACF91A45C")},
                new OrderEntity { Id = new Guid("F418E182-D81A-4311-A6BF-EDF4CCA2D4EE"), CreationDate=DateTime.Parse("28/2/2024 6:32:05 PM"), PostalCode="62100", City="Macerata", StreetNumber="12", Street="Via qualunque", CustomerId=new Guid("49E6787D-0515-4062-8C6E-F51ACF91A45C")},
            };

            modelBuilder.Entity<OrderEntity>().HasData(orders);

            // POPOLO TABELLA CHE COLLEGA L'ORDINE CON IL PASTO
            var orderMeal = new List<OrderMealEntity>();
            Random rnd = new Random();
            foreach (var order in orders)
            {
                int mealsNumber = rnd.Next(1, 12);
                for (int i = 0; i < mealsNumber; i++)
                {
                    orderMeal.Add(new OrderMealEntity { Id = Guid.NewGuid(), OrderId = order.Id, MealId = meals.ElementAt(rnd.Next(0, meals.Count)).Id });
                }
                int month = rnd.Next(1, 13);
            }

            modelBuilder.Entity<OrderMealEntity>().HasData(orderMeal);

        }
    }
}
