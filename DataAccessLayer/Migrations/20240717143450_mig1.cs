using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Admin_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin_mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin_password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Admin_Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Branch_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Branch_Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Appointment_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Branch_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customer_Id);
                    table.ForeignKey(
                        name: "FK_Customers_Branches_Branch_Id",
                        column: x => x.Branch_Id,
                        principalTable: "Branches",
                        principalColumn: "Branch_Id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Employee_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employee_mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employee_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Branch_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Employee_Id);
                    table.ForeignKey(
                        name: "FK_Employees_Branches_Branch_Id",
                        column: x => x.Branch_Id,
                        principalTable: "Branches",
                        principalColumn: "Branch_Id");
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Appointment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    Employee_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Appointment_Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Customers_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customers",
                        principalColumn: "Customer_Id");
                    table.ForeignKey(
                        name: "FK_Appointments_Employees_Employee_Id",
                        column: x => x.Employee_Id,
                        principalTable: "Employees",
                        principalColumn: "Employee_Id");
                });

            migrationBuilder.CreateTable(
                name: "Processs",
                columns: table => new
                {
                    Process_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    Employee_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processs", x => x.Process_Id);
                    table.ForeignKey(
                        name: "FK_Processs_Customers_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customers",
                        principalColumn: "Customer_Id");
                    table.ForeignKey(
                        name: "FK_Processs_Employees_Employee_Id",
                        column: x => x.Employee_Id,
                        principalTable: "Employees",
                        principalColumn: "Employee_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Customer_Id",
                table: "Appointments",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Employee_Id",
                table: "Appointments",
                column: "Employee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Branch_Id",
                table: "Customers",
                column: "Branch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Branch_Id",
                table: "Employees",
                column: "Branch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Processs_Customer_Id",
                table: "Processs",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Processs_Employee_Id",
                table: "Processs",
                column: "Employee_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Processs");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}
