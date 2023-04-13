using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodProcessorShop.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodProcessors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Company = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    BowlMaterial = table.Column<string>(type: "text", nullable: false),
                    BowlCapacity = table.Column<double>(type: "double precision", nullable: false),
                    SpeedsCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodProcessors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    User = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    ContactPhone = table.Column<string>(type: "text", nullable: false),
                    isUrgently = table.Column<bool>(type: "boolean", nullable: false),
                    FoodProcessorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_FoodProcessors_FoodProcessorId",
                        column: x => x.FoodProcessorId,
                        principalTable: "FoodProcessors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FoodProcessors",
                columns: new[] { "Id", "BowlCapacity", "BowlMaterial", "Company", "Name", "Price", "SpeedsCount" },
                values: new object[,]
                {
                    { new Guid("3875e3fb-2def-42a5-ac94-f904569c7eb7"), 4.0, "Металл", "Endever", "Sigma-21S", 6099, 6 },
                    { new Guid("b17ddd4a-b7ae-4bde-a25d-dba74c6ab5f3"), 0.34999999999999998, "Пластик", "Aresa", "AR-1704", 2399, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FoodProcessorId",
                table: "Orders",
                column: "FoodProcessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "FoodProcessors");
        }
    }
}
