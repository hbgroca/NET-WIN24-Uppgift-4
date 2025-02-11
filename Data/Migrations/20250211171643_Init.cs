using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    CompanyNr = table.Column<string>(type: "nvarchar(16)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(125)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(45)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(45)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(125)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(45)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(45)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(125)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(25)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(125)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(125)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    ServiceCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_StatusType_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CompanyName", "CompanyNr", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Töm & Glöm AB", "556501-1234", "nustrulardetigen@helvetes.net", "Robban", "Carlsson", "555123456" },
                    { 2, null, null, "sara.syntax@domain.net", "Sara", "Syntax", "555654321" },
                    { 3, null, null, "mackan.nilsson@domain.net", "Markus", "Nilsson", "555123456" },
                    { 4, null, null, "henke@domain.net", "Henrik", "Rosengren", "555123456" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "nustrulardetigen@helvetes.net", "Klabbe", "Röv", "0701234567" },
                    { 2, "hasse.kopilator@domain.net", "Hasse", "Kompilator", "0700765321" },
                    { 3, "nisse@domain.net", "Nils", "Visman", "0700123456" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Price", "ServiceName" },
                values: new object[,]
                {
                    { 1, 135m, "Consulting" },
                    { 2, 145m, "Web Development" },
                    { 3, 145m, "Mobile Development" },
                    { 4, 145m, "Database Development" },
                    { 5, 140m, "Backend Performance" },
                    { 6, 0m, "Hang out" }
                });

            migrationBuilder.InsertData(
                table: "StatusType",
                columns: new[] { "Id", "StatusDescription" },
                values: new object[,]
                {
                    { 1, "Completed" },
                    { 2, "In Progress" },
                    { 3, "Not Started" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CustomerId", "Description", "EmployeeId", "EndDate", "ProjectName", "ServiceCost", "ServiceId", "StartDate", "StatusId" },
                values: new object[,]
                {
                    { 1, 1, null, 1, new DateOnly(2025, 4, 1), "Build database 4 client", 6500m, 4, new DateOnly(2025, 2, 1), 2 },
                    { 2, 4, null, 1, new DateOnly(2026, 5, 29), "Hang out with Robban", 0m, 2, new DateOnly(2024, 8, 26), 2 },
                    { 3, 2, null, 3, new DateOnly(2025, 8, 31), "Build TodoApp", 9000m, 6, new DateOnly(2025, 4, 1), 3 },
                    { 4, 2, null, 2, new DateOnly(2025, 1, 31), "Update business webpage", 4400m, 2, new DateOnly(2024, 12, 1), 1 },
                    { 5, 3, null, 3, new DateOnly(2025, 1, 31), "Optimise services", 3790m, 4, new DateOnly(2024, 12, 1), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CustomerId",
                table: "Projects",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_EmployeeId",
                table: "Projects",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ServiceId",
                table: "Projects",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StatusId",
                table: "Projects",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "StatusType");
        }
    }
}
