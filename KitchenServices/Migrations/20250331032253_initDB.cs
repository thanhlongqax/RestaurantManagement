using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KitchenServices.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kitchenOrders",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    OrderId = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    totalPreparationTime = table.Column<int>(type: "integer", nullable: true),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kitchenOrders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "kitchenOrderItems",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    MenuItemId = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    PreparationTime = table.Column<int>(type: "integer", nullable: true),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    KitchenOrderId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kitchenOrderItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_kitchenOrderItems_kitchenOrders_KitchenOrderId",
                        column: x => x.KitchenOrderId,
                        principalTable: "kitchenOrders",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_kitchenOrderItems_KitchenOrderId",
                table: "kitchenOrderItems",
                column: "KitchenOrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kitchenOrderItems");

            migrationBuilder.DropTable(
                name: "kitchenOrders");
        }
    }
}
