using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlaceMyOrder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Primo", "First" },
                    { 2, "Secondo", "Main" },
                    { 3, "Contorno", "Side" },
                    { 4, "Dolce", "Dessert" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Cliente", "Customer" },
                    { 2, "Amministratore", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "CourseId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0deb52dc-2966-4bbc-84ef-eced23d66efe"), 4, "Crema Catalana", 4.0 },
                    { new Guid("166758f6-5182-4682-b3d6-8ad730188401"), 1, "Bucatini all'Amatriciana", 8.0 },
                    { new Guid("178526aa-8e82-40b2-bcab-c0539d959300"), 1, "Tortellini alla Boscaiola", 10.0 },
                    { new Guid("656ef65a-6a48-4ea7-b078-6b5238b95e93"), 4, "Tiramisù", 5.0 },
                    { new Guid("6d69e048-0627-4d3d-a780-aaf7099a575d"), 4, "Dolce della nonna", 6.0 },
                    { new Guid("86192e09-62ca-4f95-bef7-12cfd08eb24b"), 2, "Arrosto misto", 14.0 },
                    { new Guid("89c2afd1-f00d-4e88-89da-c481c19a82fc"), 3, "Insalata mista", 3.0 },
                    { new Guid("8e3009c8-67b8-4008-9e8f-e8d5026600fe"), 3, "Verdure gratinate", 6.0 },
                    { new Guid("8f9923e0-528f-4c62-96c8-f8383bf1168f"), 3, "Chips di patate", 4.0 },
                    { new Guid("a82f285e-5dab-47ce-9525-717c5e7e2dba"), 1, "Spaghetti alla Gricia", 7.5 },
                    { new Guid("c052b5b7-f6b1-4e72-a344-6af6f737c3a2"), 4, "Sorbetto al limone", 3.0 },
                    { new Guid("cc5ec2a9-0edf-4cfe-b952-0ba8b18052b1"), 4, "Zuppa inglese", 4.0 },
                    { new Guid("d2983ca1-201e-44ce-a1e4-3ce71e5f23ee"), 3, "Patate al forno", 5.0 },
                    { new Guid("d6877b30-38c6-43d0-ad32-f2a1696c4f3a"), 3, "Verdure grigliate", 5.0 },
                    { new Guid("d8b76814-48f0-4ecb-b832-2d62a8f17fab"), 1, "Lasagna", 9.0 },
                    { new Guid("dd92eddf-1a4d-4366-81e8-b901539c77b7"), 2, "Tagliata di vitello con rucola, grana e pomodorini", 12.5 },
                    { new Guid("e2062100-eb3c-4d0c-b1e5-0963dae4563f"), 2, "Cotiche e fagioli", 8.0 },
                    { new Guid("e9c0e768-032d-4c32-873f-02d4d7ffcba9"), 1, "Mezze Maniche alla Carbonara", 8.0 },
                    { new Guid("eca33ae7-2513-4163-8740-c6c49aeb7f09"), 2, "Polpette della Nonna", 6.5 },
                    { new Guid("fb772fcd-07a5-4fd7-80e7-ea09d6c64f3d"), 2, "Pollo alla Cacciatora", 12.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "LastName", "Name", "Password", "RoleId" },
                values: new object[,]
                {
                    { new Guid("49e6787d-0515-4062-8c6e-f51acf91a45c"), "customer2@placemyorder.com", "LastCustomer2", "Customer2", "$2a$11$/JlN5wxyJTFnYzsp1B62pOzToGGDkcbYLlklBivaR1GpqwtIi1NB6", 1 },
                    { new Guid("5c6aea35-3eae-480d-673b-08dc4758c63e"), "admin@placemyorder.com", "LastAdmin", "Admin", "$2a$11$/HJfRrqKz7ildPBxu2yt2OdNuhsoEugNkd6cyafDJtEKz7lKDrq.S", 2 },
                    { new Guid("c66a3950-f0a3-4015-673a-08dc4758c63e"), "customer1@placemyorder.com", "LastCustomer1", "Customer1", "$2a$11$/JlN5wxyJTFnYzsp1B62pOzToGGDkcbYLlklBivaR1GpqwtIi1NB6", 1 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "City", "CreationDate", "CustomerId", "PostalCode", "Street", "StreetNumber" },
                values: new object[,]
                {
                    { new Guid("0902143a-6fec-4a01-9894-51708dacd4b2"), "Macerata", new DateTime(2024, 1, 7, 18, 32, 5, 0, DateTimeKind.Unspecified), new Guid("49e6787d-0515-4062-8c6e-f51acf91a45c"), "62100", "Via qualunque", "12" },
                    { new Guid("153b7ec2-ac8e-4e5e-b6b3-48961adb5089"), "Macerata", new DateTime(2024, 3, 16, 18, 32, 5, 0, DateTimeKind.Unspecified), new Guid("c66a3950-f0a3-4015-673a-08dc4758c63e"), "62100", "Via qualunque", "20" },
                    { new Guid("3519d9ca-d66c-464f-b4c7-770c7096ed9d"), "Macerata", new DateTime(2023, 11, 10, 18, 32, 5, 0, DateTimeKind.Unspecified), new Guid("c66a3950-f0a3-4015-673a-08dc4758c63e"), "62100", "Via qualunque", "20" },
                    { new Guid("39c6c265-b927-4ba4-bcd9-3be2ca01d9fb"), "Macerata", new DateTime(2024, 1, 3, 18, 32, 5, 0, DateTimeKind.Unspecified), new Guid("c66a3950-f0a3-4015-673a-08dc4758c63e"), "62100", "Via qualunque", "20" },
                    { new Guid("3aa347d2-8d17-4696-a6a5-dd577d96c6dd"), "Macerata", new DateTime(2024, 2, 14, 18, 32, 5, 0, DateTimeKind.Unspecified), new Guid("49e6787d-0515-4062-8c6e-f51acf91a45c"), "62100", "Via qualunque", "12" },
                    { new Guid("47ea9e21-266b-418c-a127-5e4ea11cc85e"), "Macerata", new DateTime(2024, 1, 29, 18, 32, 5, 0, DateTimeKind.Unspecified), new Guid("49e6787d-0515-4062-8c6e-f51acf91a45c"), "62100", "Via qualunque", "12" },
                    { new Guid("49c4c24f-c63c-46f2-9906-ec8dcab7be2f"), "Macerata", new DateTime(2023, 1, 28, 18, 32, 5, 0, DateTimeKind.Unspecified), new Guid("49e6787d-0515-4062-8c6e-f51acf91a45c"), "62100", "Via qualunque", "12" },
                    { new Guid("54cea234-2158-4843-9763-12880a2e9297"), "Macerata", new DateTime(2024, 1, 10, 18, 32, 5, 0, DateTimeKind.Unspecified), new Guid("c66a3950-f0a3-4015-673a-08dc4758c63e"), "62100", "Via qualunque", "20" },
                    { new Guid("55a67337-b6dd-4193-bf4a-5c8d3ad37ec4"), "Macerata", new DateTime(2024, 2, 3, 18, 32, 5, 0, DateTimeKind.Unspecified), new Guid("49e6787d-0515-4062-8c6e-f51acf91a45c"), "62100", "Via qualunque", "12" },
                    { new Guid("68ee84f6-6d10-454f-866d-15ae5544304a"), "Macerata", new DateTime(2023, 12, 12, 18, 32, 5, 0, DateTimeKind.Unspecified), new Guid("c66a3950-f0a3-4015-673a-08dc4758c63e"), "62100", "Via qualunque", "20" },
                    { new Guid("758e147c-990a-4796-b8b1-56f97a6a13eb"), "Macerata", new DateTime(2024, 2, 10, 18, 32, 5, 0, DateTimeKind.Unspecified), new Guid("49e6787d-0515-4062-8c6e-f51acf91a45c"), "62100", "Via qualunque", "12" },
                    { new Guid("a39b757c-cd87-4d54-a904-8f10b7bac0b8"), "Macerata", new DateTime(2024, 3, 10, 18, 32, 5, 0, DateTimeKind.Unspecified), new Guid("c66a3950-f0a3-4015-673a-08dc4758c63e"), "62100", "Via qualunque", "20" },
                    { new Guid("a4ee7914-492b-49e1-8691-c364d1c604ea"), "Macerata", new DateTime(2024, 2, 21, 18, 32, 5, 0, DateTimeKind.Unspecified), new Guid("c66a3950-f0a3-4015-673a-08dc4758c63e"), "62100", "Via qualunque", "20" },
                    { new Guid("d22634cf-c1de-455a-b649-80f53056b318"), "Macerata", new DateTime(2024, 3, 5, 18, 32, 5, 0, DateTimeKind.Unspecified), new Guid("c66a3950-f0a3-4015-673a-08dc4758c63e"), "62100", "Via qualunque", "20" },
                    { new Guid("f418e182-d81a-4311-a6bf-edf4cca2d4ee"), "Macerata", new DateTime(2024, 2, 28, 18, 32, 5, 0, DateTimeKind.Unspecified), new Guid("49e6787d-0515-4062-8c6e-f51acf91a45c"), "62100", "Via qualunque", "12" },
                    { new Guid("fe192eb3-e95c-4481-b1d5-979ed5b9d57b"), "Macerata", new DateTime(2023, 11, 1, 18, 32, 5, 0, DateTimeKind.Unspecified), new Guid("49e6787d-0515-4062-8c6e-f51acf91a45c"), "62100", "Via qualunque", "12" }
                });

            migrationBuilder.InsertData(
                table: "OrderMeal",
                columns: new[] { "Id", "MealEntityId", "MealId", "OrderEntityId", "OrderId" },
                values: new object[,]
                {
                    { new Guid("003fe415-f100-468f-91f9-8edc65a03207"), null, new Guid("178526aa-8e82-40b2-bcab-c0539d959300"), null, new Guid("49c4c24f-c63c-46f2-9906-ec8dcab7be2f") },
                    { new Guid("0151f289-aefd-4849-a797-c12c0a6871c2"), null, new Guid("a82f285e-5dab-47ce-9525-717c5e7e2dba"), null, new Guid("68ee84f6-6d10-454f-866d-15ae5544304a") },
                    { new Guid("023e2f24-b633-4c45-a6b2-16634e5c62f2"), null, new Guid("656ef65a-6a48-4ea7-b078-6b5238b95e93"), null, new Guid("f418e182-d81a-4311-a6bf-edf4cca2d4ee") },
                    { new Guid("051704b7-eb2f-4dec-81d0-f98e84454430"), null, new Guid("166758f6-5182-4682-b3d6-8ad730188401"), null, new Guid("3aa347d2-8d17-4696-a6a5-dd577d96c6dd") },
                    { new Guid("0a2b5e9b-1cb2-4b31-9d02-06645825ff1a"), null, new Guid("fb772fcd-07a5-4fd7-80e7-ea09d6c64f3d"), null, new Guid("153b7ec2-ac8e-4e5e-b6b3-48961adb5089") },
                    { new Guid("0b8b1716-7128-4744-946a-1fd492ba01ac"), null, new Guid("a82f285e-5dab-47ce-9525-717c5e7e2dba"), null, new Guid("39c6c265-b927-4ba4-bcd9-3be2ca01d9fb") },
                    { new Guid("0ce9ddc3-225e-4f49-9c2b-1af55c8950f3"), null, new Guid("86192e09-62ca-4f95-bef7-12cfd08eb24b"), null, new Guid("3aa347d2-8d17-4696-a6a5-dd577d96c6dd") },
                    { new Guid("0d09317d-6b56-499a-8a4f-70ab7a29fca7"), null, new Guid("166758f6-5182-4682-b3d6-8ad730188401"), null, new Guid("55a67337-b6dd-4193-bf4a-5c8d3ad37ec4") },
                    { new Guid("10147603-0be6-44de-afbf-f4ba7aefb4fd"), null, new Guid("89c2afd1-f00d-4e88-89da-c481c19a82fc"), null, new Guid("758e147c-990a-4796-b8b1-56f97a6a13eb") },
                    { new Guid("12fa877c-eab1-4a0a-9645-cb7ab82c4e1c"), null, new Guid("d6877b30-38c6-43d0-ad32-f2a1696c4f3a"), null, new Guid("47ea9e21-266b-418c-a127-5e4ea11cc85e") },
                    { new Guid("15d4c49a-2036-43c1-ad8c-dc009f33c01d"), null, new Guid("6d69e048-0627-4d3d-a780-aaf7099a575d"), null, new Guid("a39b757c-cd87-4d54-a904-8f10b7bac0b8") },
                    { new Guid("199e9c57-0e3b-442e-9adc-5300e0df9d8e"), null, new Guid("6d69e048-0627-4d3d-a780-aaf7099a575d"), null, new Guid("54cea234-2158-4843-9763-12880a2e9297") },
                    { new Guid("1a2048b3-a18f-4c6d-aeb4-4a8f74988c79"), null, new Guid("d8b76814-48f0-4ecb-b832-2d62a8f17fab"), null, new Guid("68ee84f6-6d10-454f-866d-15ae5544304a") },
                    { new Guid("1ddbe022-a455-41bd-bfd8-9737dd6205db"), null, new Guid("a82f285e-5dab-47ce-9525-717c5e7e2dba"), null, new Guid("a39b757c-cd87-4d54-a904-8f10b7bac0b8") },
                    { new Guid("1efdc434-ddcf-4baf-a8d7-6e3dc7199124"), null, new Guid("e2062100-eb3c-4d0c-b1e5-0963dae4563f"), null, new Guid("68ee84f6-6d10-454f-866d-15ae5544304a") },
                    { new Guid("223caf3c-9d29-4812-af40-51af00643292"), null, new Guid("d2983ca1-201e-44ce-a1e4-3ce71e5f23ee"), null, new Guid("3519d9ca-d66c-464f-b4c7-770c7096ed9d") },
                    { new Guid("254b03d0-9f35-4261-bd31-84a6a063639f"), null, new Guid("d2983ca1-201e-44ce-a1e4-3ce71e5f23ee"), null, new Guid("fe192eb3-e95c-4481-b1d5-979ed5b9d57b") },
                    { new Guid("296461d6-75a8-4bb5-bd42-60f28310f887"), null, new Guid("6d69e048-0627-4d3d-a780-aaf7099a575d"), null, new Guid("f418e182-d81a-4311-a6bf-edf4cca2d4ee") },
                    { new Guid("2ca04d07-28ba-4470-a3ac-5b72bdf5759c"), null, new Guid("6d69e048-0627-4d3d-a780-aaf7099a575d"), null, new Guid("a4ee7914-492b-49e1-8691-c364d1c604ea") },
                    { new Guid("2e65ee87-3d27-4c95-9a7b-8f2e8224679b"), null, new Guid("a82f285e-5dab-47ce-9525-717c5e7e2dba"), null, new Guid("fe192eb3-e95c-4481-b1d5-979ed5b9d57b") },
                    { new Guid("2f27af72-69df-4079-ac68-e49786f1a17e"), null, new Guid("a82f285e-5dab-47ce-9525-717c5e7e2dba"), null, new Guid("d22634cf-c1de-455a-b649-80f53056b318") },
                    { new Guid("316d9957-3daf-4c6f-8c5e-c7e6ab470903"), null, new Guid("166758f6-5182-4682-b3d6-8ad730188401"), null, new Guid("a39b757c-cd87-4d54-a904-8f10b7bac0b8") },
                    { new Guid("35143e3d-e164-4ea8-a08b-960171e4ffac"), null, new Guid("e9c0e768-032d-4c32-873f-02d4d7ffcba9"), null, new Guid("47ea9e21-266b-418c-a127-5e4ea11cc85e") },
                    { new Guid("36597a04-1815-48e3-81b3-03c8b3a17c8a"), null, new Guid("fb772fcd-07a5-4fd7-80e7-ea09d6c64f3d"), null, new Guid("758e147c-990a-4796-b8b1-56f97a6a13eb") },
                    { new Guid("37515c46-2142-4188-a0e8-5a9bdff1a305"), null, new Guid("d2983ca1-201e-44ce-a1e4-3ce71e5f23ee"), null, new Guid("39c6c265-b927-4ba4-bcd9-3be2ca01d9fb") },
                    { new Guid("37969aa0-37e9-413e-8c4b-fa42538d1970"), null, new Guid("cc5ec2a9-0edf-4cfe-b952-0ba8b18052b1"), null, new Guid("54cea234-2158-4843-9763-12880a2e9297") },
                    { new Guid("3832ed03-ff7c-4896-b045-fde75626e50c"), null, new Guid("e9c0e768-032d-4c32-873f-02d4d7ffcba9"), null, new Guid("47ea9e21-266b-418c-a127-5e4ea11cc85e") },
                    { new Guid("3cd6b71d-36cc-42f9-a81f-32fecbe39bc5"), null, new Guid("178526aa-8e82-40b2-bcab-c0539d959300"), null, new Guid("a39b757c-cd87-4d54-a904-8f10b7bac0b8") },
                    { new Guid("3e6e11cf-0a33-4a9c-a010-c8acd363e350"), null, new Guid("e9c0e768-032d-4c32-873f-02d4d7ffcba9"), null, new Guid("758e147c-990a-4796-b8b1-56f97a6a13eb") },
                    { new Guid("3e75d41b-ff95-44c5-9b8e-3d09ba34f5a4"), null, new Guid("a82f285e-5dab-47ce-9525-717c5e7e2dba"), null, new Guid("49c4c24f-c63c-46f2-9906-ec8dcab7be2f") },
                    { new Guid("409371b5-85de-47f7-9bed-2cb660fe3be1"), null, new Guid("dd92eddf-1a4d-4366-81e8-b901539c77b7"), null, new Guid("49c4c24f-c63c-46f2-9906-ec8dcab7be2f") },
                    { new Guid("41551d37-9050-495c-8ac8-7cc69f59521e"), null, new Guid("d2983ca1-201e-44ce-a1e4-3ce71e5f23ee"), null, new Guid("a4ee7914-492b-49e1-8691-c364d1c604ea") },
                    { new Guid("44d064ac-7e47-4b77-b5db-1243add4c6ef"), null, new Guid("166758f6-5182-4682-b3d6-8ad730188401"), null, new Guid("fe192eb3-e95c-4481-b1d5-979ed5b9d57b") },
                    { new Guid("44d650ea-1df0-479f-b57c-a18bbcb50441"), null, new Guid("a82f285e-5dab-47ce-9525-717c5e7e2dba"), null, new Guid("a39b757c-cd87-4d54-a904-8f10b7bac0b8") },
                    { new Guid("490b0948-19ad-4af5-8d2e-6e3a2e41d25f"), null, new Guid("c052b5b7-f6b1-4e72-a344-6af6f737c3a2"), null, new Guid("3aa347d2-8d17-4696-a6a5-dd577d96c6dd") },
                    { new Guid("4b971fb4-a84f-4ce5-83e9-74f7a01a3391"), null, new Guid("166758f6-5182-4682-b3d6-8ad730188401"), null, new Guid("153b7ec2-ac8e-4e5e-b6b3-48961adb5089") },
                    { new Guid("4eb178f5-91f4-459c-84a0-cc217eb0abee"), null, new Guid("86192e09-62ca-4f95-bef7-12cfd08eb24b"), null, new Guid("f418e182-d81a-4311-a6bf-edf4cca2d4ee") },
                    { new Guid("4f26b86a-2bb6-43b1-a5dd-ca9b6187a97b"), null, new Guid("656ef65a-6a48-4ea7-b078-6b5238b95e93"), null, new Guid("39c6c265-b927-4ba4-bcd9-3be2ca01d9fb") },
                    { new Guid("5740809d-5759-44e4-8e56-d4d549cacb36"), null, new Guid("fb772fcd-07a5-4fd7-80e7-ea09d6c64f3d"), null, new Guid("a39b757c-cd87-4d54-a904-8f10b7bac0b8") },
                    { new Guid("5a228dea-9797-422e-ab46-6513f1ef9b00"), null, new Guid("89c2afd1-f00d-4e88-89da-c481c19a82fc"), null, new Guid("a39b757c-cd87-4d54-a904-8f10b7bac0b8") },
                    { new Guid("5f9f49dc-8afb-4787-8eb0-3f1b8dbe1476"), null, new Guid("d8b76814-48f0-4ecb-b832-2d62a8f17fab"), null, new Guid("f418e182-d81a-4311-a6bf-edf4cca2d4ee") },
                    { new Guid("60145281-512e-46ae-98d0-57b812f8541d"), null, new Guid("656ef65a-6a48-4ea7-b078-6b5238b95e93"), null, new Guid("153b7ec2-ac8e-4e5e-b6b3-48961adb5089") },
                    { new Guid("612c435f-d34e-478b-8b82-271365b116c6"), null, new Guid("dd92eddf-1a4d-4366-81e8-b901539c77b7"), null, new Guid("3aa347d2-8d17-4696-a6a5-dd577d96c6dd") },
                    { new Guid("66643bab-ab61-4879-a53f-15ffb09acf2d"), null, new Guid("cc5ec2a9-0edf-4cfe-b952-0ba8b18052b1"), null, new Guid("fe192eb3-e95c-4481-b1d5-979ed5b9d57b") },
                    { new Guid("67c21979-723f-49cf-bd3d-95657c1e1430"), null, new Guid("fb772fcd-07a5-4fd7-80e7-ea09d6c64f3d"), null, new Guid("a4ee7914-492b-49e1-8691-c364d1c604ea") },
                    { new Guid("682b38d0-57d9-4f02-aabb-a2894927b314"), null, new Guid("0deb52dc-2966-4bbc-84ef-eced23d66efe"), null, new Guid("47ea9e21-266b-418c-a127-5e4ea11cc85e") },
                    { new Guid("6d329f5e-d578-458c-b193-6b845a6956a8"), null, new Guid("6d69e048-0627-4d3d-a780-aaf7099a575d"), null, new Guid("f418e182-d81a-4311-a6bf-edf4cca2d4ee") },
                    { new Guid("6d8364d4-2aaf-4cfc-bc11-38b86c864c23"), null, new Guid("0deb52dc-2966-4bbc-84ef-eced23d66efe"), null, new Guid("a4ee7914-492b-49e1-8691-c364d1c604ea") },
                    { new Guid("6e5b7d23-bc64-4ff3-b733-b4fa4342d0bc"), null, new Guid("6d69e048-0627-4d3d-a780-aaf7099a575d"), null, new Guid("68ee84f6-6d10-454f-866d-15ae5544304a") },
                    { new Guid("703e6cb3-4c5b-4494-8fd6-11d92fe668fb"), null, new Guid("dd92eddf-1a4d-4366-81e8-b901539c77b7"), null, new Guid("54cea234-2158-4843-9763-12880a2e9297") },
                    { new Guid("72fb53a6-2f1c-4cbf-b855-77a6a26bf16d"), null, new Guid("d8b76814-48f0-4ecb-b832-2d62a8f17fab"), null, new Guid("3aa347d2-8d17-4696-a6a5-dd577d96c6dd") },
                    { new Guid("7330d8fb-5a13-48e9-a7a4-3b4b565eb8ca"), null, new Guid("166758f6-5182-4682-b3d6-8ad730188401"), null, new Guid("54cea234-2158-4843-9763-12880a2e9297") },
                    { new Guid("75c6d102-9e22-41b1-94b4-67f2c2d77af1"), null, new Guid("166758f6-5182-4682-b3d6-8ad730188401"), null, new Guid("758e147c-990a-4796-b8b1-56f97a6a13eb") },
                    { new Guid("78f6f505-2935-4473-bb5d-c6c68ea5cc47"), null, new Guid("0deb52dc-2966-4bbc-84ef-eced23d66efe"), null, new Guid("f418e182-d81a-4311-a6bf-edf4cca2d4ee") },
                    { new Guid("81959782-b39c-4ca4-9be9-0a9b6f7799f7"), null, new Guid("e9c0e768-032d-4c32-873f-02d4d7ffcba9"), null, new Guid("3519d9ca-d66c-464f-b4c7-770c7096ed9d") },
                    { new Guid("831bb69e-ed36-49d9-94ef-bb74166a1edb"), null, new Guid("8f9923e0-528f-4c62-96c8-f8383bf1168f"), null, new Guid("47ea9e21-266b-418c-a127-5e4ea11cc85e") },
                    { new Guid("84d6bd5f-379e-4386-a332-c185b0c0dc4a"), null, new Guid("e2062100-eb3c-4d0c-b1e5-0963dae4563f"), null, new Guid("a4ee7914-492b-49e1-8691-c364d1c604ea") },
                    { new Guid("85d76a61-3ed3-4201-857f-349a7a7f49fe"), null, new Guid("6d69e048-0627-4d3d-a780-aaf7099a575d"), null, new Guid("a4ee7914-492b-49e1-8691-c364d1c604ea") },
                    { new Guid("8821cdf1-2ffb-4815-9806-f278cf86ecdb"), null, new Guid("8f9923e0-528f-4c62-96c8-f8383bf1168f"), null, new Guid("fe192eb3-e95c-4481-b1d5-979ed5b9d57b") },
                    { new Guid("89fcf5b6-7e6f-4c8c-82d2-1ec86e22bb7d"), null, new Guid("d2983ca1-201e-44ce-a1e4-3ce71e5f23ee"), null, new Guid("f418e182-d81a-4311-a6bf-edf4cca2d4ee") },
                    { new Guid("8aa9cf33-d16b-44b1-a021-f89c784f67d2"), null, new Guid("a82f285e-5dab-47ce-9525-717c5e7e2dba"), null, new Guid("54cea234-2158-4843-9763-12880a2e9297") },
                    { new Guid("92972bee-62c2-4d16-b24c-d12984568d3c"), null, new Guid("89c2afd1-f00d-4e88-89da-c481c19a82fc"), null, new Guid("49c4c24f-c63c-46f2-9906-ec8dcab7be2f") },
                    { new Guid("92e53390-f60d-49e4-b381-3274a002ecc0"), null, new Guid("0deb52dc-2966-4bbc-84ef-eced23d66efe"), null, new Guid("55a67337-b6dd-4193-bf4a-5c8d3ad37ec4") },
                    { new Guid("95bad3b1-5af9-4978-a78b-5f7f490e70fe"), null, new Guid("166758f6-5182-4682-b3d6-8ad730188401"), null, new Guid("fe192eb3-e95c-4481-b1d5-979ed5b9d57b") },
                    { new Guid("9631389b-aaaa-4034-b29a-179ea195895a"), null, new Guid("6d69e048-0627-4d3d-a780-aaf7099a575d"), null, new Guid("49c4c24f-c63c-46f2-9906-ec8dcab7be2f") },
                    { new Guid("9dfb8329-d828-445c-bc76-e1b937f45c44"), null, new Guid("86192e09-62ca-4f95-bef7-12cfd08eb24b"), null, new Guid("153b7ec2-ac8e-4e5e-b6b3-48961adb5089") },
                    { new Guid("9e07316f-a487-4392-9212-b8b72042d1d2"), null, new Guid("86192e09-62ca-4f95-bef7-12cfd08eb24b"), null, new Guid("55a67337-b6dd-4193-bf4a-5c8d3ad37ec4") },
                    { new Guid("9eb468a0-4830-424c-a395-97304a33b98c"), null, new Guid("8f9923e0-528f-4c62-96c8-f8383bf1168f"), null, new Guid("68ee84f6-6d10-454f-866d-15ae5544304a") },
                    { new Guid("9f1d44ea-d377-498e-990f-0801020f26df"), null, new Guid("8e3009c8-67b8-4008-9e8f-e8d5026600fe"), null, new Guid("f418e182-d81a-4311-a6bf-edf4cca2d4ee") },
                    { new Guid("a56dcfbe-63bb-452a-a48f-e70ec83a5e4e"), null, new Guid("eca33ae7-2513-4163-8740-c6c49aeb7f09"), null, new Guid("55a67337-b6dd-4193-bf4a-5c8d3ad37ec4") },
                    { new Guid("a621b2ae-9279-4476-ab52-86a86b12ee1e"), null, new Guid("cc5ec2a9-0edf-4cfe-b952-0ba8b18052b1"), null, new Guid("0902143a-6fec-4a01-9894-51708dacd4b2") },
                    { new Guid("a6acc75f-7f80-4ce2-981a-7abc3e2731ea"), null, new Guid("cc5ec2a9-0edf-4cfe-b952-0ba8b18052b1"), null, new Guid("68ee84f6-6d10-454f-866d-15ae5544304a") },
                    { new Guid("a95d769d-9a66-4e4f-b284-c51d84e3ad69"), null, new Guid("656ef65a-6a48-4ea7-b078-6b5238b95e93"), null, new Guid("3519d9ca-d66c-464f-b4c7-770c7096ed9d") },
                    { new Guid("a97f0c12-176a-4397-b445-defa1fad7784"), null, new Guid("a82f285e-5dab-47ce-9525-717c5e7e2dba"), null, new Guid("54cea234-2158-4843-9763-12880a2e9297") },
                    { new Guid("aa714001-4565-406c-a65c-81a0cd23de47"), null, new Guid("8e3009c8-67b8-4008-9e8f-e8d5026600fe"), null, new Guid("3519d9ca-d66c-464f-b4c7-770c7096ed9d") },
                    { new Guid("acddac22-8f85-47ff-8640-3912f80b7dd7"), null, new Guid("e9c0e768-032d-4c32-873f-02d4d7ffcba9"), null, new Guid("153b7ec2-ac8e-4e5e-b6b3-48961adb5089") },
                    { new Guid("b0d57d28-eb39-45b1-86d4-fe46990bbc98"), null, new Guid("656ef65a-6a48-4ea7-b078-6b5238b95e93"), null, new Guid("a4ee7914-492b-49e1-8691-c364d1c604ea") },
                    { new Guid("b36e7528-8149-4318-b168-906085a776c9"), null, new Guid("86192e09-62ca-4f95-bef7-12cfd08eb24b"), null, new Guid("153b7ec2-ac8e-4e5e-b6b3-48961adb5089") },
                    { new Guid("b37c34a0-b64e-4088-bca3-b853da98d654"), null, new Guid("e9c0e768-032d-4c32-873f-02d4d7ffcba9"), null, new Guid("55a67337-b6dd-4193-bf4a-5c8d3ad37ec4") },
                    { new Guid("b40f5127-ec66-45e4-af7d-ae7145150d11"), null, new Guid("e2062100-eb3c-4d0c-b1e5-0963dae4563f"), null, new Guid("47ea9e21-266b-418c-a127-5e4ea11cc85e") },
                    { new Guid("b74971d7-5331-455c-bb9f-b15a4c252985"), null, new Guid("89c2afd1-f00d-4e88-89da-c481c19a82fc"), null, new Guid("3aa347d2-8d17-4696-a6a5-dd577d96c6dd") },
                    { new Guid("b75445c8-3928-40b1-822a-b95e9fa9bc13"), null, new Guid("6d69e048-0627-4d3d-a780-aaf7099a575d"), null, new Guid("153b7ec2-ac8e-4e5e-b6b3-48961adb5089") },
                    { new Guid("b9560f22-31c0-4c03-88e3-2debf7768d7e"), null, new Guid("656ef65a-6a48-4ea7-b078-6b5238b95e93"), null, new Guid("a39b757c-cd87-4d54-a904-8f10b7bac0b8") },
                    { new Guid("ba3224d3-bca3-4e25-b195-34dd9d27dd99"), null, new Guid("eca33ae7-2513-4163-8740-c6c49aeb7f09"), null, new Guid("a39b757c-cd87-4d54-a904-8f10b7bac0b8") },
                    { new Guid("bc409e2f-7446-4934-be74-1eea1fc27ae4"), null, new Guid("8f9923e0-528f-4c62-96c8-f8383bf1168f"), null, new Guid("55a67337-b6dd-4193-bf4a-5c8d3ad37ec4") },
                    { new Guid("bfc5dcd3-7344-4097-b2bd-623391d9c383"), null, new Guid("89c2afd1-f00d-4e88-89da-c481c19a82fc"), null, new Guid("153b7ec2-ac8e-4e5e-b6b3-48961adb5089") },
                    { new Guid("c186e956-2f75-439a-bddf-4a515cec556b"), null, new Guid("cc5ec2a9-0edf-4cfe-b952-0ba8b18052b1"), null, new Guid("49c4c24f-c63c-46f2-9906-ec8dcab7be2f") },
                    { new Guid("c1c5ba3e-6f53-4178-a67c-288f5d40e960"), null, new Guid("e2062100-eb3c-4d0c-b1e5-0963dae4563f"), null, new Guid("54cea234-2158-4843-9763-12880a2e9297") },
                    { new Guid("c31d858a-9930-4d49-b668-bd6439445e5b"), null, new Guid("a82f285e-5dab-47ce-9525-717c5e7e2dba"), null, new Guid("758e147c-990a-4796-b8b1-56f97a6a13eb") },
                    { new Guid("c32f8d5e-c766-49cc-9c32-976b1e1ba978"), null, new Guid("dd92eddf-1a4d-4366-81e8-b901539c77b7"), null, new Guid("a4ee7914-492b-49e1-8691-c364d1c604ea") },
                    { new Guid("c35aaf0c-6700-466a-ac42-60dbd0577fe9"), null, new Guid("e9c0e768-032d-4c32-873f-02d4d7ffcba9"), null, new Guid("47ea9e21-266b-418c-a127-5e4ea11cc85e") },
                    { new Guid("c5c12cf8-7f92-4855-aeae-da52c039110d"), null, new Guid("d8b76814-48f0-4ecb-b832-2d62a8f17fab"), null, new Guid("fe192eb3-e95c-4481-b1d5-979ed5b9d57b") },
                    { new Guid("ca87b2f7-8296-4abe-822a-eb806fb247f5"), null, new Guid("d8b76814-48f0-4ecb-b832-2d62a8f17fab"), null, new Guid("55a67337-b6dd-4193-bf4a-5c8d3ad37ec4") },
                    { new Guid("d06217f8-ecbd-4e52-9747-0dbfb63d96fb"), null, new Guid("656ef65a-6a48-4ea7-b078-6b5238b95e93"), null, new Guid("758e147c-990a-4796-b8b1-56f97a6a13eb") },
                    { new Guid("d1953be5-6a75-481f-9ead-449f9543a136"), null, new Guid("166758f6-5182-4682-b3d6-8ad730188401"), null, new Guid("a4ee7914-492b-49e1-8691-c364d1c604ea") },
                    { new Guid("d6fcb3c2-a260-4e4d-b1df-5fb22a369fd8"), null, new Guid("a82f285e-5dab-47ce-9525-717c5e7e2dba"), null, new Guid("47ea9e21-266b-418c-a127-5e4ea11cc85e") },
                    { new Guid("d7a61d26-e69a-4d4d-b465-188acd1f68e6"), null, new Guid("e9c0e768-032d-4c32-873f-02d4d7ffcba9"), null, new Guid("54cea234-2158-4843-9763-12880a2e9297") },
                    { new Guid("dc083a69-3a31-4efe-af31-e6309669af76"), null, new Guid("d8b76814-48f0-4ecb-b832-2d62a8f17fab"), null, new Guid("39c6c265-b927-4ba4-bcd9-3be2ca01d9fb") },
                    { new Guid("dc2b4f83-299b-43ab-891e-8d7803c5a568"), null, new Guid("d6877b30-38c6-43d0-ad32-f2a1696c4f3a"), null, new Guid("68ee84f6-6d10-454f-866d-15ae5544304a") },
                    { new Guid("dc5ea2de-c9af-4dc6-a23f-8b0f69fa54a1"), null, new Guid("c052b5b7-f6b1-4e72-a344-6af6f737c3a2"), null, new Guid("f418e182-d81a-4311-a6bf-edf4cca2d4ee") },
                    { new Guid("e456122b-442d-4bae-b014-61b162557eb5"), null, new Guid("d2983ca1-201e-44ce-a1e4-3ce71e5f23ee"), null, new Guid("3aa347d2-8d17-4696-a6a5-dd577d96c6dd") },
                    { new Guid("e52368ca-7a10-4a75-a0a6-683604223bc0"), null, new Guid("d6877b30-38c6-43d0-ad32-f2a1696c4f3a"), null, new Guid("153b7ec2-ac8e-4e5e-b6b3-48961adb5089") },
                    { new Guid("e9468d33-41b8-4856-a5e4-290a36615fed"), null, new Guid("6d69e048-0627-4d3d-a780-aaf7099a575d"), null, new Guid("a39b757c-cd87-4d54-a904-8f10b7bac0b8") },
                    { new Guid("eaf5afc6-c041-44b5-9ebe-626d9fac848a"), null, new Guid("eca33ae7-2513-4163-8740-c6c49aeb7f09"), null, new Guid("47ea9e21-266b-418c-a127-5e4ea11cc85e") },
                    { new Guid("ee7b147a-5cfb-42c6-89e2-2a315457b1d7"), null, new Guid("89c2afd1-f00d-4e88-89da-c481c19a82fc"), null, new Guid("3aa347d2-8d17-4696-a6a5-dd577d96c6dd") },
                    { new Guid("f0de8145-6ab6-41ba-a808-9dc16e1ecfe9"), null, new Guid("a82f285e-5dab-47ce-9525-717c5e7e2dba"), null, new Guid("54cea234-2158-4843-9763-12880a2e9297") },
                    { new Guid("f0e64c35-5084-4147-90e0-75639eaa547e"), null, new Guid("0deb52dc-2966-4bbc-84ef-eced23d66efe"), null, new Guid("f418e182-d81a-4311-a6bf-edf4cca2d4ee") },
                    { new Guid("f13f9927-6b95-4580-9e9b-deced94e4129"), null, new Guid("eca33ae7-2513-4163-8740-c6c49aeb7f09"), null, new Guid("153b7ec2-ac8e-4e5e-b6b3-48961adb5089") },
                    { new Guid("f329695a-0541-452b-80a2-d7e00e04336a"), null, new Guid("86192e09-62ca-4f95-bef7-12cfd08eb24b"), null, new Guid("f418e182-d81a-4311-a6bf-edf4cca2d4ee") },
                    { new Guid("f56d6aa9-9c00-4453-8b09-9a798e9a9c45"), null, new Guid("e2062100-eb3c-4d0c-b1e5-0963dae4563f"), null, new Guid("49c4c24f-c63c-46f2-9906-ec8dcab7be2f") },
                    { new Guid("f5917efe-264b-469a-9fda-3bcc4b0e014e"), null, new Guid("166758f6-5182-4682-b3d6-8ad730188401"), null, new Guid("a4ee7914-492b-49e1-8691-c364d1c604ea") },
                    { new Guid("f84d055a-dfaa-4874-a826-0420fa17279a"), null, new Guid("178526aa-8e82-40b2-bcab-c0539d959300"), null, new Guid("3519d9ca-d66c-464f-b4c7-770c7096ed9d") },
                    { new Guid("f89275bc-3c4b-4241-9c4d-53a8df8956d9"), null, new Guid("e9c0e768-032d-4c32-873f-02d4d7ffcba9"), null, new Guid("55a67337-b6dd-4193-bf4a-5c8d3ad37ec4") },
                    { new Guid("f9c8412b-7cfa-45b1-8b6f-a9d1c0bf2ce9"), null, new Guid("a82f285e-5dab-47ce-9525-717c5e7e2dba"), null, new Guid("47ea9e21-266b-418c-a127-5e4ea11cc85e") },
                    { new Guid("fc3eeb10-d192-4393-8e9d-7bf9bc4bf48e"), null, new Guid("656ef65a-6a48-4ea7-b078-6b5238b95e93"), null, new Guid("fe192eb3-e95c-4481-b1d5-979ed5b9d57b") },
                    { new Guid("fdd69987-f464-446a-8393-e0292fe5672d"), null, new Guid("8e3009c8-67b8-4008-9e8f-e8d5026600fe"), null, new Guid("a4ee7914-492b-49e1-8691-c364d1c604ea") },
                    { new Guid("ffc533d1-53f4-4cef-b14a-eaaaef944d7a"), null, new Guid("656ef65a-6a48-4ea7-b078-6b5238b95e93"), null, new Guid("3aa347d2-8d17-4696-a6a5-dd577d96c6dd") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("003fe415-f100-468f-91f9-8edc65a03207"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("0151f289-aefd-4849-a797-c12c0a6871c2"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("023e2f24-b633-4c45-a6b2-16634e5c62f2"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("051704b7-eb2f-4dec-81d0-f98e84454430"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("0a2b5e9b-1cb2-4b31-9d02-06645825ff1a"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("0b8b1716-7128-4744-946a-1fd492ba01ac"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("0ce9ddc3-225e-4f49-9c2b-1af55c8950f3"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("0d09317d-6b56-499a-8a4f-70ab7a29fca7"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("10147603-0be6-44de-afbf-f4ba7aefb4fd"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("12fa877c-eab1-4a0a-9645-cb7ab82c4e1c"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("15d4c49a-2036-43c1-ad8c-dc009f33c01d"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("199e9c57-0e3b-442e-9adc-5300e0df9d8e"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("1a2048b3-a18f-4c6d-aeb4-4a8f74988c79"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("1ddbe022-a455-41bd-bfd8-9737dd6205db"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("1efdc434-ddcf-4baf-a8d7-6e3dc7199124"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("223caf3c-9d29-4812-af40-51af00643292"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("254b03d0-9f35-4261-bd31-84a6a063639f"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("296461d6-75a8-4bb5-bd42-60f28310f887"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("2ca04d07-28ba-4470-a3ac-5b72bdf5759c"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("2e65ee87-3d27-4c95-9a7b-8f2e8224679b"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("2f27af72-69df-4079-ac68-e49786f1a17e"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("316d9957-3daf-4c6f-8c5e-c7e6ab470903"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("35143e3d-e164-4ea8-a08b-960171e4ffac"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("36597a04-1815-48e3-81b3-03c8b3a17c8a"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("37515c46-2142-4188-a0e8-5a9bdff1a305"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("37969aa0-37e9-413e-8c4b-fa42538d1970"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("3832ed03-ff7c-4896-b045-fde75626e50c"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("3cd6b71d-36cc-42f9-a81f-32fecbe39bc5"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("3e6e11cf-0a33-4a9c-a010-c8acd363e350"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("3e75d41b-ff95-44c5-9b8e-3d09ba34f5a4"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("409371b5-85de-47f7-9bed-2cb660fe3be1"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("41551d37-9050-495c-8ac8-7cc69f59521e"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("44d064ac-7e47-4b77-b5db-1243add4c6ef"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("44d650ea-1df0-479f-b57c-a18bbcb50441"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("490b0948-19ad-4af5-8d2e-6e3a2e41d25f"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("4b971fb4-a84f-4ce5-83e9-74f7a01a3391"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("4eb178f5-91f4-459c-84a0-cc217eb0abee"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("4f26b86a-2bb6-43b1-a5dd-ca9b6187a97b"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("5740809d-5759-44e4-8e56-d4d549cacb36"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("5a228dea-9797-422e-ab46-6513f1ef9b00"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("5f9f49dc-8afb-4787-8eb0-3f1b8dbe1476"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("60145281-512e-46ae-98d0-57b812f8541d"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("612c435f-d34e-478b-8b82-271365b116c6"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("66643bab-ab61-4879-a53f-15ffb09acf2d"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("67c21979-723f-49cf-bd3d-95657c1e1430"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("682b38d0-57d9-4f02-aabb-a2894927b314"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("6d329f5e-d578-458c-b193-6b845a6956a8"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("6d8364d4-2aaf-4cfc-bc11-38b86c864c23"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("6e5b7d23-bc64-4ff3-b733-b4fa4342d0bc"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("703e6cb3-4c5b-4494-8fd6-11d92fe668fb"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("72fb53a6-2f1c-4cbf-b855-77a6a26bf16d"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("7330d8fb-5a13-48e9-a7a4-3b4b565eb8ca"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("75c6d102-9e22-41b1-94b4-67f2c2d77af1"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("78f6f505-2935-4473-bb5d-c6c68ea5cc47"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("81959782-b39c-4ca4-9be9-0a9b6f7799f7"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("831bb69e-ed36-49d9-94ef-bb74166a1edb"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("84d6bd5f-379e-4386-a332-c185b0c0dc4a"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("85d76a61-3ed3-4201-857f-349a7a7f49fe"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("8821cdf1-2ffb-4815-9806-f278cf86ecdb"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("89fcf5b6-7e6f-4c8c-82d2-1ec86e22bb7d"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("8aa9cf33-d16b-44b1-a021-f89c784f67d2"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("92972bee-62c2-4d16-b24c-d12984568d3c"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("92e53390-f60d-49e4-b381-3274a002ecc0"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("95bad3b1-5af9-4978-a78b-5f7f490e70fe"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("9631389b-aaaa-4034-b29a-179ea195895a"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("9dfb8329-d828-445c-bc76-e1b937f45c44"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("9e07316f-a487-4392-9212-b8b72042d1d2"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("9eb468a0-4830-424c-a395-97304a33b98c"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("9f1d44ea-d377-498e-990f-0801020f26df"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("a56dcfbe-63bb-452a-a48f-e70ec83a5e4e"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("a621b2ae-9279-4476-ab52-86a86b12ee1e"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("a6acc75f-7f80-4ce2-981a-7abc3e2731ea"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("a95d769d-9a66-4e4f-b284-c51d84e3ad69"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("a97f0c12-176a-4397-b445-defa1fad7784"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("aa714001-4565-406c-a65c-81a0cd23de47"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("acddac22-8f85-47ff-8640-3912f80b7dd7"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("b0d57d28-eb39-45b1-86d4-fe46990bbc98"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("b36e7528-8149-4318-b168-906085a776c9"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("b37c34a0-b64e-4088-bca3-b853da98d654"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("b40f5127-ec66-45e4-af7d-ae7145150d11"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("b74971d7-5331-455c-bb9f-b15a4c252985"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("b75445c8-3928-40b1-822a-b95e9fa9bc13"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("b9560f22-31c0-4c03-88e3-2debf7768d7e"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("ba3224d3-bca3-4e25-b195-34dd9d27dd99"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("bc409e2f-7446-4934-be74-1eea1fc27ae4"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("bfc5dcd3-7344-4097-b2bd-623391d9c383"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("c186e956-2f75-439a-bddf-4a515cec556b"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("c1c5ba3e-6f53-4178-a67c-288f5d40e960"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("c31d858a-9930-4d49-b668-bd6439445e5b"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("c32f8d5e-c766-49cc-9c32-976b1e1ba978"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("c35aaf0c-6700-466a-ac42-60dbd0577fe9"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("c5c12cf8-7f92-4855-aeae-da52c039110d"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("ca87b2f7-8296-4abe-822a-eb806fb247f5"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("d06217f8-ecbd-4e52-9747-0dbfb63d96fb"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("d1953be5-6a75-481f-9ead-449f9543a136"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("d6fcb3c2-a260-4e4d-b1df-5fb22a369fd8"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("d7a61d26-e69a-4d4d-b465-188acd1f68e6"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("dc083a69-3a31-4efe-af31-e6309669af76"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("dc2b4f83-299b-43ab-891e-8d7803c5a568"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("dc5ea2de-c9af-4dc6-a23f-8b0f69fa54a1"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("e456122b-442d-4bae-b014-61b162557eb5"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("e52368ca-7a10-4a75-a0a6-683604223bc0"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("e9468d33-41b8-4856-a5e4-290a36615fed"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("eaf5afc6-c041-44b5-9ebe-626d9fac848a"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("ee7b147a-5cfb-42c6-89e2-2a315457b1d7"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("f0de8145-6ab6-41ba-a808-9dc16e1ecfe9"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("f0e64c35-5084-4147-90e0-75639eaa547e"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("f13f9927-6b95-4580-9e9b-deced94e4129"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("f329695a-0541-452b-80a2-d7e00e04336a"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("f56d6aa9-9c00-4453-8b09-9a798e9a9c45"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("f5917efe-264b-469a-9fda-3bcc4b0e014e"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("f84d055a-dfaa-4874-a826-0420fa17279a"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("f89275bc-3c4b-4241-9c4d-53a8df8956d9"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("f9c8412b-7cfa-45b1-8b6f-a9d1c0bf2ce9"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("fc3eeb10-d192-4393-8e9d-7bf9bc4bf48e"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("fdd69987-f464-446a-8393-e0292fe5672d"));

            migrationBuilder.DeleteData(
                table: "OrderMeal",
                keyColumn: "Id",
                keyValue: new Guid("ffc533d1-53f4-4cef-b14a-eaaaef944d7a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5c6aea35-3eae-480d-673b-08dc4758c63e"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("0deb52dc-2966-4bbc-84ef-eced23d66efe"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("166758f6-5182-4682-b3d6-8ad730188401"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("178526aa-8e82-40b2-bcab-c0539d959300"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("656ef65a-6a48-4ea7-b078-6b5238b95e93"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("6d69e048-0627-4d3d-a780-aaf7099a575d"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("86192e09-62ca-4f95-bef7-12cfd08eb24b"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("89c2afd1-f00d-4e88-89da-c481c19a82fc"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("8e3009c8-67b8-4008-9e8f-e8d5026600fe"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("8f9923e0-528f-4c62-96c8-f8383bf1168f"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("a82f285e-5dab-47ce-9525-717c5e7e2dba"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("c052b5b7-f6b1-4e72-a344-6af6f737c3a2"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("cc5ec2a9-0edf-4cfe-b952-0ba8b18052b1"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("d2983ca1-201e-44ce-a1e4-3ce71e5f23ee"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("d6877b30-38c6-43d0-ad32-f2a1696c4f3a"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("d8b76814-48f0-4ecb-b832-2d62a8f17fab"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("dd92eddf-1a4d-4366-81e8-b901539c77b7"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("e2062100-eb3c-4d0c-b1e5-0963dae4563f"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("e9c0e768-032d-4c32-873f-02d4d7ffcba9"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("eca33ae7-2513-4163-8740-c6c49aeb7f09"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("fb772fcd-07a5-4fd7-80e7-ea09d6c64f3d"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("0902143a-6fec-4a01-9894-51708dacd4b2"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("153b7ec2-ac8e-4e5e-b6b3-48961adb5089"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("3519d9ca-d66c-464f-b4c7-770c7096ed9d"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("39c6c265-b927-4ba4-bcd9-3be2ca01d9fb"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("3aa347d2-8d17-4696-a6a5-dd577d96c6dd"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("47ea9e21-266b-418c-a127-5e4ea11cc85e"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("49c4c24f-c63c-46f2-9906-ec8dcab7be2f"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("54cea234-2158-4843-9763-12880a2e9297"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("55a67337-b6dd-4193-bf4a-5c8d3ad37ec4"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("68ee84f6-6d10-454f-866d-15ae5544304a"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("758e147c-990a-4796-b8b1-56f97a6a13eb"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("a39b757c-cd87-4d54-a904-8f10b7bac0b8"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("a4ee7914-492b-49e1-8691-c364d1c604ea"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("d22634cf-c1de-455a-b649-80f53056b318"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("f418e182-d81a-4311-a6bf-edf4cca2d4ee"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("fe192eb3-e95c-4481-b1d5-979ed5b9d57b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("49e6787d-0515-4062-8c6e-f51acf91a45c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c66a3950-f0a3-4015-673a-08dc4758c63e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
