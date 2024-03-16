using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaceMyOrder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Autoconfigurazionetabellemanytomanyperorderemeal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MealEntityId",
                table: "OrderMeal",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderEntityId",
                table: "OrderMeal",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderMeal_MealEntityId",
                table: "OrderMeal",
                column: "MealEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMeal_OrderEntityId",
                table: "OrderMeal",
                column: "OrderEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMeal_Meals_MealEntityId",
                table: "OrderMeal",
                column: "MealEntityId",
                principalTable: "Meals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMeal_Orders_OrderEntityId",
                table: "OrderMeal",
                column: "OrderEntityId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderMeal_Meals_MealEntityId",
                table: "OrderMeal");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMeal_Orders_OrderEntityId",
                table: "OrderMeal");

            migrationBuilder.DropIndex(
                name: "IX_OrderMeal_MealEntityId",
                table: "OrderMeal");

            migrationBuilder.DropIndex(
                name: "IX_OrderMeal_OrderEntityId",
                table: "OrderMeal");

            migrationBuilder.DropColumn(
                name: "MealEntityId",
                table: "OrderMeal");

            migrationBuilder.DropColumn(
                name: "OrderEntityId",
                table: "OrderMeal");

            migrationBuilder.CreateTable(
                name: "MealEntityOrderEntity",
                columns: table => new
                {
                    MealsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrdersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealEntityOrderEntity", x => new { x.MealsId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_MealEntityOrderEntity_Meals_MealsId",
                        column: x => x.MealsId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealEntityOrderEntity_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealEntityOrderEntity_OrdersId",
                table: "MealEntityOrderEntity",
                column: "OrdersId");
        }
    }
}
