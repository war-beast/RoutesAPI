using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Origin = table.Column<string>(type: "text", nullable: false),
                    Destination = table.Column<string>(type: "text", nullable: false),
                    OriginDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DestinationDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    TimeLimit = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Destination", "DestinationDateTime", "Origin", "OriginDateTime", "Price", "TimeLimit" },
                values: new object[,]
                {
                    { new Guid("0d2da54c-9263-47ef-acd7-bbfe6809ae2a"), "Sochi", new DateTime(2024, 3, 11, 10, 46, 35, 654, DateTimeKind.Utc).AddTicks(9391), "Moscow", new DateTime(2024, 2, 12, 10, 46, 35, 654, DateTimeKind.Utc).AddTicks(9385), 100.10m, new DateTime(2024, 3, 11, 10, 46, 35, 654, DateTimeKind.Utc).AddTicks(9419) },
                    { new Guid("51dc3cc1-59ac-4a60-a87f-0dd71c5779e6"), "Piter", new DateTime(2024, 4, 11, 10, 46, 35, 654, DateTimeKind.Utc).AddTicks(9423), "Kirov", new DateTime(2024, 2, 21, 10, 46, 35, 654, DateTimeKind.Utc).AddTicks(9422), 50.00m, new DateTime(2024, 4, 11, 10, 46, 35, 654, DateTimeKind.Utc).AddTicks(9426) },
                    { new Guid("6444a2db-4742-4c38-870f-1bb3dd9b69cd"), "Ekat", new DateTime(2024, 5, 11, 10, 46, 35, 654, DateTimeKind.Utc).AddTicks(9428), "Kazan", new DateTime(2024, 2, 26, 10, 46, 35, 654, DateTimeKind.Utc).AddTicks(9427), 100.10m, new DateTime(2024, 5, 11, 10, 46, 35, 654, DateTimeKind.Utc).AddTicks(9430) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}
